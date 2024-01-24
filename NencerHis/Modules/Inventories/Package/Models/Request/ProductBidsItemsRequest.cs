namespace NencerHis.Modules.Inventories.Package.Models.Request
{
    public class ProductBidsItemsRequest
    {
        public int Id { get; set; }
        public int BidId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Vat { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public decimal PriceIns { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
