using System.Text.RegularExpressions;
using WMS.Frontend.Models;
using Xceed.Document.NET;
using Xceed.Words.NET;

public class DocumentServiceWindows
{
        public byte[] GenerateDocument(ReceivingSummary receivingSummary)
        {
                using var document = DocX.Create($"{receivingSummary.Series}.docx");
                document.MarginTop = 0; 
                document.MarginLeft = 30;
                document.MarginRight = 30;
                document.MarginBottom = 0;

                 // Create a Header
                document.AddHeaders();
                var header = document.Headers.Odd;
                
                // Create a table for Header alignment
                var HeaderTable =  header.InsertTable(3, 3);
                HeaderTable.AutoFit = AutoFit.Contents; // Adjust to content width
                HeaderTable.Alignment = Alignment.center;
               
                var logoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Skybest.png");
                // Insert the logo if it exists
                if (File.Exists(logoPath))
                {
                        // var logo = document.AddImage(logoPath);
                        // var picture = logo.CreatePicture();

                        // // Set logo dimensions
                        // picture.Width = 50; // Adjust width

                        // // Calculate combined height for the text
                        // var companyNameHeight = 21; // Font size for company name
                        // var addressHeight = 10;      // Font size for address
                        // var lineSpacing = 5;         // Estimated line spacing
                        // var totalHeight = companyNameHeight + addressHeight + lineSpacing; // Total height for the image

                        // picture.Height = totalHeight; // Set height to match combined text height

                        // // Add image to the first cell
                        // HeaderTable.Rows[0].Cells[0].InsertParagraph().AppendPicture(picture).Alignment = Alignment.center;
                }
                else
                {
                        HeaderTable.Rows[0].Cells[0].InsertParagraph("Logo not found.\n"); // Fallback if logo is missing
                }

                // Add company name and address in the second cell
                var textCell = HeaderTable.Rows[0].Cells[1];
                textCell.InsertParagraph("Skybest Logistic Corporation")
                        .Font("Century")
                        .FontSize(21)
                        .Bold()
                        .Alignment = Alignment.center;

                textCell.InsertParagraph("Maclane Storage Facility, Ilaya St. Niog 2 Bacoor, Cavite")
                        .FontSize(10)
                        .Alignment = Alignment.center;

                header.InsertParagraph();

                // Create a table for Title and Series alignment
                var TitleSection = header.InsertTable(1, 3);                
                TitleSection.Rows[0].Cells[1].Paragraphs[0].Append("Receiving Tally")
                        .FontSize(18)
                        .Bold()
                        .Alignment = Alignment.center;

                TitleSection.Rows[0].Cells[2].Paragraphs[0].Append("No: " + receivingSummary.Series)
                        .FontSize(14)
                        .Alignment = Alignment.right;
                
                header.InsertParagraph();
                
                //Create a table for Overview Details 
                var FirstSectionDetails = header.InsertTable(1, 2);
                 // Set table width to full page width
                FirstSectionDetails.SetWidths(new float[] { document.PageWidth * 0.65f, document.PageWidth * 0.35f }); 

                FirstSectionDetails.Rows[0].Cells[0].Paragraphs[0].Append("TRANSPORT CO. :      " + receivingSummary.TransportCompany.ToUpper());
                FirstSectionDetails.Rows[0].Cells[0].InsertParagraph("SHIPPER / EXPORTER:       " + receivingSummary.Shipper.ToUpper());
                FirstSectionDetails.Rows[0].Cells[0].InsertParagraph("CONSIGNEE / IMPORTER:     " + (receivingSummary.Consignee is null ? "" : receivingSummary.Consignee.ToUpper()));
                
                FirstSectionDetails.Rows[0].Cells[1].Paragraphs[0].Append("DATE RECEIVED :      " + receivingSummary.DateReceived.ToShortDateString());
                FirstSectionDetails.Rows[0].Cells[1].InsertParagraph("INV / PO / DR NO.:        ").Append(Regex.Replace(receivingSummary.Reference, @"\r\n?|\n", ", "));
                
                // string[] series = receivingSummary.Series.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                // foreach (var SeperatedSeries in series)
                // {
                //         FirstSectionDetails.Rows[0].Cells[1].InsertParagraph(SeperatedSeries);
                // }
                header.InsertParagraph();                
                
                var consolidatedProducts = receivingSummary.Products
                .GroupBy(p => new
                {
                        p.Name,
                        p.TypeOfPackage,
                        p.ContainerName,
                        p.Measurement,
                        p.ExpirationDate,
                        p.Remarks
                })
                .Select(g => new
                {
                        g.Key.Name,
                        g.Key.TypeOfPackage,
                        g.Key.ContainerName,
                        g.Key.Measurement,
                        Quantity = g.Sum(x => x.Quantity), // Sum quantities
                        // CBM = CalculateCBM(g.Key.Measurement, g.Sum(x => x.Quantity)), // Recompute CBM
                        CBM = g.Sum(x => Convert.ToDecimal(x.CBM)).ToString("N4"), // Recompute CBM
                        // TotalWeight = g.Sum(x => x.Quantity * x.Weight).ToString("N2"), // Recompute total weight
                        TotalWeight = g.Sum(x => Convert.ToDecimal(x.TotalWeight)).ToString("N2"), // Recompute total weight
                        g.Key.ExpirationDate,
                        g.Key.Remarks
                })
                .ToList();
                
                 //Create a table for List of Products
                var products = document.InsertTable(1 + consolidatedProducts.Count, 6);
                 // Set the table column widths
                products.SetWidths(new float[] { 150f, 50f, 80f, 80f, 60f, 120f });
               
                products.Rows[0].Cells[0].Paragraphs[0].Append("DESCRIPTION").Alignment = Alignment.center;
                products.Rows[0].Cells[0].VerticalAlignment = VerticalAlignment.Center;
                products.Rows[0].Cells[1].Paragraphs[0].Append("QTY").Alignment = Alignment.center;
                products.Rows[0].Cells[1].VerticalAlignment = VerticalAlignment.Center;
                products.Rows[0].Cells[2].Paragraphs[0].Append("TYPE OF PACKAGES").Alignment = Alignment.center;
                products.Rows[0].Cells[2].VerticalAlignment = VerticalAlignment.Center;
                products.Rows[0].Cells[3].Paragraphs[0].Append("MEASUREMENT");
                products.Rows[0].Cells[3].VerticalAlignment = VerticalAlignment.Center;
                products.Rows[0].Cells[4].Paragraphs[0].Append("WEIGHT").Alignment = Alignment.center;
                products.Rows[0].Cells[4].VerticalAlignment = VerticalAlignment.Center;
                products.Rows[0].Cells[5].Paragraphs[0].Append("REMARKS").Alignment = Alignment.center;
                products.Rows[0].Cells[5].VerticalAlignment = VerticalAlignment.Center;

                for (int i = 0; i < consolidatedProducts.Count; i++)
                {       
                        int count = 1 + i;
                        products.Rows[count].Cells[0].InsertParagraph(count + ". " + consolidatedProducts[i].Name).Alignment = Alignment.left;
                        products.Rows[count].Cells[0].VerticalAlignment = VerticalAlignment.Center;
                        products.Rows[count].Cells[1].InsertParagraph(consolidatedProducts[i].Quantity.ToString()).Alignment = Alignment.center;
                        products.Rows[count].Cells[1].VerticalAlignment = VerticalAlignment.Center;
                        products.Rows[count].Cells[2].InsertParagraph(consolidatedProducts[i].TypeOfPackage + $"{ (!String.IsNullOrWhiteSpace(consolidatedProducts[i].ContainerName) ? $"{Environment.NewLine}({consolidatedProducts[i].ContainerName})" : "") }").Alignment = Alignment.center;
                        products.Rows[count].Cells[2].VerticalAlignment = VerticalAlignment.Center;
                        products.Rows[count].Cells[3].InsertParagraph(consolidatedProducts[i].CBM).Alignment = Alignment.center;
                        products.Rows[count].Cells[3].VerticalAlignment = VerticalAlignment.Center;
                        products.Rows[count].Cells[4].InsertParagraph(consolidatedProducts[i].TotalWeight).Alignment = Alignment.center;
                        products.Rows[count].Cells[4].VerticalAlignment = VerticalAlignment.Center;
                        products.Rows[count].Cells[5].InsertParagraph(consolidatedProducts[i].Remarks).Alignment = Alignment.center;
                        products.Rows[count].Cells[5].VerticalAlignment = VerticalAlignment.Center;
                }

                 // Create a footer
                document.AddFooters();
                var footer = document.Footers.Odd;
                // Create a table with 1 row and 2 columns
                var SecondSectionDetails = footer.InsertTable(3, 3);
                 // Set table width to full page width
                SecondSectionDetails.SetWidths(new float[] { document.PageWidth * 0.43f,document.PageWidth * 0.13f, document.PageWidth * 0.43f });

                SecondSectionDetails.Rows[0].Cells[0].Paragraphs[0].Append("NOTES / INSTRUCTIONS:").Bold();

                SecondSectionDetails.Rows[1].Cells[0].InsertParagraph()
                .Append(new string('_', Math.Max(0, (30 - receivingSummary.PlateNumber.Length) / 2)))
                .Append(receivingSummary.PlateNumber)
                .UnderlineStyle(UnderlineStyle.singleLine) 
                .Append(new string('_', Math.Max(0, (30 - receivingSummary.PlateNumber.Length) / 2)))
                .Alignment = Alignment.center;

                SecondSectionDetails.Rows[1].Cells[0].InsertParagraph()
                .Append("TRUCK PLATE NO")
                .Alignment = Alignment.center;

                SecondSectionDetails.Rows[1].Cells[0].InsertParagraph("\n")
                .Append(new string('_', Math.Max(0, (30 - receivingSummary.DriverName.Length) / 2)))
                .Append(receivingSummary.DriverName) 
                .UnderlineStyle(UnderlineStyle.singleLine)
                .Append(new string('_', Math.Max(0, (30 - receivingSummary.DriverName.Length) / 2)))
                .Alignment = Alignment.center;

                SecondSectionDetails.Rows[1].Cells[0].InsertParagraph()
                .Append("DRIVER'S NAME") 
                .Alignment = Alignment.center;

                SecondSectionDetails.Rows[1].Cells[0].InsertParagraph("\n")
                .Append(new string('_', Math.Max(0, (30 - (receivingSummary.DateTime.ToShortDateString().Length + receivingSummary.DateTime.ToString("hh:mm tt").Length)) / 2))) 
                .Append(receivingSummary.DateTime.ToShortDateString() + "           " + receivingSummary.DateTime.ToString("hh:mm tt"))
                .UnderlineStyle(UnderlineStyle.singleLine)
                .Append(new string('_', Math.Max(0, (30 - (receivingSummary.DateTime.ToShortDateString().Length + "           ".Length + receivingSummary.DateTime.ToString("hh:mm tt").Length)) / 2))) 
                .Alignment = Alignment.center;

                SecondSectionDetails.Rows[1].Cells[0].InsertParagraph()
                .Append("DATE           TIME") 
                .Alignment = Alignment.center;

                SecondSectionDetails.Rows[1].Cells[2].InsertParagraph()
                .Append(new string('_', Math.Max(0, (30 - (receivingSummary.ClientRepresentative is null ? 0 : receivingSummary.ClientRepresentative.Length)) / 2))) 
                .Append(receivingSummary.ClientRepresentative) 
                .UnderlineStyle(UnderlineStyle.singleLine) 
                .Append(new string('_', Math.Max(0, (30 - (receivingSummary.ClientRepresentative is null ? 0 : receivingSummary.ClientRepresentative.Length)) / 2)))
                .Alignment = Alignment.center;

                SecondSectionDetails.Rows[1].Cells[2].InsertParagraph()
                .Append("CLIENT REPRESENTATIVE")
                .Alignment = Alignment.center;

              
                SecondSectionDetails.Rows[1].Cells[2].InsertParagraph("\n")
                .Append(new string('_', Math.Max(0, (30 - (receivingSummary.CheckerName is null ? 0 : receivingSummary.CheckerName.Length)) / 2))) 
                .Append(receivingSummary.CheckerName)
                .UnderlineStyle(UnderlineStyle.singleLine) 
                .Append(new string('_', Math.Max(0, (30 - (receivingSummary.CheckerName is null ? 0 : receivingSummary.CheckerName.Length)) / 2)))
                .Alignment = Alignment.center;

                SecondSectionDetails.Rows[1].Cells[2].InsertParagraph()
                .Append("CHECKER'S NAME") 
                .Alignment = Alignment.center;

                SecondSectionDetails.Rows[1].Cells[2].InsertParagraph("\n")
                .Append(new string('_', Math.Max(0, (30 - (receivingSummary.TimeStart.ToString("hh:mm tt").Length + receivingSummary.TimeEnd.ToString("hh:mm tt").Length)) / 2)))
                .Append(receivingSummary.TimeStart.ToString("hh:mm tt") + "     " + receivingSummary.TimeEnd.ToString("hh:mm tt")) 
                .UnderlineStyle(UnderlineStyle.singleLine) 
                .Append(new string('_', Math.Max(0, (30 - (receivingSummary.TimeStart.ToString("hh:mm tt").Length + "     ".Length + receivingSummary.TimeEnd.ToString("hh:mm tt").Length)) / 2))) 
                .Alignment = Alignment.center;

                SecondSectionDetails.Rows[1].Cells[2].InsertParagraph()
                .Append("TIME START     TIME END")
                .Alignment = Alignment.center;

                SecondSectionDetails.Rows[2].Cells[2].InsertParagraph("Page ").AppendPageNumber(PageNumberFormat.roman).Alignment = Alignment.right;
                
                // Remove borders from the tables
                var borderTypes = new[] { TableBorderType.InsideH, TableBorderType.InsideV, TableBorderType.Top, TableBorderType.Bottom, TableBorderType.Left, TableBorderType.Right };
                foreach (var borderType in borderTypes)
                {
                        HeaderTable.SetBorder(borderType, new Border(BorderStyle.Tcbs_none, 0, 0, System.Drawing.Color.Transparent));
                        TitleSection.SetBorder(borderType, new Border(BorderStyle.Tcbs_none, 0, 0, System.Drawing.Color.Transparent));
                        FirstSectionDetails.SetBorder(borderType, new Border(BorderStyle.Tcbs_none, 0, 0, System.Drawing.Color.Transparent));
                        SecondSectionDetails.SetBorder(borderType, new Border(BorderStyle.Tcbs_none, 0, 0, System.Drawing.Color.Transparent));
                }

                // Save to a memory stream
                using var stream = new MemoryStream();
                document.SaveAs(stream);
                return stream.ToArray();
        }

        private static string CalculateCBM(string? measurement, int quantity)
        {
                if (string.IsNullOrWhiteSpace(measurement))
                        return "0.00";

                var measurements = measurement.Replace(" ", "").Split("X");
                decimal dimension = 1;

                foreach (var item in measurements)
                {
                        if (decimal.TryParse(item, out decimal value))
                        {
                        dimension *= value;
                        }
                }

                return ((dimension * quantity) / 1000000).ToString("N2");
        }
}