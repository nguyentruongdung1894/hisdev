namespace NencerHis.Modules.Inventories.StockOrder.Models
{
    public class SearchStockOdersModel
    {
        public int? Type { get; set; }

        public int SkipCount { get; set; } = 0;

        public int MaxResultCount { get; set; } = 10;
    }
}
