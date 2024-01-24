using DevExpress.XtraTab;
using NencerHis.Modules.CommonManager;
using NencerHis.Modules.InvoiceAndPayment.InventoryCashier.Forms;
using NencerHis.Modules.LIS_RIS.LISHandle.Forms;

namespace NencerHis.Modules.LIS_RIS.LISHandle.Toolbar.Forms
{
    public partial class LisHandleUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public LisHandleUserControl()
        {
            InitializeComponent();
        }

        private void InvoiceAndPaymentUserControl_Load(object sender, EventArgs e)
        {

        }

        private void xtraTabControl_CloseButtonClick(object sender, EventArgs e)
        {
            xtraTabControl.TabPages.RemoveAt(xtraTabControl.SelectedTabPageIndex);
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            // Xóa tất cả các tab khác LISHandleUserControl
            RemoveTabsExcept<LISHandleUserControl>();

            // Thêm tab mới với LISHandleUserControl
            Common.AddTab(xtraTabControl, "Thông tin xét nghiệm", new LISHandleUserControl());
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
