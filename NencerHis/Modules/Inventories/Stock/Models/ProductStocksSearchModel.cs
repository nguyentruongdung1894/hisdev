namespace NencerHis.Modules.Inventories.Stock.Models
{
    public class ProductStocksSearchModel
    {
        public string? Code { get; set; }

        public string? Name { get; set; }

        public int SkipCount { get; set; } = 0;

        public int MaxResultCount { get; set; } = 10;
    }
}
