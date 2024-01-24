namespace NencerHis.Modules.Inventories.StockOrder.Models.Request
{
    public class StockRequest
    {
        public ProductStockOrdersRequest productStockOrdersRequest { get; set; }

        public InventoryTransferRequest inventoryTransferRequest { get; set; }

        public InventoryExportPatientRequest inventoryExportPatientRequest { get; set; }

        public InventoryExportCancelRequest inventoryExportCancelRequest { get; set; }

        public List<ProductStockOrderItemsRequest> listProductStockOrderItemsRequest { get; set; }
    }
}
