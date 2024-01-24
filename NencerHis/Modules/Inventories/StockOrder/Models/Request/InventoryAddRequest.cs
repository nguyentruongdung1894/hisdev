namespace NencerHis.Modules.Inventories.StockOrder.Models.Request
{
    public class InventoryAddRequest
    {
        public int StockId { get; set; }
        public int? SupplierId { get; set; }
        public string Code { get; set; }
        public DateTime? BillDate { get; set; }
        public string? Receiver { get; set; }
        public string? Deliver { get; set; }
        public int? Status { get; set; }
        public string? Note { get; set; }
        public List<Items> Items { get; set; }
    }

    public class Items
    {
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public string Unit { get; set; }
        public Decimal? PriceInput { get; set; }
        public Decimal? Tax { get; set; }
        public string? PackageCode { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public Decimal? Price { get; set; }
        public Decimal? PriceIns { get; set; }
        public Decimal? PriceRequest { get; set; }
        public string? BidNumber { get; set; }
        public string? BidGroup { get; set; }
        public string? BidPackage { get; set; }
        public string? BidYear { get; set; }
        public int? BidId { get; set; }
        public string? LotCode { get; set; }
    }
}
