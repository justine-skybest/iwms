namespace WMS.Api.Helpers
{
    public static class LotNumberGenerator
    {
        /// <summary>
        /// Generates a structured WMS Lot Number if none is provided.
        /// Format: LOT-YYYYMMDD-RCV{ReceivingId}-PRD{ProductId}-{Sequence}
        /// </summary>
        public static string Generate(string? existingLotNumber, int receivingId, int productId, int sequenceIndex = 1)
        {
            if (!string.IsNullOrWhiteSpace(existingLotNumber))
            {
                return existingLotNumber.Trim().ToUpper();
            }

            var datePrefix = DateTime.UtcNow.ToString("yyyyMMdd");
            return $"LOT-{datePrefix}-RCV{receivingId}-PRD{productId}-{sequenceIndex:D2}";
        }
    }
}
