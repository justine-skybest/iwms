using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using WMS.Frontend.Models;

public class DocumentServiceUbuntu
{
    public byte[] GenerateDocument(ReceivingSummary receivingSummary)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            // Create the WordprocessingDocument (using DocumentType.Document for a standard .docx file)
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(memoryStream, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                // Add the main document part
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                // Ensure the document and body are initialized
                mainPart.Document = new Document();
                if (mainPart.Document.Body == null)
                {
                    mainPart.Document.Body = new Body();  // Initialize Body if it's null
                }

                // Add header and footer parts
                AddHeader(mainPart);
                AddFooter(mainPart);

                // Add content to the body
                AddDocumentContent(mainPart, receivingSummary);

                // Save the document to the main part
                mainPart.Document.Save();
            }

            // Return the document as a byte array
            return memoryStream.ToArray();
        }
    }

    private void AddHeader(MainDocumentPart mainPart)
    {
        // Create header part
        HeaderPart headerPart = mainPart.AddNewPart<HeaderPart>();
        headerPart.Header = new Header(new Paragraph(new Run(new Text("This is the header"))));

        // 1. Header Section: Table with 3 columns and 1 row
        Table headerTable = new Table();

        // Set table width to span the document
        TableProperties tblProperties = new TableProperties(
                new TableWidth() { Type = TableWidthUnitValues.Auto }
        );
        headerTable.AppendChild(tblProperties);

        // Create the row for the header
        TableRow headerRow = new TableRow();

        // Column 0: Insert image (Logo)
        TableCell cell0 = new TableCell(new Paragraph(new Run(new Text("Logo")))); // Placeholder text for now

        // Insert image into Column 0
        string logoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Skybest.png");
        if (File.Exists(logoPath))
        {
            // Add image to the document part
            ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Png);
            using (FileStream fs = new FileStream(logoPath, FileMode.Open))
            {
                imagePart.FeedData(fs);
            }

            // Create a reference to the image in the document
            string relationshipId = mainPart.GetIdOfPart(imagePart);

            // Create a paragraph and add the image
            Run run = new Run();
            run.Append(
                new Drawing(
                    new DocumentFormat.OpenXml.Drawing.Wordprocessing.Inline(
                        new DocumentFormat.OpenXml.Drawing.Wordprocessing.Extent() { Cx = 990000L, Cy = 792000L }, // Image size in EMUs (1 inch = 914400 EMUs)
                        new DocumentFormat.OpenXml.Drawing.Wordprocessing.EffectExtent() { LeftEdge = 0, TopEdge = 0, RightEdge = 0, BottomEdge = 0 },
                        new DocumentFormat.OpenXml.Drawing.Wordprocessing.DocProperties() { Id = 1U, Name = "Picture" },
                        new DocumentFormat.OpenXml.Drawing.Wordprocessing.NonVisualGraphicFrameDrawingProperties(
                            new DocumentFormat.OpenXml.Drawing.GraphicFrameLocks() { NoChangeAspect = true }
                        ),
                        new DocumentFormat.OpenXml.Drawing.Graphic(
                            new DocumentFormat.OpenXml.Drawing.GraphicData(
                                new DocumentFormat.OpenXml.Drawing.Pictures.Picture(
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(
                                        new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties() { Id = 0U, Name = "Skybest" }),
                                    new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill(
                                        new DocumentFormat.OpenXml.Drawing.Blip() { Embed = relationshipId }),
                                    new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties()
                                )
                            )
                        )
                    )
                )
            );

            // Add the image to a paragraph in the body
            Paragraph paragraph = new Paragraph(new Run(run));
            cell0.AppendChild(paragraph);
        }

        // Column 1: Company Name and Address
        TableCell cell1 = new TableCell();
        Paragraph companyInfo = new Paragraph(
            new Run(new Text("Skybest Ltd"))
            {
                RunProperties = new RunProperties(new Bold())
            }
        );
        companyInfo.AppendChild(new Paragraph(new Run(new Text("1234 Business Ave, City, Country"))));

        // Center the content in Column 1
        cell1.AppendChild(companyInfo);
        cell1.TableCellProperties = new TableCellProperties(new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center });

        // Column 2: Empty
        TableCell cell2 = new TableCell();  
        cell2.Append(new Paragraph()); 
        cell2.TableCellProperties = new TableCellProperties(new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center });

        // Add the row to the table
        headerRow.Append(cell0, cell1, cell2);
        headerTable.Append(headerRow);
        headerPart.Header.Append(headerTable);

        // Add a paragraph in the Body for Header content
        mainPart.Document.Body!.AppendChild(new Paragraph(new Run(new Text("Header Content"))));

        // Associate the header with the document
        SectionProperties sectionProperties = mainPart.Document.Body.Elements<SectionProperties>().FirstOrDefault() 
            ?? new SectionProperties();

        // Add a HeaderReference to the SectionProperties
        sectionProperties.AppendChild(new HeaderReference() 
        {
            Type = HeaderFooterValues.Default,
            Id = mainPart.GetIdOfPart(headerPart)
        });

        // Append SectionProperties if not already present
        if (!mainPart.Document.Body.Elements<SectionProperties>().Any())
        {
            mainPart.Document.Body.Append(sectionProperties);
        }
    }

    private void AddDocumentContent(MainDocumentPart mainPart, ReceivingSummary receivingSummary)
    {
        // Ensure Body is initialized
        Body body = mainPart.Document.Body!;
        
        // Example body content
        body.AppendChild(new Paragraph(new Run(new Text("This is the body content of the document."))));

        // Loop through receivingSummary to add dynamic content
        foreach (var item in receivingSummary.Products)
        {
            body.AppendChild(new Paragraph(new Run(new Text(item.Remarks))));
        }
    }

    private void AddFooter(MainDocumentPart mainPart)
    {
        // Create footer part
        FooterPart footerPart = mainPart.AddNewPart<FooterPart>();
        footerPart.Footer = new Footer(new Paragraph(new Run(new Text("This is the footer"))));

        // Associate the footer with the document
        SectionProperties sectionProperties = mainPart.Document.Body!.Elements<SectionProperties>().FirstOrDefault() 
            ?? new SectionProperties();

        // Add a FooterReference to the SectionProperties
        sectionProperties.AppendChild(new FooterReference() 
        {
            Type = HeaderFooterValues.Default,
            Id = mainPart.GetIdOfPart(footerPart)
        });

        // Append SectionProperties if not already present
        if (!mainPart.Document.Body.Elements<SectionProperties>().Any())
        {
            mainPart.Document.Body.Append(sectionProperties);
        }
    }
}
