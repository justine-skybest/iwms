// using NPOI.XWPF.UserModel;
// using NPOI.WP.UserModel;
// using System.Text.RegularExpressions;
// using WMS.Frontend.Models;

// public class DocumentServiceNPOI
// {
//     public byte[] GenerateDocument(ReceivingSummary receivingSummary)
//     {
//         // Create a new XWPFDocument (Word .docx format)
//         using var document = new XWPFDocument();

//         // --- HEADER ---
//         // Create a header
//         XWPFHeader header = document.CreateHeader(HeaderFooterType.DEFAULT);
//         XWPFParagraph headerParagraph = header.CreateParagraph();
//         headerParagraph.Alignment = ParagraphAlignment.CENTER;

//         // Create a table for Header alignment
//         XWPFTable headerTable = header.CreateTable(3, 3);
//         // headerTable.AutoFit = true;
//         // headerTable.Alignment = ParagraphAlignment.CENTER;

//         // Insert logo (if exists)
//         string logoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "img.png");
//         if (File.Exists(logoPath))
//         {
//             XWPFPictureData logo = document.AddPictureData(File.ReadAllBytes(logoPath), XWPFDocument.PICTURE_TYPE_PNG);
//             XWPFRun pictureRun = headerTable.GetRow(0).GetCell(0).AddParagraph().CreateRun();
//             pictureRun.AddPicture(new MemoryStream(logo.GetData()), (int)XWPFDocument.PICTURE_TYPE_PNG, "img.png", 50, 50);
//         }
//         else
//         {
//             headerTable.GetRow(0).GetCell(0).SetText("Logo not found.");
//         }

//         // Add company name and address in the second cell
//         headerTable.GetRow(0).GetCell(1).SetText("Company Name\nCompany Address");

//         // Title and series
//         headerTable.GetRow(1).GetCell(1).SetText("Receiving Tally");
//         headerTable.GetRow(1).GetCell(2).SetText("No: " + receivingSummary.Series);

//         // --- BODY CONTENT ---
//         // First section details (Transport company, Shipper, Consignee)
//         XWPFTable firstSectionTable = document.CreateTable(1, 2);
//         firstSectionTable.GetRow(0).GetCell(0).SetText($"TRANSPORT CO. : {receivingSummary.TransportCompany.ToUpper()}\nSHIPPER / EXPORTER: {receivingSummary.Shipper.ToUpper()}\nCONSIGNEE / IMPORTER: {receivingSummary.Consignee?.ToUpper() ?? ""}");
//         firstSectionTable.GetRow(0).GetCell(1).SetText($"DATE RECEIVED: {receivingSummary.DateReceived.ToShortDateString()}\nINV / PO / DR NO.: {Regex.Replace(receivingSummary.Reference, @"\r\n?|\n", ", ")}");

//         // List of products table
//         XWPFTable productsTable = document.CreateTable(receivingSummary.Products.Count + 1, 6);
//         string[] headers = { "DESCRIPTION", "QTY", "TYPE OF PACKAGES", "MEASUREMENT", "WEIGHT", "REMARKS" };
//         for (int i = 0; i < headers.Length; i++)
//         {
//             productsTable.GetRow(0).GetCell(i).SetText(headers[i]);
//         }

//         // Insert product rows
//         for (int i = 0; i < receivingSummary.Products.Count; i++)
//         {
//             var product = receivingSummary.Products[i];
//             productsTable.GetRow(i + 1).GetCell(0).SetText($"{i + 1}. {product.Name}");
//             productsTable.GetRow(i + 1).GetCell(1).SetText(product.Quantity.ToString());
//             productsTable.GetRow(i + 1).GetCell(2).SetText(product.TypeOfPackage);
//             productsTable.GetRow(i + 1).GetCell(3).SetText(product.CBM);
//             productsTable.GetRow(i + 1).GetCell(4).SetText(product.TotalWeight.ToString());
//             productsTable.GetRow(i + 1).GetCell(5).SetText(product.Remarks);
//         }

//         // --- FOOTER ---
//         // Create a footer
//         XWPFFooter footer = document.CreateFooter(HeaderFooterType.DEFAULT);
//         XWPFTable footerTable = footer.CreateTable(3, 3);

//         // Set notes section in the footer
//         footerTable.GetRow(0).GetCell(0).SetText("NOTES / INSTRUCTIONS:");
//         footerTable.GetRow(1).GetCell(0).SetText($"Truck Plate No: {receivingSummary.PlateNumber}");
//         footerTable.GetRow(1).GetCell(1).SetText($"Driver: {receivingSummary.DriverName}");
//         footerTable.GetRow(1).GetCell(2).SetText($"Date: {receivingSummary.DateTime.ToShortDateString()} Time: {receivingSummary.DateTime.ToShortTimeString()}");

//         // Client representative and checker's name
//         footerTable.GetRow(2).GetCell(0).SetText($"Client Rep: {receivingSummary.ClientRepresentative}");
//         footerTable.GetRow(2).GetCell(2).SetText($"Checker: {receivingSummary.CheckerName}");

//         // Page number
//         footerTable.GetRow(2).GetCell(2).SetText($"Page {receivingSummary.Series}");


//         // --- Save Document to MemoryStream ---
//         using var stream = new MemoryStream();
//         document.Write(stream);
//         return stream.ToArray();
//     }
// }
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.WP.UserModel;
using NPOI.XWPF.UserModel;
using WMS.Frontend.Models;

public class DocumentServiceNPOI
{
    public byte[] GenerateDocument(ReceivingSummary receivingSummary)
    {
        // Create a new blank document
        XWPFDocument document = new XWPFDocument();
        
        // Add header, body, and footer to the document
        AddHeader(document, receivingSummary);
        AddBody(document, receivingSummary);
        AddFooter(document, receivingSummary);
        
        // Save the document to a memory stream and return the byte array
        using (var memoryStream = new MemoryStream())
        {
            document.Write(memoryStream);
            return memoryStream.ToArray();
        }
    }

     // Function to add the header to the document
    // Function to add header content to the document
    private void AddHeader(XWPFDocument document, ReceivingSummary receivingSummary)
    {
        // Create the header section
        XWPFHeader header = document.CreateHeader(HeaderFooterType.DEFAULT);        

        // Create a table with 3 columns and 1 row in the header
        XWPFTable table = header.CreateTable(1, 3);  // 1 row, 3 columns

        // Get the first row of the table (XWPFTableRow)
        XWPFTableRow row = table.GetRow(0);
        
        // Set the width of each column to span the page width
        SetTableColumnWidth(table);

        // First cell (Column 1)
        XWPFTableCell cell1 = row.GetCell(0);
        cell1.SetText("Company Name or Logo");  // Add text or image to this cell

        // Second cell (Column 2)
        XWPFTableCell cell2 = row.GetCell(1);
        cell2.SetText("Receiving Summary Report");  // Report title

        // Third cell (Column 3)
        XWPFTableCell cell3 = row.GetCell(2);
        cell3.SetText($"Generated on: {DateTime.Now:MM/dd/yyyy}");  // Add date or other dynamic info

        // Apply styling to the cells (optional)
        StyleTableCells(cell1, cell2, cell3);

        // // Create a header section (this will be applied to the first page)
        // XWPFHeader header = document.CreateHeader(HeaderFooterType.DEFAULT);

        // // Create a paragraph in the header
        // XWPFParagraph headerParagraph = header.CreateParagraph();
        // headerParagraph.Alignment = NPOI.XWPF.UserModel.ParagraphAlignment.CENTER;
        
        // // Add header text
        // XWPFRun headerRun = headerParagraph.CreateRun();
        // headerRun.SetText("Receiving Summary Report");  // Use SetText to modify text
        // headerRun.FontSize = 14;
        // headerRun.IsBold = true;  // Make the header text bold
    }

    // Method to set column widths to span the page width
    private void SetTableColumnWidth(XWPFTable table)
    {
        // Default page width in twips (8.5 inches * 1440 twips per inch)
        int pageWidthInTwips = 12240;  // 8.5 inches * 1440 twips per inch

        // Calculate column widths to span the full page width
        int column1Width = pageWidthInTwips / 4;  // 1/4 of the page width
        int column2Width = pageWidthInTwips / 2;  // 1/2 of the page width
        int column3Width = pageWidthInTwips / 4;  // 1/4 of the page width

        // Set the table width to span the full page width
        CT_TblWidth tableWidth = new CT_TblWidth();
        tableWidth.type = ST_TblWidth.dxa;
        tableWidth.w = pageWidthInTwips.ToString(); // Set the table width to the page width

        // Access the table properties (CT_TblPr) and set the table width
        CT_TblPr tblPr = table.GetCTTbl().AddNewTblPr();  // Add new table properties
        tblPr.AddNewTblW().w = tableWidth.w;
        tblPr.AddNewTblW().type = tableWidth.type;

        // Set the width and padding for each column dynamically
        for (int i = 0; i < table.Rows.Count; i++)  // Iterate through each row
        {
            XWPFTableRow row = table.GetRow(i);

            // Set the width and padding of each cell based on its column
            for (int j = 0; j < row.GetTableCells().Count; j++)
            {
                XWPFTableCell cell = row.GetCell(j);

                // Create CTTblWidth and set width in twips
                CT_TblWidth tblWidth = new CT_TblWidth();
                tblWidth.type = ST_TblWidth.dxa;
                tblWidth.w = (j == 0 ? column1Width : j == 1 ? column2Width : column3Width).ToString();

                CT_TcPr tcPr = cell.GetCTTc().AddNewTcPr();  // Add new table properties for the cell

                // Add a new TblWidth and set it
                var cellTblWidth = tcPr.AddNewTcW(); // Add new TblWidth element to cell's TcPr
                cellTblWidth.w = tblWidth.w;
                cellTblWidth.type = tblWidth.type;
            }
        }
    }

    // Optional method to style the cells (e.g., bold text, font size, etc.)
    private void StyleTableCells(XWPFTableCell cell1, XWPFTableCell cell2, XWPFTableCell cell3)
    {
        // Style cell 1
        XWPFRun run1 = cell1.GetParagraphArray(0).CreateRun();
        run1.SetText("Company Name or Logo");
        run1.IsBold = true;
        run1.FontSize = 14;

        // Style cell 2 (title)
        XWPFRun run2 = cell2.GetParagraphArray(0).CreateRun();
        run2.SetText("Receiving Summary Report");
        run2.IsBold = true;
        run2.FontSize = 16;

        // Style cell 3 (date or dynamic info)
        XWPFRun run3 = cell3.GetParagraphArray(0).CreateRun();
        run3.SetText($"Generated on: {DateTime.Now:MM/dd/yyyy}");
        run3.FontSize = 12;
    }

    // Function to add the body to the document
     // Function to add body content to the document
    private void AddBody(XWPFDocument document, ReceivingSummary receivingSummary)
    {
        // // Create a body paragraph for the document
        // XWPFParagraph bodyParagraph = document.CreateParagraph();
        // bodyParagraph.Alignment = NPOI.XWPF.UserModel.ParagraphAlignment.LEFT;

        // // Add main body text (using properties from ReceivingSummary)
        // XWPFRun bodyRun = bodyParagraph.CreateRun();
        // bodyRun.SetText($"Receiving Number: {receivingSummary.ReceivingNumber}\n\n");  // Use SetText
        // bodyRun.FontSize = 12;

        // // Add additional summary details
        // XWPFParagraph detailsParagraph = document.CreateParagraph();
        // detailsParagraph.Alignment = NPOI.XWPF.UserModel.ParagraphAlignment.LEFT;
        
        // XWPFRun detailsRun = detailsParagraph.CreateRun();
        // detailsRun.SetText($"Date: {receivingSummary.Date:MM/dd/yyyy}\n" +
        //                    $"Total Items Received: {receivingSummary.TotalItemsReceived}\n" +
        //                    $"Vendor: {receivingSummary.VendorName}\n");  // Use SetText
        // detailsRun.FontSize = 12;
    }

    // Function to add the footer to the document
    private void AddFooter(XWPFDocument document, ReceivingSummary receivingSummary)
    {
        // // Create a footer section
        // XWPFFooter footer = document.CreateFooter(HeaderFooterType.DEFAULT);

        // // Add a paragraph to the footer
        // XWPFParagraph footerParagraph = footer.CreateParagraph();
        // footerParagraph.Alignment = NPOI.XWPF.UserModel.ParagraphAlignment.CENTER;

        // // Add text to the footer paragraph
        // XWPFRun footerRun = footerParagraph.CreateRun();
        // footerRun.SetText($"Page generated on: {System.DateTime.Now:MM/dd/yyyy HH:mm}");  // Use SetText
        // footerRun.FontSize = 10;
    }
}
    