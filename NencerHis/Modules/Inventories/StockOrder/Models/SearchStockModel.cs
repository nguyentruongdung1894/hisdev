namespace NencerHis.Modules.Inventories.StockOrder.Models
{
    public class SearchStockModel
    {
        public string? Name { get; set; }

        public int SkipCount { get; set; } = 0;

        public int MaxResultCount { get; set; } = 10;
    }
}
