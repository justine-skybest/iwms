namespace WMS.Api.Dtos.Receiving
{
    public enum ReceivedItemStatus
    {
        Matched = 1,                 // Item is in the original PL
        Unlisted_PendingPL = 2,      // Item physically arrived but not in PL
        RevisedPL_Received = 3,      // Shipper submitted revised PL (System state)
        Validated = 4,               // Item is confirmed against revised PL
        ForClarification = 5,        // Shipper has not confirmed/revised
        Rejected = 6                 // Item cannot be received based on rules
    }
}
