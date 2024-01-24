using DevExpress.XtraTab;
using NencerHis.Modules.CommonManager;
using NencerHis.Modules.Inventories.Category.Forms;
using NencerHis.Modules.Inventories.Package.Forms;
using NencerHis.Modules.Inventories.Product.Forms;
using NencerHis.Modules.Inventories.Stock.Forms;
using NencerHis.Modules.Inventories.StockInventory.Forms;
using NencerHis.Modules.Inventories.StockOrder.Forms;
using NencerHis.Modules.Inventories.Supplier.Forms;

namespace NencerHis.Modules.Reception.Forms
{
    public partial class ToolbarInventoriesUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public ToolbarInventoriesUserControl()
        {
            InitializeComponent();
        }

        private void ToolbarInventoriesUserControl_Load(object sender, EventArgs e)
        {

        }

        private void xtraTabControl_CloseButtonClick(object sender, EventArgs e)
        {
            xtraTabControl.TabPages.RemoveAt(xtraTabControl.SelectedTabPageIndex);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            // Xóa tất cả các tab khác CategoryUserControl
            RemoveTabsExcept<CategoryUserControl>();

            // Thêm tab mới với CategoryUserControl
            Common.AddTab(xtraTabControl, "Thêm Mới Danh mục thuốc", new CategoryUserControl());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            // Xóa tất cả các tab khác SupplierUserControl
            RemoveTabsExcept<SupplierUserControl>();

            // Thêm tab mới với SupplierUserControl
            Common.AddTab(xtraTabControl, "Thêm Mới Nhà cung cấp", new SupplierUserControl());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            // Xóa tất cả các tab khác ProductUserControl
            RemoveTabsExcept<ProductUserControl>();

            // Thêm tab mới với ProductUserControl
            Common.AddTab(xtraTabControl, "Thêm Mới Sản phẩm", new ProductUserControl());
        }

        private void btnStockOrder_Click(object sender, EventArgs e)
        {
            // Xóa tất cả các tab khác StockOdersUserControl
            RemoveTabsExcept<StockOdersUserControl>();

            // Thêm tab mới với StockOdersUserControl
            Common.AddTab(xtraTabControl, "Thêm Thông phiếu order", new StockOdersUserControl());
        }

        private void btnStockInventory_Click(object sender, EventArgs e)
        {
            // Xóa tất cả các tab khác StockInventoryUserControl
            RemoveTabsExcept<StockInventoryUserControl>();

            // Thêm tab mới với StockInventoryUserControl
            Common.AddTab(xtraTabControl, "Thông tin tồn kho", new StockInventoryUserControl());
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            // Xóa tất cả các tab khác StockFormUserControl
            RemoveTabsExcept<StockFormUserControl>();

            // Thêm tab mới với StockFormUserControl
            Common.AddTab(xtraTabControl, "Thêm Thông tin kho", new StockFormUserControl());
        }

        private void btnPackage_Click(object sender, EventArgs e)
        {
            // Xóa tất cả các tab khác PackageUserControl
            RemoveTabsExcept<PackageUserControl>();

            // Thêm tab mới với PackageUserControl
            Common.AddTab(xtraTabControl, "Thêm Thông tin gói thầu", new PackageUserControl());
        }

        private void RemoveTabsExcept<T>() where T : UserControl
        {
            // Lưu trữ danh sách các tab cần giữ lại
            List<XtraTabPage> tabsToKeep = new List<XtraTabPage>();

            // Lặp qua tất cả các tab
            foreach (XtraTabPage tabPage in xtraTabControl.TabPages)
            {
                // Kiểm tra nếu UserControl trong tab là loại T thì thêm vào danh sách giữ lại
                if (tabPage.Controls.Count > 0 && tabPage.Controls[0] is T)
                {
                    tabsToKeep.Add(tabPage);
                }
            }

            // Xóa tất cả các tab
            xtraTabControl.TabPages.Clear();

            // Thêm lại các tab cần giữ lại
            xtraTabControl.TabPages.AddRange(tabsToKeep.ToArray());
        }
    }
}
