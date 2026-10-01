using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WMS.Api.Data;
using WMS.Api.Entities;
using WMS.Api.Services;

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
                IAuditLogService auditLogService,
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

                // --- ADD AUDIT LOG ENTRY ---
                await auditLogService.LogAsync(
                    category: "Incoming Import",
                    action: "Created",
                    description: $"Imported new incoming shipment '{file.FileName}' with {parseResult.IncomingProducts.Count} product(s) ({parseResult.NewProductsDict.Count} newly auto-created).",
                    details: new
                    {
                        IncomingId = incoming.Id,
                        FileName = file.FileName,
                        WarehouseId = warehouseId,
                        Shipper = parseResult.Shipper,
                        Consignee = parseResult.Consignee,
                        TotalProducts = parseResult.IncomingProducts.Count,
                        AutoCreatedProductsCount = parseResult.NewProductsDict.Count,

                        Products = parseResult.IncomingProducts.Select(p =>
                        {
                            var (name, unit) = GetProductInfo(p, parseResult.ProductInfoMap);
                            return new
                            {
                                ProductName = name,
                                Quantity = p.Quantity,
                                Unit = unit,
                                UnitPrice = p.UnitPrice,
                                TotalAmount = p.TotalAmount,
                                Expiration = p.ExpirationDate?.ToString("yyyy-MM-dd") ?? "None",
                                Supplier = string.IsNullOrWhiteSpace(p.Supplier) ? "—" : p.Supplier,
                                Status = p.Status.ToString(),
                                Remarks = string.IsNullOrWhiteSpace(p.Remarks) ? "—" : p.Remarks
                            };
                        })
                    }
                );

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
                            IAuditLogService auditLogService,
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

                var existingDbItems = existingIncoming.Products ?? new List<IncomingProduct>();

                // Separate partially or fully received items from unreceived items
                var receivedOrPartialItems = existingDbItems.Where(p => p.Status != IncomingProductStatus.UNRECEIVED).ToList();
                var unreceivedItems = existingDbItems.Where(p => p.Status == IncomingProductStatus.UNRECEIVED).ToList();

                var incomingExcelList = parseResult.IncomingProducts.ToList();

                // RULE 1: Ensure already received or partially received items remain intact in the updated Excel file
                foreach (var recItem in receivedOrPartialItems)
                {
                    string prodName = recItem.Product?.Name ?? $"Product #{recItem.ProductId}";
                    string recExpKey = recItem.ExpirationDate?.ToString("yyyy-MM-dd") ?? "NONE";

                    var matchIndex = incomingExcelList.FindIndex(excelItem =>
                        excelItem.ProductId == recItem.ProductId &&
                        (excelItem.ExpirationDate?.ToString("yyyy-MM-dd") ?? "NONE") == recExpKey &&
                        (excelItem.Supplier ?? "NONE").Trim().Equals((recItem.Supplier ?? "NONE").Trim(), StringComparison.OrdinalIgnoreCase) &&
                        excelItem.UnitPrice == recItem.UnitPrice &&
                        excelItem.Quantity == recItem.Quantity &&
                        excelItem.TotalAmount == recItem.TotalAmount &&
                        excelItem.CBM == recItem.CBM &&
                        excelItem.TotalWeight == recItem.TotalWeight
                    );

                    if (matchIndex == -1)
                    {
                        errors.Add($"Cannot remove or alter partially/fully received item '{prodName}' (Exp: {recExpKey}, Status: {recItem.Status}). Ensure it exists exactly as originally recorded in the updated Excel file.");
                    }
                    else
                    {
                        incomingExcelList.RemoveAt(matchIndex);
                    }
                }

                if (errors.Any())
                {
                    return Results.UnprocessableEntity(new { Errors = errors });
                }

                // APPLY REVISIONS: Clear existing UNRECEIVED items and append newly parsed unreceived line items
                int removedCount = unreceivedItems.Count;
                foreach (var dbItem in unreceivedItems)
                {
                    dbContext.Remove(dbItem);
                }

                int addedCount = incomingExcelList.Count;
                foreach (var newExcelItem in incomingExcelList)
                {
                    existingIncoming.Products!.Add(newExcelItem);
                }

                if (!string.IsNullOrWhiteSpace(parseResult.Shipper)) existingIncoming.Shipper = parseResult.Shipper;
                if (!string.IsNullOrWhiteSpace(parseResult.Consignee)) existingIncoming.Consignee = parseResult.Consignee;

                await dbContext.SaveChangesAsync(cancellationToken);

                // --- ADD AUDIT LOG ENTRY ---
                await auditLogService.LogAsync(
                    category: "Incoming Import",
                    action: "Updated",
                    description: $"Revised incoming shipment ID {existingIncoming.Id} via '{file.FileName}'. Removed {removedCount} unreceived item(s) and inserted {addedCount} updated item(s).",
                    details: new
                    {
                        IncomingId = existingIncoming.Id,
                        FileName = file.FileName,
                        AddedItemsCount = addedCount,
                        RemovedItemsCount = removedCount,
                        TotalFinalItems = existingIncoming.Products!.Count,

                        FinalProducts = existingIncoming.Products.Select(p =>
                        {
                            var (name, unit) = GetProductInfo(p, parseResult.ProductInfoMap);
                            return new
                            {
                                ProductName = name,
                                Quantity = p.Quantity,
                                Unit = unit,
                                UnitPrice = p.UnitPrice,
                                Expiration = p.ExpirationDate?.ToString("yyyy-MM-dd") ?? "None",
                                Supplier = string.IsNullOrWhiteSpace(p.Supplier) ? "—" : p.Supplier,
                                Status = p.Status.ToString()
                            };
                        })
                    }
                );

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
        // HELPER METHOD TO RESOLVE PRODUCT NAME & UNIT
        // ====================================================================
        private static (string Name, string Unit) GetProductInfo(
            IncomingProduct p,
            Dictionary<int, (string Name, string Unit)> productInfoMap)
        {
            if (p.Product != null && !string.IsNullOrWhiteSpace(p.Product.Name))
            {
                return (p.Product.Name, p.Product.TypeOfPackage);
            }

            if (p.ProductId > 0 && productInfoMap.TryGetValue(p.ProductId, out var info))
            {
                return info;
            }

            return ($"Product #{p.ProductId}", "N/A");
        }

        // ====================================================================
        // SHARED EXCEL PARSING HELPER METHOD
        // ====================================================================
        private record ParseResult(
            IResult? ResultError,
            string Shipper,
            string Consignee,
            List<IncomingProduct> IncomingProducts,
            Dictionary<string, Product> NewProductsDict,
            Dictionary<int, (string Name, string Unit)> ProductInfoMap);

        private static async Task<ParseResult> ParseExcelAsync(
            IFormFile file,
            WMSContext dbContext,
            CancellationToken cancellationToken)
        {
            var emptyMap = new Dictionary<int, (string Name, string Unit)>();

            if (file is null || file.Length == 0)
            {
                return new ParseResult(Results.BadRequest("An Excel file (.xlsx) is required."), "", "", [], [], emptyMap);
            }

            if (!file.FileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase) &&
                !file.FileName.EndsWith(".xls", StringComparison.OrdinalIgnoreCase))
            {
                return new ParseResult(Results.BadRequest("Only Excel files (.xlsx / .xls) are supported."), "", "", [], [], emptyMap);
            }

            using var stream = file.OpenReadStream();
            using var reader = ExcelReaderFactory.CreateReader(stream);

            var dataSet = reader.AsDataSet();

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
                return new ParseResult(Results.BadRequest("Invalid Excel format. Selected sheet contains insufficient rows."), "", "", [], [], emptyMap);
            }

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
                .Select(p => new { p.Id, Name = p.Name.Trim(), p.TypeOfPackage })
                .ToListAsync(cancellationToken);

            var existingProductsDict = existingProductsList
                .GroupBy(p => p.Name, StringComparer.OrdinalIgnoreCase)
                .ToDictionary(g => g.Key, g => g.First().Id, StringComparer.OrdinalIgnoreCase);

            var productInfoMap = existingProductsList
                .ToDictionary(p => p.Id, p => (p.Name, p.TypeOfPackage));

            var newProductsDict = new Dictionary<string, Product>(StringComparer.OrdinalIgnoreCase);

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

                DateOnly? expiryDate = null;
                if (DateTime.TryParse(row[7]?.ToString()?.Trim(), out DateTime parsedDate))
                {
                    expiryDate = DateOnly.FromDateTime(parsedDate);
                }

                string supplier = row[12]?.ToString()?.Trim() ?? "";

                decimal? unitPrice = decimal.TryParse(row[5]?.ToString(), out decimal parsedUnitPrice)
                    ? Math.Round(parsedUnitPrice, 2, MidpointRounding.AwayFromZero)
                    : null;

                if (!decimal.TryParse(colQtyStr, out decimal parsedQty) || parsedQty <= 0)
                {
                    errors.Add($"Row {excelRowNum}: Line #{lineNumber} ('{productName}') has an invalid quantity '{colQtyStr}'.");
                    continue;
                }
                int quantity = (int)parsedQty;

                string uom = row[3]?.ToString()?.Trim() ?? "UNIT";
                if (string.IsNullOrWhiteSpace(uom)) uom = "UNIT";

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

                string remarks = row[13]?.ToString()?.Trim() ?? "";

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
                    Status = IncomingProductStatus.UNRECEIVED,
                    DateAdded = DateTime.UtcNow
                };

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
                return new ParseResult(Results.UnprocessableEntity(new { Errors = errors }), "", "", [], [], emptyMap);
            }

            if (!incomingProducts.Any())
            {
                return new ParseResult(Results.BadRequest("No valid numbered line items were found in the file."), "", "", [], [], emptyMap);
            }

            return new ParseResult(null, shipper, consignee, incomingProducts, newProductsDict, productInfoMap);
        }
    }
}