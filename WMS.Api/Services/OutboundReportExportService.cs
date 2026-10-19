using ClosedXML.Excel;
using CsvHelper;
using System.Globalization;

namespace WMS.Api.Services
{
    public class OutboundReportExportService : IOutboundReportExportService
    {
        public byte[] GenerateDispatchManifestExcel(IEnumerable<dynamic> data)
        {
            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Dispatch Manifest");

            // Title Block
            ws.Cell("A1").Value = "OUTBOUND DISPATCH MANIFEST REPORT";
            ws.Cell("A1").Style.Font.Bold = true;
            ws.Cell("A1").Style.Font.FontSize = 14;
            ws.Cell("A2").Value = $"Generated: {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC";
            ws.Cell("A2").Style.Font.Italic = true;

            // Table Headers
            var headers = new[]
            {
            "Loading Ref", "Status", "Warehouse", "Carrier Vehicle", "Container",
            "Seal #", "Destination", "Consignee", "Planned Qty", "Loaded Qty",
            "Fulfillment %", "Dispatched At", "Supervisor", "Loader"
        };

            for (int i = 0; i < headers.Length; i++)
            {
                var cell = ws.Cell(4, i + 1);
                cell.Value = headers[i];
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.FromArgb(30, 58, 138); // Dark Navy
                cell.Style.Font.FontColor = XLColor.White;
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }

            // Data Rows
            int row = 5;
            foreach (var item in data)
            {
                ws.Cell(row, 1).Value = (string)item.LoadingReference;
                ws.Cell(row, 2).Value = (string)item.Status;
                ws.Cell(row, 3).Value = (string)item.WarehouseName;
                ws.Cell(row, 4).Value = (string)item.Transport.VehiclePlateNumber ?? "N/A";
                ws.Cell(row, 5).Value = (string)item.Transport.ContainerNumber ?? "N/A";
                ws.Cell(row, 6).Value = (string)item.Transport.SealNumber ?? "N/A";
                ws.Cell(row, 7).Value = (string)item.Destination ?? "N/A";
                ws.Cell(row, 8).Value = (string)item.ConsigneeName ?? "N/A";
                ws.Cell(row, 9).Value = (int)item.TotalQuantityPlanned;
                ws.Cell(row, 10).Value = (int)item.TotalQuantityLoaded;

                var fillCell = ws.Cell(row, 11);
                fillCell.Value = (double)item.FulfillmentRatePercentage / 100;
                fillCell.Style.NumberFormat.Format = "0.0%";

                ws.Cell(row, 12).Value = item.Timestamps.CompletedAt != null
                    ? ((DateTime)item.Timestamps.CompletedAt).ToString("yyyy-MM-dd HH:mm")
                    : "Pending";
                ws.Cell(row, 13).Value = item.Personnel.SupervisorUserId?.ToString() ?? "N/A";
                ws.Cell(row, 14).Value = item.Personnel.LoaderUserId?.ToString() ?? "N/A";

                // Subtle zebra striping
                if (row % 2 == 0)
                {
                    ws.Range(row, 1, row, headers.Length).Style.Fill.BackgroundColor = XLColor.FromArgb(248, 250, 252);
                }

                row++;
            }

            // Formatting
            ws.Columns().AdjustToContents();
            ws.Range(4, 1, row - 1, headers.Length).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            ws.Range(4, 1, row - 1, headers.Length).Style.Border.InsideBorder = XLBorderStyleValues.Hair;

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        public byte[] GenerateTurnaroundExcel(IEnumerable<dynamic> data)
        {
            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Turnaround & Throughput");

            var headers = new[]
            {
            "Loading Ref", "Plate #", "Container #", "Scheduled", "Planned Start",
            "Actual Start", "Completed At", "Start Delay (min)", "Turnaround (min)",
            "Units Loaded", "Pallets Handled", "Throughput (Units/Hr)"
        };

            for (int i = 0; i < headers.Length; i++)
            {
                var cell = ws.Cell(1, i + 1);
                cell.Value = headers[i];
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.FromArgb(15, 118, 110); // Teal
                cell.Style.Font.FontColor = XLColor.White;
            }

            int row = 2;
            foreach (var item in data)
            {
                ws.Cell(row, 1).Value = (string)item.LoadingReference;
                ws.Cell(row, 2).Value = (string)item.VehiclePlateNumber ?? "N/A";
                ws.Cell(row, 3).Value = (string)item.ContainerNumber ?? "N/A";
                ws.Cell(row, 4).Value = item.ScheduledDate?.ToString("yyyy-MM-dd") ?? "N/A";
                ws.Cell(row, 5).Value = item.PlannedStartAt?.ToString("yyyy-MM-dd HH:mm") ?? "N/A";
                ws.Cell(row, 6).Value = item.ActualStartAt?.ToString("yyyy-MM-dd HH:mm") ?? "N/A";
                ws.Cell(row, 7).Value = item.CompletedAt?.ToString("yyyy-MM-dd HH:mm") ?? "N/A";
                ws.Cell(row, 8).Value = item.StartDelayMinutes ?? 0;
                ws.Cell(row, 9).Value = (double)item.NetTurnaroundMinutes;
                ws.Cell(row, 10).Value = (int)item.TotalUnitsLoaded;
                ws.Cell(row, 11).Value = (int)item.TotalPalletsCount;
                ws.Cell(row, 12).Value = (double)item.UnitsPerHour;

                row++;
            }

            ws.Columns().AdjustToContents();
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        public byte[] GenerateGenericCsv<T>(IEnumerable<T> records)
        {
            using var memoryStream = new MemoryStream();
            using var writer = new StreamWriter(memoryStream);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(records);
            writer.Flush();
            return memoryStream.ToArray();
        }
    }
}
