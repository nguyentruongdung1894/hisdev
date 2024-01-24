namespace NencerHis.Modules.Inventories.Supplier.Models
{
    public class SearchSupplierModel
    {
        public string? Code { get; set; }

        public int SkipCount { get; set; } = 0;

        public int MaxResultCount { get; set; } = 10;
    }
}
