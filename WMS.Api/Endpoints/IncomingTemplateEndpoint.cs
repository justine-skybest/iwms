using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;

namespace WMS.Api.Endpoints
{
    public static class IncomingTemplateEndpoint
    {
        public static RouteGroupBuilder MapIncomingTemplateEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("incoming-template")
                .WithTags("IncomingImportTemplate")
                .WithParameterValidation();

            // GET: Download Standardized Excel Template
            group.MapGet("/template", () =>
            {
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Packing List");

                // --- 1. Company Header Area ---
                worksheet.Cell("A1").Value = "GLOBAL LOGISTICS & WAREHOUSING SYSTEMS";
                worksheet.Cell("A2").Value = "STANDARD INCOMING PACKING LIST TEMPLATE";
                worksheet.Cell("A1").Style.Font.SetBold().Font.SetFontSize(12);
                worksheet.Cell("A2").Style.Font.SetItalic().Font.SetFontSize(10);

                // --- 2. Fixed Metadata Cells (Targeted by Parser) ---
                // Cell A4 (Row 4): Shipper Name
                worksheet.Cell("A4").Value = "SHIPPER: SAMPLE EXPORT SUPPLIER CORP.";
                worksheet.Cell("A4").Style.Font.SetBold();

                // Cell A6 (Row 6): Consignee Name
                worksheet.Cell("A6").Value = "CONSIGNEE: SAMPLE IMPORTING DISTRIBUTOR INC.";
                worksheet.Cell("A6").Style.Font.SetBold();

                worksheet.Cell("A8").Value = "DESTINATION: MAIN DISTRIBUTION CENTER";
                worksheet.Cell("A10").Value = "1X20FT CONTAINER - GENERAL MERCHANDISE";
                worksheet.Cell("A10").Style.Font.SetBold();

                // --- 3. Table Header Row (Row 12) - 14 Columns ---
                string[] headers = new string[]
                {
                    "LN#", "QTY", "PROD. CODE", "UOM", "PRODUCT DESCRIPTION",
                    "UNIT PRICE", "TOTAL AMOUNT", "EXPIRY", "CBM", "TOTAL CBM",
                    "WGT", "TOTAL WGT", "SUPPLIER", "Remarks"
                };

                for (int col = 0; col < headers.Length; col++)
                {
                    var cell = worksheet.Cell(12, col + 1);
                    cell.Value = headers[col];
                    cell.Style.Font.SetBold();
                    cell.Style.Font.SetFontColor(XLColor.White);
                    cell.Style.Fill.SetBackgroundColor(XLColor.FromHtml("#002060")); // Dark navy header
                    cell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                }

                // --- 4. Supplier Banner Row (Row 13) ---
                worksheet.Cell("A13").Value = "PRIMARY SUPPLIER A";
                worksheet.Range("A13:N13").Style.Font.SetBold();
                worksheet.Range("A13:N13").Style.Font.SetFontColor(XLColor.White);
                worksheet.Range("A13:N13").Style.Fill.SetBackgroundColor(XLColor.FromHtml("#1F4E78"));

                // --- 5. Generic Line Item Sample Data (Rows 14 & 15) ---
                // Item 1
                worksheet.Cell("A14").Value = 1;                                      // LN#
                worksheet.Cell("B14").Value = 50;                                     // QTY
                worksheet.Cell("C14").Value = "PRD-10001";                            // PROD. CODE
                worksheet.Cell("D14").Value = "CASE";                                 // UOM
                worksheet.Cell("E14").Value = "SAMPLE GENERAL MERCHANDISE ITEM A";    // PRODUCT DESCRIPTION
                worksheet.Cell("F14").Value = 150.00;                                 // UNIT PRICE
                worksheet.Cell("G14").Value = 7500.00;                                // TOTAL AMOUNT
                worksheet.Cell("H14").Value = "2027-12-31";                           // EXPIRY
                worksheet.Cell("I14").Value = 0.02;                                   // CBM
                worksheet.Cell("J14").Value = 1.00;                                   // TOTAL CBM
                worksheet.Cell("K14").Value = 12.50;                                  // WGT
                worksheet.Cell("L14").Value = 625.00;                                 // TOTAL WGT
                worksheet.Cell("M14").Value = "SUPPLIER A";                           // SUPPLIER
                worksheet.Cell("N14").Value = "Handle with care";                     // Remarks

                // Item 2
                worksheet.Cell("A15").Value = 2;                                      // LN#
                worksheet.Cell("B15").Value = 100;                                    // QTY
                worksheet.Cell("C15").Value = "PRD-10002";                            // PROD. CODE
                worksheet.Cell("D15").Value = "BOX";                                  // UOM
                worksheet.Cell("E15").Value = "SAMPLE GENERAL MERCHANDISE ITEM B";    // PRODUCT DESCRIPTION
                worksheet.Cell("F15").Value = 250.00;                                 // UNIT PRICE
                worksheet.Cell("G15").Value = 25000.00;                               // TOTAL AMOUNT
                worksheet.Cell("H15").Value = "2028-06-30";                           // EXPIRY
                worksheet.Cell("I15").Value = 0.015;                                  // CBM
                worksheet.Cell("J15").Value = 1.50;                                   // TOTAL CBM
                worksheet.Cell("K15").Value = 10.00;                                  // WGT
                worksheet.Cell("L15").Value = 1000.00;                                // TOTAL WGT
                worksheet.Cell("M15").Value = "SUPPLIER A";                           // SUPPLIER
                worksheet.Cell("N15").Value = "Keep dry";                             // Remarks

                // Auto-fit columns for clean presentation
                worksheet.Columns().AdjustToContents();

                // Stream response file directly to download
                using var stream = new MemoryStream();
                workbook.SaveAs(stream);
                var content = stream.ToArray();

                return Results.File(
                    content,
                    contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileDownloadName: "Incoming_Packing_List_Template.xlsx"
                );
            })
            .WithName("DownloadIncomingTemplate")
            .Produces(StatusCodes.Status200OK, contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

            return group;
        }
    }
}