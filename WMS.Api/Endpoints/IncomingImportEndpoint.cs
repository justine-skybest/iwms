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

            group.MapPost("/import-excel", async (
                IFormFile file,
                int warehouseId,
                WMSContext dbContext,
                CancellationToken cancellationToken) =>
            {
                if (file is null || file.Length == 0)
                {
                    return Results.BadRequest("An Excel file (.xlsx) is required.");
                }

                if (!file.FileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase) &&
                    !file.FileName.EndsWith(".xls", StringComparison.OrdinalIgnoreCase))
                {
                    return Results.BadRequest("Only Excel files (.xlsx / .xls) are supported.");
                }

                using var stream = file.OpenReadStream();
                using var reader = ExcelReaderFactory.CreateReader(stream);

                var dataSet = reader.AsDataSet();

                // 1. DYNAMIC SHEET SELECTION
                // Target "PACKING LIST" sheet or fall back to any sheet containing a "LN#" header
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
                    return Results.BadRequest("Invalid Excel format. Selected sheet contains insufficient rows.");
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

                // Pre-fetch existing products grouped by normalized name
                var existingProductsList = await dbContext.Products
                    .AsNoTracking()
                    .Select(p => new { p.Id, Name = p.Name.Trim() })
                    .ToListAsync(cancellationToken);

                var existingProductsDict = existingProductsList
                    .GroupBy(p => p.Name, StringComparer.OrdinalIgnoreCase)
                    .ToDictionary(g => g.Key, g => g.First().Id, StringComparer.OrdinalIgnoreCase);

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

                    // Safe Break: Stop processing if we hit 5 empty rows in a row
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

                    // STRICT LINE NUMBER CHECK: Skip supplier banners ("SUYSING SUPPLIER"), remarks, or empty rows
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

                    // QTY Parsing (handles floating point strings like "3.0")
                    if (!decimal.TryParse(colQtyStr, out decimal parsedQty) || parsedQty <= 0)
                    {
                        errors.Add($"Row {excelRowNum}: Line #{lineNumber} ('{productName}') has an invalid quantity '{colQtyStr}'.");
                        continue;
                    }
                    int quantity = (int)parsedQty;

                    string uom = row[3]?.ToString()?.Trim() ?? "UNIT";
                    if (string.IsNullOrWhiteSpace(uom)) uom = "UNIT";

                    // Parse & round Currency
                    decimal? unitPrice = decimal.TryParse(row[5]?.ToString(), out decimal parsedUnitPrice)
                        ? Math.Round(parsedUnitPrice, 2, MidpointRounding.AwayFromZero)
                        : null;

                    decimal? totalAmount = decimal.TryParse(row[6]?.ToString(), out decimal parsedTotalAmount)
                        ? Math.Round(parsedTotalAmount, 2, MidpointRounding.AwayFromZero)
                        : null;

                    // Parse, round, and re-format CBM to string ("0.084")
                    string cbmRaw = row[8]?.ToString()?.Trim() ?? row[9]?.ToString()?.Trim() ?? "0";
                    string cbm = decimal.TryParse(cbmRaw, out decimal parsedCbm)
                        ? Math.Round(parsedCbm, 4, MidpointRounding.AwayFromZero).ToString("0.####")
                        : "0";

                    // Parse, round, and re-format Total Weight to string ("60.3")
                    string totalWeightRaw = row[11]?.ToString()?.Trim() ?? "0";
                    string totalWeight = decimal.TryParse(totalWeightRaw, out decimal parsedTotalWeight)
                        ? Math.Round(parsedTotalWeight, 2, MidpointRounding.AwayFromZero).ToString("0.##")
                        : "0";

                    // Parse Unit Weight (decimal)
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
                        CBM = cbm,                   // clean string ("0.084")
                        TotalWeight = totalWeight,   // clean string ("60.3")
                        ExpirationDate = expiryDate,
                        Supplier = string.IsNullOrWhiteSpace(supplier) ? null : supplier,
                        Remarks = string.IsNullOrWhiteSpace(remarks) ? null : remarks
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
                            Measurement = uom,     // string (UOM)
                            Weight = unitWeight,   // decimal
                            DateAdded = DateTime.UtcNow
                        };

                        newProductsDict[productName] = newProduct;
                        incomingProduct.Product = newProduct;
                    }

                    incomingProducts.Add(incomingProduct);
                }

                if (errors.Any())
                {
                    return Results.UnprocessableEntity(new { Errors = errors });
                }

                if (!incomingProducts.Any())
                {
                    return Results.BadRequest("No valid numbered line items were found in the file.");
                }

                // 4. SAVE TO DATABASE
                var incoming = new Incoming
                {
                    WarehouseId = warehouseId,
                    Shipper = shipper,
                    Consignee = consignee,
                    Status = IncomingStatus.PENDING,
                    Products = incomingProducts
                };

                dbContext.Incomings.Add(incoming);
                await dbContext.SaveChangesAsync(cancellationToken);

                return Results.Created($"/incoming/{incoming.Id}", new
                {
                    IncomingId = incoming.Id,
                    NewProductsCreated = newProductsDict.Count,
                    Message = $"Successfully created incoming entry with {incomingProducts.Count} line items ({newProductsDict.Count} new products auto-created)."
                });
            })
            .DisableAntiforgery()
            .WithName("ImportIncomingFromExcel")
            .WithSummary("Import an incoming shipment from an Excel packing list")
            .Accepts<IFormFile>("multipart/form-data")
            .Produces(StatusCodes.Status201Created)
            .Produces<string>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status422UnprocessableEntity);

            return group;
        }
    }
}