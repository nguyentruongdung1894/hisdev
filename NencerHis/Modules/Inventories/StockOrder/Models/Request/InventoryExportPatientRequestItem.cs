namespace NencerHis.Modules.Inventories.StockOrder.Models.Request
{
    public class InventoryExportPatientRequestItem
    {
        public int InventoryId { get; set; }
        public int Qty { get; set; }
        public string Unit { get; set; }
    }
}
