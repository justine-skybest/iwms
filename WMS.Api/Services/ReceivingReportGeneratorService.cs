using ClosedXML.Excel;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.IO;
using System.Text;
using WMS.Api.Data;
using WMS.Api.Dtos.Reporting;
using WMS.Api.Entities;
using WMS.Api.Entities.Reporting;

namespace WMS.Api.Services;

public interface IReceivingReportGeneratorService
{
    Task<string> GenerateReportFileAsync(GenerateReceivingReportRequest request, string jobNumber, CancellationToken ct);
}

public class ReceivingReportGeneratorService : IReceivingReportGeneratorService
{
    private readonly WMSContext _dbContext;

    public ReceivingReportGeneratorService(WMSContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> GenerateReportFileAsync(GenerateReceivingReportRequest request, string jobNumber, CancellationToken ct)
    {
        string reportsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "Receiving");
        if (!Directory.Exists(reportsDirectory)) Directory.CreateDirectory(reportsDirectory);

        string extension = request.Format switch
        {
            ReportFormat.Excel => "xlsx",
            ReportFormat.Csv => "csv",
            ReportFormat.Pdf => "pdf",
            _ => "xlsx"
        };

        string fileName = $"{jobNumber}.{extension}";
        string fullPath = Path.Combine(reportsDirectory, fileName);

        switch (request.SubType)
        {
            case ReceivingReportSubType.PerPalletPerPackingList:
                await GenerateReport1Async(request, fullPath, ct);
                break;
            case ReceivingReportSubType.PerPlateNumberPerPackingList:
                await GenerateReport2Async(request, fullPath, ct);
                break;
            case ReceivingReportSubType.ReceivedVsRemaining:
                await GenerateReport3Async(request, fullPath, ct);
                break;
            case ReceivingReportSubType.DailyPerPackingList:
                await GenerateReport4Async(request, fullPath, ct);
                break;
        }

        return Path.Combine("Reports", "Receiving", fileName);
    }

    #region 1. Receiving Report per Pallet per Packing List
    private async Task GenerateReport1Async(GenerateReceivingReportRequest request, string filePath, CancellationToken ct)
    {
        var query = _dbContext.Receivings
            .Include(r => r.Incoming)
            .Include(r => r.Products)
                .ThenInclude(p => p.Product)
            .AsNoTracking()
            .AsQueryable();

        if (request.StartDate.HasValue) query = query.Where(r => r.DateReceived >= request.StartDate.Value);
        if (request.EndDate.HasValue) query = query.Where(r => r.DateReceived <= request.EndDate.Value);
        if (request.IncomingId.HasValue) query = query.Where(r => r.IncomingId == request.IncomingId.Value);
        if (!string.IsNullOrWhiteSpace(request.PackingListNumber)) query = query.Where(r => r.Reference.Contains(request.PackingListNumber));
        if (!string.IsNullOrWhiteSpace(request.PlateNumber)) query = query.Where(r => r.PlateNumber.Contains(request.PlateNumber));

        var rows = await query
            .SelectMany(r => r.Products!, (r, p) => new
            {
                PackingList = r.Reference,
                PalletNumber = p.PalletId.HasValue ? $"PAL-{p.PalletId.Value}" : "UNASSIGNED",
                ItemCode = p.Product != null ? p.Product.Code : "N/A",
                ItemDescription = p.Product != null ? p.Product.Name : (p.ExpectedProductName ?? "N/A"),
                Quantity = p.Quantity,
                UOM = p.TypeOfPackage ?? "CS",
                CBM = p.CBM ?? 0m,
                Weight = (p.Weight ?? 0m) * p.Quantity,
                PlateNumber = r.PlateNumber,
                ReceivingDate = r.DateReceived.ToString("yyyy-MM-dd"),
                Status = r.Incoming != null ? r.Incoming.Status.ToString() : "RECEIVED"
            })
            .OrderBy(x => x.PackingList)
            .ThenBy(x => x.PalletNumber)
            .ToListAsync(ct);

        if (request.Format == ReportFormat.Csv)
        {
            await ExportCsvAsync(filePath, rows);
            return;
        }

        using var workbook = new XLWorkbook();
        var ws = workbook.Worksheets.Add("Per Pallet Report");

        string[] headers = { "Packing List", "Pallet Number", "Item Code", "Item Description", "Quantity", "UOM", "CBM", "Weight (KG)", "Plate Number", "Receiving Date", "Status" };
        for (int i = 0; i < headers.Length; i++) ws.Cell(1, i + 1).Value = headers[i];
        ws.Row(1).Style.Font.Bold = true;
        ws.Row(1).Style.Fill.BackgroundColor = XLColor.FromHtml("#1E293B");
        ws.Row(1).Style.Font.FontColor = XLColor.White;

        int rowIdx = 2;
        foreach (var r in rows)
        {
            ws.Cell(rowIdx, 1).Value = r.PackingList;
            ws.Cell(rowIdx, 2).Value = r.PalletNumber;
            ws.Cell(rowIdx, 3).Value = r.ItemCode;
            ws.Cell(rowIdx, 4).Value = r.ItemDescription;
            ws.Cell(rowIdx, 5).Value = r.Quantity;
            ws.Cell(rowIdx, 6).Value = r.UOM;
            ws.Cell(rowIdx, 7).Value = r.CBM;
            ws.Cell(rowIdx, 8).Value = r.Weight;
            ws.Cell(rowIdx, 9).Value = r.PlateNumber;
            ws.Cell(rowIdx, 10).Value = r.ReceivingDate;
            ws.Cell(rowIdx, 11).Value = r.Status;
            rowIdx++;
        }
        ws.Columns().AdjustToContents();
        workbook.SaveAs(filePath);
    }
    #endregion

    #region 2. Receiving Report per Plate Number per Packing List
    private async Task GenerateReport2Async(GenerateReceivingReportRequest request, string filePath, CancellationToken ct)
    {
        var query = _dbContext.Receivings
            .Include(r => r.Incoming)
            .Include(r => r.Products)
            .AsNoTracking()
            .AsQueryable();

        if (request.StartDate.HasValue) query = query.Where(r => r.DateReceived >= request.StartDate.Value);
        if (request.EndDate.HasValue) query = query.Where(r => r.DateReceived <= request.EndDate.Value);
        if (!string.IsNullOrWhiteSpace(request.PackingListNumber)) query = query.Where(r => r.Reference.Contains(request.PackingListNumber));
        if (!string.IsNullOrWhiteSpace(request.PlateNumber)) query = query.Where(r => r.PlateNumber.Contains(request.PlateNumber));

        var rows = await query
            .Select(r => new
            {
                PackingList = r.Reference,
                PlateNumber = r.PlateNumber,
                ReceivingDate = r.DateReceived.ToString("yyyy-MM-dd"),
                PalletCount = r.Products!.Where(p => p.PalletId.HasValue).Select(p => p.PalletId).Distinct().Count(),
                ItemCount = r.Products!.Count,
                QuantityReceived = r.Products!.Sum(p => p.Quantity),
                CBM = r.Products!.Sum(p => Convert.ToDecimal(p.CBM ?? 0m)),
                Weight = r.Products!.Sum(p => (p.Weight ?? 0m) * p.Quantity),
                Status = r.Incoming != null ? r.Incoming.Status.ToString() : "RECEIVED"
            })
            .OrderBy(x => x.PackingList)
            .ThenBy(x => x.PlateNumber)
            .ToListAsync(ct);

        if (request.Format == ReportFormat.Csv)
        {
            await ExportCsvAsync(filePath, rows);
            return;
        }

        using var workbook = new XLWorkbook();
        var ws = workbook.Worksheets.Add("Per Plate Report");

        string[] headers = { "Packing List", "Plate Number", "Receiving Date", "Pallets Count", "Distinct Items", "Qty Received", "CBM", "Total Weight", "Status" };
        for (int i = 0; i < headers.Length; i++) ws.Cell(1, i + 1).Value = headers[i];
        ws.Row(1).Style.Font.Bold = true;
        ws.Row(1).Style.Fill.BackgroundColor = XLColor.FromHtml("#1E293B");
        ws.Row(1).Style.Font.FontColor = XLColor.White;

        int rowIdx = 2;
        foreach (var r in rows)
        {
            ws.Cell(rowIdx, 1).Value = r.PackingList;
            ws.Cell(rowIdx, 2).Value = r.PlateNumber;
            ws.Cell(rowIdx, 3).Value = r.ReceivingDate;
            ws.Cell(rowIdx, 4).Value = r.PalletCount;
            ws.Cell(rowIdx, 5).Value = r.ItemCount;
            ws.Cell(rowIdx, 6).Value = r.QuantityReceived;
            ws.Cell(rowIdx, 7).Value = r.CBM;
            ws.Cell(rowIdx, 8).Value = r.Weight;
            ws.Cell(rowIdx, 9).Value = r.Status;
            rowIdx++;
        }
        ws.Columns().AdjustToContents();
        workbook.SaveAs(filePath);
    }
    #endregion

    #region 3. Receiving Report per Packing List – Received vs. Remaining
    private async Task GenerateReport3Async(GenerateReceivingReportRequest request, string filePath, CancellationToken ct)
    {
        // 1. Identify targeted IncomingIds if filtering by PackingListNumber (from Receivings.Reference)
        List<int>? matchingIncomingIds = null;
        if (!string.IsNullOrWhiteSpace(request.PackingListNumber))
        {
            matchingIncomingIds = await _dbContext.Receivings
                .AsNoTracking()
                .Where(r => r.IncomingId != null && r.Reference.Contains(request.PackingListNumber))
                .Select(r => r.IncomingId!.Value)
                .Distinct()
                .ToListAsync(ct);
        }

        // 2. Query target Incomings and expected line items (Include Product navigation)
        var incomingQuery = _dbContext.Incomings
            .Include(i => i.Products!)
                .ThenInclude(p => p.Product)
            .AsNoTracking()
            .AsQueryable();

        if (request.IncomingId.HasValue)
            incomingQuery = incomingQuery.Where(i => i.Id == request.IncomingId.Value);

        if (matchingIncomingIds != null)
            incomingQuery = incomingQuery.Where(i => matchingIncomingIds.Contains(i.Id));

        var incomings = await incomingQuery.ToListAsync(ct);
        var incomingIds = incomings.Select(i => i.Id).ToList();

        // 3. Query ALL Receivings & ReceivedProducts linked to these Incomings
        var allReceivings = await _dbContext.Receivings
            .Include(r => r.Products!)
            .AsNoTracking()
            .Where(r => r.IncomingId != null && incomingIds.Contains(r.IncomingId.Value))
            .ToListAsync(ct);

        var receivingsByIncoming = allReceivings
            .GroupBy(r => r.IncomingId!.Value)
            .ToDictionary(g => g.Key, g => g.ToList());

        // 4. Build ClosedXML Spreadsheet
        using var workbook = new XLWorkbook();
        var ws = workbook.Worksheets.Add("Received vs Remaining");

        string[] headers = {
        "Packing List", "Item Code / Name", "Expected Qty", "Received Qty",
        "Remaining Qty", "Receiving %", "UOM", "Item Status",
        "First Recv Date", "Latest Recv Date"
    };

        for (int i = 0; i < headers.Length; i++) ws.Cell(1, i + 1).Value = headers[i];
        ws.Row(1).Style.Font.Bold = true;
        ws.Row(1).Style.Fill.BackgroundColor = XLColor.FromHtml("#0F172A");
        ws.Row(1).Style.Font.FontColor = XLColor.White;

        int rowIdx = 2;
        foreach (var inc in incomings)
        {
            receivingsByIncoming.TryGetValue(inc.Id, out var relatedReceivings);
            relatedReceivings ??= new List<Receiving>();

            string packingListRef = relatedReceivings
                .Select(r => r.Reference)
                .FirstOrDefault(r => !string.IsNullOrEmpty(r)) ?? $"INC-{inc.Id}";

            DateTime? firstDate = relatedReceivings.Any() ? relatedReceivings.Min(r => r.DateReceived) : null;
            DateTime? latestDate = relatedReceivings.Any() ? relatedReceivings.Max(r => r.DateReceived) : null;

            var allReceivedProducts = relatedReceivings
                .SelectMany(r => r.Products ?? new List<ReceivedProduct>())
                .ToList();

            var expectedProducts = inc.Products ?? new List<IncomingProduct>();

            foreach (var prod in expectedProducts)
            {
                int expected = prod.Quantity;

                // Match against ReceivedProduct.IncomingProductId or ProductId safely
                int actualReceived = allReceivedProducts
                    .Where(rp => rp.IncomingProductId == prod.Id || rp.ProductId == prod.ProductId)
                    .Sum(rp => rp.Quantity);

                int remaining = Math.Max(0, expected - actualReceived);
                double percentage = expected > 0 ? Math.Round((double)actualReceived / expected * 100, 2) : 0;

                string status = remaining == 0 && actualReceived > 0
                    ? "Fully Received"
                    : (actualReceived > 0 ? "Partially Received" : "Not Yet Received");

                ws.Cell(rowIdx, 1).Value = packingListRef;
                ws.Cell(rowIdx, 2).Value = prod.Product?.Name ?? "N/A"; // 👈 Access via Product navigation
                ws.Cell(rowIdx, 3).Value = expected;
                ws.Cell(rowIdx, 4).Value = actualReceived;
                ws.Cell(rowIdx, 5).Value = remaining;
                ws.Cell(rowIdx, 6).Value = $"{percentage}%";
                ws.Cell(rowIdx, 7).Value = prod.Product?.TypeOfPackage; // 👈 Access via Product navigation
                ws.Cell(rowIdx, 8).Value = status;
                ws.Cell(rowIdx, 9).Value = firstDate.HasValue ? firstDate.Value.ToString("yyyy-MM-dd") : "N/A";
                ws.Cell(rowIdx, 10).Value = latestDate.HasValue ? latestDate.Value.ToString("yyyy-MM-dd") : "N/A";

                if (status == "Fully Received") ws.Cell(rowIdx, 8).Style.Font.FontColor = XLColor.Emerald;
                else if (status == "Partially Received") ws.Cell(rowIdx, 8).Style.Font.FontColor = XLColor.DarkOrange;
                else ws.Cell(rowIdx, 8).Style.Font.FontColor = XLColor.Red;

                rowIdx++;
            }
        }

        ws.Columns().AdjustToContents();
        workbook.SaveAs(filePath);
    }
    #endregion

    #region 4. Daily Receiving Report per Packing List
    private async Task GenerateReport4Async(GenerateReceivingReportRequest request, string filePath, CancellationToken ct)
    {
        var query = _dbContext.Receivings
            .Include(r => r.Incoming)
            .Include(r => r.Products)
            .AsNoTracking()
            .AsQueryable();

        if (request.StartDate.HasValue) query = query.Where(r => r.DateReceived >= request.StartDate.Value);
        if (request.EndDate.HasValue) query = query.Where(r => r.DateReceived <= request.EndDate.Value);
        if (!string.IsNullOrWhiteSpace(request.PackingListNumber)) query = query.Where(r => r.Reference.Contains(request.PackingListNumber));
        if (!string.IsNullOrWhiteSpace(request.PlateNumber)) query = query.Where(r => r.PlateNumber.Contains(request.PlateNumber));

        var rows = await query
            .GroupBy(r => new
            {
                RecvDate = r.DateReceived.Date,
                PackingList = r.Reference
            })
            .Select(g => new
            {
                ReceivingDate = g.Key.RecvDate.ToString("yyyy-MM-dd"),
                PackingList = g.Key.PackingList,
                PlateNumber = string.Join(", ", g.Select(x => x.PlateNumber).Distinct()),
                PalletCount = g.SelectMany(x => x.Products!).Where(p => p.PalletId.HasValue).Select(p => p.PalletId).Distinct().Count(),
                ItemCount = g.SelectMany(x => x.Products!).Count(),
                QuantityReceived = g.SelectMany(x => x.Products!).Sum(p => p.Quantity),
                CBM = g.SelectMany(x => x.Products!).Sum(p => Convert.ToDecimal(p.CBM ?? 0m)),
                Weight = g.SelectMany(x => x.Products!).Sum(p => (p.Weight ?? 0m) * p.Quantity),
                Status = g.Select(x => x.Incoming != null ? x.Incoming.Status.ToString() : "RECEIVED").FirstOrDefault() ?? "RECEIVED"
            })
            .OrderByDescending(x => x.ReceivingDate)
            .ThenBy(x => x.PackingList)
            .ToListAsync(ct);

        if (request.Format == ReportFormat.Csv)
        {
            await ExportCsvAsync(filePath, rows);
            return;
        }

        using var workbook = new XLWorkbook();
        var ws = workbook.Worksheets.Add("Daily Receiving Report");

        string[] headers = { "Receiving Date", "Packing List", "Plate Number(s)", "Pallet Count", "Item Count", "Qty Received", "CBM", "Weight", "Status" };
        for (int i = 0; i < headers.Length; i++) ws.Cell(1, i + 1).Value = headers[i];
        ws.Row(1).Style.Font.Bold = true;
        ws.Row(1).Style.Fill.BackgroundColor = XLColor.FromHtml("#1E293B");
        ws.Row(1).Style.Font.FontColor = XLColor.White;

        int rowIdx = 2;
        foreach (var r in rows)
        {
            ws.Cell(rowIdx, 1).Value = r.ReceivingDate;
            ws.Cell(rowIdx, 2).Value = r.PackingList;
            ws.Cell(rowIdx, 3).Value = r.PlateNumber;
            ws.Cell(rowIdx, 4).Value = r.PalletCount;
            ws.Cell(rowIdx, 5).Value = r.ItemCount;
            ws.Cell(rowIdx, 6).Value = r.QuantityReceived;
            ws.Cell(rowIdx, 7).Value = r.CBM;
            ws.Cell(rowIdx, 8).Value = r.Weight;
            ws.Cell(rowIdx, 9).Value = r.Status;
            rowIdx++;
        }
        ws.Columns().AdjustToContents();
        workbook.SaveAs(filePath);
    }
    #endregion

    private static async Task ExportCsvAsync<T>(string filePath, IEnumerable<T> data)
    {
        using var writer = new StreamWriter(filePath, false, Encoding.UTF8);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        await csv.WriteRecordsAsync(data);
    }
}