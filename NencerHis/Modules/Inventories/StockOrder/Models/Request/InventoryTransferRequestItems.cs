namespace NencerHis.Modules.Inventories.StockOrder.Models.Request
{
    public class InventoryTransferRequestItems
    {
        public int InventoryId { get; set; }
        public int Qty { get; set; }
        public string Unit { get; set; }
        public string? PackageCode { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public Decimal? Price { get; set; }
        public string? BidNumber { get; set; }
    }
}
