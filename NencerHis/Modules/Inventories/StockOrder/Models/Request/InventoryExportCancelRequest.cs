namespace NencerHis.Modules.Inventories.StockOrder.Models.Request
{
    public class InventoryExportCancelRequest
    {
        public int StockId { get; set; }
        public string Reason { get; set; }
        public int? Status { get; set; }
        public string? Note { get; set; }
        public int? Supplier_id { get; set; }
        public string? Receiver { get; set; }
        public List<InventoryExportCancelRequestItem> Items { get; set; }
    }
}
