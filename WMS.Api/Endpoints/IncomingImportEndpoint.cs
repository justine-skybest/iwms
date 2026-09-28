using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WMS.Api.Data;
using WMS.Api.Entities;

namespace WMS.Api.Endpoints
{
    public static class IncomingImportEndpoint
    {
        public static RouteGroupBuilder MapIncomingImportEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("incoming-import")
                .WithTags("IncomingImport")
                .WithParameterValidation();

            // ------------------------------------------------------------------
            // 1. IMPORT INITIAL EXCEL
            // ------------------------------------------------------------------
            group.MapPost("/import-excel", async (
                IFormFile file,
                int warehouseId,
                WMSContext dbContext,
                CancellationToken cancellationToken) =>
            {
                var parseResult = await ParseExcelAsync(file, dbContext, cancellationToken);
                if (parseResult.ResultError is not null) return parseResult.ResultError;

                var incoming = new Incoming
                {
                    WarehouseId = warehouseId,
                    Shipper = parseResult.Shipper,
                    Consignee = parseResult.Consignee,
                    Status = IncomingStatus.PENDING,
                    Products = parseResult.IncomingProducts
                };

                dbContext.Incomings.Add(incoming);
                await dbContext.SaveChangesAsync(cancellationToken);

                return Results.Created($"/incoming/{incoming.Id}", new
                {
                    IncomingId = incoming.Id,
                    NewProductsCreated = parseResult.NewProductsDict.Count,
                    Message = $"Successfully created incoming entry with {parseResult.IncomingProducts.Count} line items ({parseResult.NewProductsDict.Count} new products auto-created)."
                });
            })
            .DisableAntiforgery()
            .WithName("ImportIncomingFromExcel")
            .WithSummary("Import an incoming shipment from an Excel packing list")
            .Accepts<IFormFile>("multipart/form-data")
            .Produces(StatusCodes.Status201Created)
            .Produces<string>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status422UnprocessableEntity);

            // ------------------------------------------------------------------
            // 2. REVISE EXISTING INCOMING SHIPMENT EXCEL
            // ------------------------------------------------------------------
            group.MapPost("/{incomingId:int}/revision-excel", async (
                            int incomingId,
                            IFormFile file,
                            WMSContext dbContext,
                            CancellationToken cancellationToken) =>
            {
                var existingIncoming = await dbContext.Incomings
                    .Include(i => i.Products!)
                        .ThenInclude(p => p.Product)
                    .FirstOrDefaultAsync(i => i.Id == incomingId, cancellationToken);

                if (existingIncoming is null)
                {
                    return Results.NotFound($"Incoming shipment with ID {incomingId} was not found.");
                }

                if (existingIncoming.Status == IncomingStatus.CANCELLED)
                {
                    return Results.BadRequest("Cannot apply revisions to a cancelled shipment.");
                }

                var parseResult = await ParseExcelAsync(file, dbContext, cancellationToken);
                if (parseResult.ResultError is not null) return parseResult.ResultError;

                var errors = new List<string>();

                // Separate existing DB items by received status
                var existingDbItems = existingIncoming.Products ?? new List<IncomingProduct>();
                var receivedItems = existingDbItems.Where(p => p.Received).ToList();
                var unreceivedItems = existingDbItems.Where(p => !p.Received).ToList();

                // Build lookup for parsed excel items by Product ID
                var excelItemMap = new Dictionary<int, IncomingProduct>();
                var newParsedItemsWithoutId = new List<IncomingProduct>();

                foreach (var item in parseResult.IncomingProducts)
                {
                    if (item.ProductId > 0)
                    {
                        excelItemMap[item.ProductId] = item;
                    }
                    else
                    {
                        newParsedItemsWithoutId.Add(item);
                    }
                }

                // RULE 1: Prevent Removal or Modification of Received Items
                foreach (var recItem in receivedItems)
                {
                    string prodName = recItem.Product?.Name ?? $"Product #{recItem.ProductId}";

                    if (!excelItemMap.TryGetValue(recItem.ProductId, out var incomingExcelItem))
                    {
                        errors.Add($"Cannot remove item '{prodName}' because it has already been received.");
                        continue;
                    }

                    // Check if properties of a received item were altered in the revised Excel
                    if (recItem.Quantity != incomingExcelItem.Quantity ||
                        recItem.UnitPrice != incomingExcelItem.UnitPrice ||
                        recItem.TotalAmount != incomingExcelItem.TotalAmount ||
                        recItem.CBM != incomingExcelItem.CBM ||
                        recItem.TotalWeight != incomingExcelItem.TotalWeight ||
                        recItem.ExpirationDate != incomingExcelItem.ExpirationDate)
                    {
                        errors.Add($"Cannot modify details for item '{prodName}' because it has already been received.");
                    }
                }

                if (errors.Any())
                {
                    return Results.UnprocessableEntity(new { Errors = errors });
                }

                // APPLY REVISIONS TO UNRECEIVED ITEMS:
                existingIncoming.Products ??= new List<IncomingProduct>();
                var processedProductIds = new HashSet<int>();

                foreach (var dbItem in unreceivedItems)
                {
                    if (excelItemMap.TryGetValue(dbItem.ProductId, out var excelItem))
                    {
                        // ITEM EDITED: Update existing unreceived entry
                        dbItem.Quantity = excelItem.Quantity;
                        dbItem.UnitPrice = excelItem.UnitPrice;
                        dbItem.TotalAmount = excelItem.TotalAmount;
                        dbItem.CBM = excelItem.CBM;
                        dbItem.TotalWeight = excelItem.TotalWeight;
                        dbItem.ExpirationDate = excelItem.ExpirationDate;
                        dbItem.Supplier = excelItem.Supplier;
                        dbItem.Remarks = excelItem.Remarks;

                        processedProductIds.Add(dbItem.ProductId);
                    }
                    else
                    {
                        // ITEM REMOVED: Item present in DB but absent in revised Excel
                        dbContext.Remove(dbItem);
                    }
                }

                // ITEM ADDED: Existing product IDs present in Excel but not in DB unreceived list
                foreach (var kvp in excelItemMap)
                {
                    int prodId = kvp.Key;
                    var excelItem = kvp.Value;

                    // Skip received items and items already processed
                    if (receivedItems.Any(r => r.ProductId == prodId) || processedProductIds.Contains(prodId))
                    {
                        continue;
                    }

                    existingIncoming.Products.Add(excelItem);
                }

                // ITEM ADDED: Completely new products auto-created from Excel
                foreach (var newExcelItem in newParsedItemsWithoutId)
                {
                    existingIncoming.Products.Add(newExcelItem);
                }

                // Update metadata if changed
                if (!string.IsNullOrWhiteSpace(parseResult.Shipper)) existingIncoming.Shipper = parseResult.Shipper;
                if (!string.IsNullOrWhiteSpace(parseResult.Consignee)) existingIncoming.Consignee = parseResult.Consignee;

                await dbContext.SaveChangesAsync(cancellationToken);

                return Results.Ok(new
                {
                    IncomingId = existingIncoming.Id,
                    NewProductsCreated = parseResult.NewProductsDict.Count,
                    Message = "Incoming shipment revised successfully."
                });
            })
            .DisableAntiforgery()
            .WithName("ReviseIncomingFromExcel")
            .WithSummary("Revise an existing incoming shipment using an updated Excel packing list")
            .Accepts<IFormFile>("multipart/form-data")
            .Produces(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status422UnprocessableEntity);

            return group;
        }

        // ====================================================================
        // SHARED EXCEL PARSING HELPER METHOD
        // ====================================================================
        private record ParseResult(
            IResult? ResultError,
            string Shipper,
            string Consignee,
            List<IncomingProduct> IncomingProducts,
            Dictionary<string, Product> NewProductsDict);

        private static async Task<ParseResult> ParseExcelAsync(
            IFormFile file,
            WMSContext dbContext,
            CancellationToken cancellationToken)
        {
            if (file is null || file.Length == 0)
            {
                return new ParseResult(Results.BadRequest("An Excel file (.xlsx) is required."), "", "", [], []);
            }

            if (!file.FileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase) &&
                !file.FileName.EndsWith(".xls", StringComparison.OrdinalIgnoreCase))
            {
                return new ParseResult(Results.BadRequest("Only Excel files (.xlsx / .xls) are supported."), "", "", [], []);
            }

            using var stream = file.OpenReadStream();
            using var reader = ExcelReaderFactory.CreateReader(stream);

            var dataSet = reader.AsDataSet();

            // 1. DYNAMIC SHEET SELECTION
            DataTable? table = dataSet.Tables.Cast<DataTable>()
                .FirstOrDefault(t => t.TableName.Equals("PACKING LIST", StringComparison.OrdinalIgnoreCase));

            if (table is null)
            {
                table = dataSet.Tables.Cast<DataTable>().FirstOrDefault(t =>
                {
                    for (int r = 0; r < Math.Min(20, t.Rows.Count); r++)
                    {
                        string col0 = t.Rows[r][0]?.ToString()?.Trim() ?? "";
                        if (col0.Equals("LN#", StringComparison.OrdinalIgnoreCase) || col0.Equals("LN #", StringComparison.OrdinalIgnoreCase))
                            return true;
                    }
                    return false;
                }) ?? dataSet.Tables[0];
            }

            if (table.Rows.Count < 5)
            {
                return new ParseResult(Results.BadRequest("Invalid Excel format. Selected sheet contains insufficient rows."), "", "", [], []);
            }

            // 2. DYNAMIC METADATA & HEADER DETECTION
            string shipper = string.Empty;
            string consignee = string.Empty;
            int headerRowIndex = -1;

            for (int r = 0; r < Math.Min(20, table.Rows.Count); r++)
            {
                string cellA = table.Rows[r][0]?.ToString()?.Trim() ?? "";

                if (cellA.StartsWith("SHIPPER:", StringComparison.OrdinalIgnoreCase))
                {
                    shipper = cellA.Replace("SHIPPER:", "", StringComparison.OrdinalIgnoreCase).Trim();
                }
                else if (cellA.StartsWith("CONSIGNEE:", StringComparison.OrdinalIgnoreCase))
                {
                    consignee = cellA.Replace("CONSIGNEE:", "", StringComparison.OrdinalIgnoreCase).Trim();
                }

                if (cellA.Equals("LN#", StringComparison.OrdinalIgnoreCase) ||
                    cellA.Equals("LN #", StringComparison.OrdinalIgnoreCase) ||
                    cellA.Equals("LN", StringComparison.OrdinalIgnoreCase))
                {
                    headerRowIndex = r;
                }
            }

            if (string.IsNullOrWhiteSpace(shipper) && table.Rows.Count > 3)
                shipper = table.Rows[3][0]?.ToString()?.Replace("SHIPPER:", "", StringComparison.OrdinalIgnoreCase).Trim() ?? "UNKNOWN SHIPPER";

            if (string.IsNullOrWhiteSpace(consignee) && table.Rows.Count > 5)
                consignee = table.Rows[5][0]?.ToString()?.Replace("CONSIGNEE:", "", StringComparison.OrdinalIgnoreCase).Trim() ?? "UNKNOWN CONSIGNEE";

            int startRow = headerRowIndex != -1 ? headerRowIndex + 1 : 13;

            var existingProductsList = await dbContext.Products
                .AsNoTracking()
                .Select(p => new { p.Id, Name = p.Name.Trim() })
                .ToListAsync(cancellationToken);

            var existingProductsDict = existingProductsList
                .GroupBy(p => p.Name, StringComparer.OrdinalIgnoreCase)
                .ToDictionary(g => g.Key, g => g.First().Id, StringComparer.OrdinalIgnoreCase);

            var newProductsDict = new Dictionary<string, Product>(StringComparer.OrdinalIgnoreCase);
            var seenProductNamesInFile = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            var errors = new List<string>();
            var incomingProducts = new List<IncomingProduct>();
            int consecutiveEmptyRows = 0;

            // 3. PARSE LINE ITEMS
            for (int r = startRow; r < table.Rows.Count; r++)
            {
                var row = table.Rows[r];
                string colLnRaw = row[0]?.ToString()?.Trim() ?? "";
                string colQtyStr = row[1]?.ToString()?.Trim() ?? "";
                string colProdCode = row[2]?.ToString()?.Trim() ?? "";
                string colDescription = row[4]?.ToString()?.Trim() ?? "";

                if (string.IsNullOrWhiteSpace(colLnRaw) &&
                    string.IsNullOrWhiteSpace(colQtyStr) &&
                    string.IsNullOrWhiteSpace(colProdCode) &&
                    string.IsNullOrWhiteSpace(colDescription))
                {
                    consecutiveEmptyRows++;
                    if (consecutiveEmptyRows >= 5) break;
                    continue;
                }

                consecutiveEmptyRows = 0;

                string cleanLn = colLnRaw.TrimEnd('.', ',', ' ').Trim();
                if (!int.TryParse(cleanLn, out int lineNumber) || lineNumber <= 0)
                {
                    continue;
                }

                int excelRowNum = r + 1;
                string productName = !string.IsNullOrWhiteSpace(colDescription) ? colDescription : colProdCode;

                if (string.IsNullOrWhiteSpace(productName))
                {
                    errors.Add($"Row {excelRowNum}: Line #{lineNumber} is missing a Product Description or Product Code.");
                    continue;
                }

                // RULE 2: Prevent item duplicates inside the file
                if (!seenProductNamesInFile.Add(productName))
                {
                    errors.Add($"Row {excelRowNum}: Duplicate item '{productName}' found in Excel file.");
                    continue;
                }

                if (!decimal.TryParse(colQtyStr, out decimal parsedQty) || parsedQty <= 0)
                {
                    errors.Add($"Row {excelRowNum}: Line #{lineNumber} ('{productName}') has an invalid quantity '{colQtyStr}'.");
                    continue;
                }
                int quantity = (int)parsedQty;

                string uom = row[3]?.ToString()?.Trim() ?? "UNIT";
                if (string.IsNullOrWhiteSpace(uom)) uom = "UNIT";

                decimal? unitPrice = decimal.TryParse(row[5]?.ToString(), out decimal parsedUnitPrice)
                    ? Math.Round(parsedUnitPrice, 2, MidpointRounding.AwayFromZero)
                    : null;

                decimal? totalAmount = decimal.TryParse(row[6]?.ToString(), out decimal parsedTotalAmount)
                    ? Math.Round(parsedTotalAmount, 2, MidpointRounding.AwayFromZero)
                    : null;

                string cbmRaw = row[8]?.ToString()?.Trim() ?? row[9]?.ToString()?.Trim() ?? "0";
                string cbm = decimal.TryParse(cbmRaw, out decimal parsedCbm)
                    ? Math.Round(parsedCbm, 4, MidpointRounding.AwayFromZero).ToString("0.####")
                    : "0";

                string totalWeightRaw = row[11]?.ToString()?.Trim() ?? "0";
                string totalWeight = decimal.TryParse(totalWeightRaw, out decimal parsedTotalWeight)
                    ? Math.Round(parsedTotalWeight, 2, MidpointRounding.AwayFromZero).ToString("0.##")
                    : "0";

                decimal unitWeight = decimal.TryParse(row[10]?.ToString(), out decimal parsedWeight)
                    ? Math.Round(parsedWeight, 2, MidpointRounding.AwayFromZero)
                    : 0m;

                string supplier = row[12]?.ToString()?.Trim() ?? "";
                string remarks = row[13]?.ToString()?.Trim() ?? "";

                DateOnly? expiryDate = null;
                if (DateTime.TryParse(row[7]?.ToString()?.Trim(), out DateTime parsedDate))
                {
                    expiryDate = DateOnly.FromDateTime(parsedDate);
                }

                var incomingProduct = new IncomingProduct
                {
                    Quantity = quantity,
                    UnitPrice = unitPrice,
                    TotalAmount = totalAmount,
                    CBM = cbm,
                    TotalWeight = totalWeight,
                    ExpirationDate = expiryDate,
                    Supplier = string.IsNullOrWhiteSpace(supplier) ? null : supplier,
                    Remarks = string.IsNullOrWhiteSpace(remarks) ? null : remarks,
                    DateAdded = DateTime.UtcNow
                };

                // Resolve Product (Existing vs Auto-Create)
                if (existingProductsDict.TryGetValue(productName, out int existingProductId))
                {
                    incomingProduct.ProductId = existingProductId;
                }
                else if (newProductsDict.TryGetValue(productName, out var cachedNewProduct))
                {
                    incomingProduct.Product = cachedNewProduct;
                }
                else
                {
                    var newProduct = new Product
                    {
                        Code = string.IsNullOrWhiteSpace(colProdCode) ? null : colProdCode,
                        Name = productName,
                        TypeOfPackage = uom,
                        Measurement = uom,
                        Weight = unitWeight,
                        DateAdded = DateTime.UtcNow
                    };

                    newProductsDict[productName] = newProduct;
                    incomingProduct.Product = newProduct;
                }

                incomingProducts.Add(incomingProduct);
            }

            if (errors.Any())
            {
                return new ParseResult(Results.UnprocessableEntity(new { Errors = errors }), "", "", [], []);
            }

            if (!incomingProducts.Any())
            {
                return new ParseResult(Results.BadRequest("No valid numbered line items were found in the file."), "", "", [], []);
            }

            return new ParseResult(null, shipper, consignee, incomingProducts, newProductsDict);
        }
    }
}