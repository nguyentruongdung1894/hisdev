namespace NencerHis.Modules.Inventories.StockOrder.Models.Request
{
    public class ProductStockOrdersRequest
    {
        public int? StockId { get; set; }

        public int? SupplierId { get; set; }

        public string? Code { get; set; }

        public DateTime? OrderDate { get; set; }

        public string? Receiver { get; set; }

        public string? Deliver { get; set; }
    }
}
