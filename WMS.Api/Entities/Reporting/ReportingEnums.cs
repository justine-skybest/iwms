namespace WMS.Api.Entities.Reporting
{
    public enum ReportType
    {
        Receiving,

        PickOrder,
        Incoming,
        Aging,
        Warehouse_Occupancy,
        Inventory
    }

    public enum ReportFormat
    {
        Csv,
        Pdf,
        Excel
    }

    public enum ReportStatus
    {
        Pending,
        Processing,
        Completed,
        Failed
    }

    public enum ReceivingReportSubType
    {
        PerPalletPerPackingList = 1,
        PerPlateNumberPerPackingList = 2,
        ReceivedVsRemaining = 3,
        DailyPerPackingList = 4
    }
}
