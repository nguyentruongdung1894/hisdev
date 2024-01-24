namespace NencerHis.Modules.Inventories.StockOrder.Models.Request
{
    public class ProductStockOrderItemsRequest
    {
        public int? Name { get; set; }

        public string? Code { get; set; }

        public string? Concentration { get; set; }

        public string? Content { get; set; }

        public int? CatId { get; set; }

        public string? LootCode { get; set; }

        public string? CountryCode { get; set; }

        public string? Manufacturer { get; set; }

        public string? RegistrationNumber { get; set; }

        public int? Unit { get; set; }

        public string? Usage { get; set; }

        public string? Day { get; set; }

        public string? Month { get; set; }

        public string? Year { get; set; }

        public int? Quantity { get; set; }

        public decimal? PriceInput { get; set; }

        public decimal? Tax { get; set; }

        public decimal? Price { get; set; }

        public decimal? TotalPrice { get; set; }

        public decimal? PriceIns { get; set; }

        public string? BidDecisionNumber { get; set; }

        public string? ContractorGroup { get; set; }

        public int? BidId { get; set; }

        public string? BidYear { get; set; }

        public decimal? TollPrice { get; set; }

        public decimal? PriceRequest { get; set; }

    }
}
