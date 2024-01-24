namespace NencerHis.Modules.Inventories.Product.Models
{
    public class ProductUnitModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Key { get; set; }

        public string? Type { get; set; }

        public string? Description { get; set; }

        public int? Default { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int TotalCount { get; set; }
    }
}
