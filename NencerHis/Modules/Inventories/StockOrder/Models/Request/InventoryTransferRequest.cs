namespace NencerHis.Modules.Inventories.StockOrder.Models.Request
{
    public class InventoryTransferRequest
    {
        public int StockId { get; set; }
        public int TargetStockId { get; set; }
        public int? Status { get; set; }
        public string? Note { get; set; }
        public List<InventoryTransferRequestItems> Items { get; set; }
    }
}
