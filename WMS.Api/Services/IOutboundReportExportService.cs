namespace WMS.Api.Services
{
    public enum ExportFormat
    {
        Excel = 1,
        Csv = 2
    }

    public interface IOutboundReportExportService
    {
        byte[] GenerateDispatchManifestExcel(IEnumerable<dynamic> manifestData);
        byte[] GenerateGenericCsv<T>(IEnumerable<T> records);
        byte[] GenerateTurnaroundExcel(IEnumerable<dynamic> turnaroundData);
    }
}
