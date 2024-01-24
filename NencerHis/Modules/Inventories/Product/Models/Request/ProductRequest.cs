namespace NencerHis.Modules.Inventories.Product.Models.Request
{
    public class ProductRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? CodeIns { get; set; }

        public string? NameIns { get; set; }

        public string? Sku { get; set; }

        public string? Barcode { get; set; }

        public int? CatId { get; set; }

        public string? LotCode { get; set; }

        public int? Qty { get; set; }

        public string? Area { get; set; }

        public string? Type { get; set; }

        public int? IsPrivate { get; set; }

        public string? Manufacturer { get; set; }

        public string? CurrencyCode { get; set; }

        public decimal? PriceInput { get; set; }

        public decimal? Price { get; set; }

        public decimal? TotalAmount { get; set; }

        public decimal? PriceRequest { get; set; }

        public decimal? PriceIns { get; set; }

        public string? Unit { get; set; }

        public string? Image { get; set; }

        public string? Description { get; set; }

        public string? Specifications { get; set; }

        public string? Concentration { get; set; }

        public string? Volume { get; set; }

        public string? ActiveIngredient { get; set; }

        public string? Content { get; set; }

        public string? CountryCode { get; set; }

        public string? GroupId { get; set; }

        public string? Usage { get; set; }

        public int? UsageIns { get; set; }

        public string? Packing { get; set; }

        public int? Antibiotic { get; set; }

        public int? EasternMed { get; set; }

        public int? FunctionalFood { get; set; }

        public int? Featured { get; set; }

        public string? RegistrationNumber { get; set; }

        public decimal? TaxRate { get; set; }

        public int? Sort { get; set; }

        public int? Status { get; set; }

        public int? BidId { get; set; }

        public string? BidGroup { get; set; }

        public string? BidNumber { get; set; }

        public string? BidYear { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? ExpirationDate { get; set; }
    }
}
