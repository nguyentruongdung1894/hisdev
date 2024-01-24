using DevExpress.XtraSplashScreen;
using NencerHis.Modules.CommonManager;
using NencerHis.Modules.InvoiceAndPayment.Toolbar.Forms;
using NencerHis.Modules.LIS_RIS.LISHandle.Toolbar.Forms;
using NencerHis.Modules.LIS_RIS.LISSample.Toolbar.Forms;
using NencerHis.Modules.Reception.Forms;

namespace NencerHis
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void xtraTabControl_CloseButtonClick(object sender, EventArgs e)
        {
            xtraTabControl.TabPages.RemoveAt(xtraTabControl.SelectedTabPageIndex);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void barBtnReception_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(frmStartApp), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Xin vui lòng chờ...");
            xtraTabControl.TabPages.Clear();
            Common.AddTab(xtraTabControl, "Đón tiếp", new DonTiepUserControl());
            SplashScreenManager.CloseForm();
        }

        private void barBtnInventories_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(frmStartApp), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Xin vui lòng chờ...");
            xtraTabControl.TabPages.Clear();
            Common.AddTab(xtraTabControl, "Quản lý kho thuốc", new ToolbarInventoriesUserControl());
            SplashScreenManager.CloseForm();
        }

        private void barBtnExaminationManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(frmStartApp), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Xin vui lòng chờ...");
            xtraTabControl.TabPages.Clear();
            Common.AddTab(xtraTabControl, "Khám bệnh", new ExaminationManagerUserControl());
            SplashScreenManager.CloseForm();
        }

        private void barBtnTicketCashier_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(frmStartApp), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Xin vui lòng chờ...");
            xtraTabControl.TabPages.Clear();
            Common.AddTab(xtraTabControl, "Thu ngân", new InvoiceAndPaymentUserControl());
            SplashScreenManager.CloseForm();
        }

        private void barBtnSample_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(frmStartApp), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Xin vui lòng chờ...");
            xtraTabControl.TabPages.Clear();
            Common.AddTab(xtraTabControl, "Lấy mẫu", new LisSampleUserControl());
            SplashScreenManager.CloseForm();
        }

        private void barBtnHandle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(frmStartApp), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Xin vui lòng chờ...");
            xtraTabControl.TabPages.Clear();
            Common.AddTab(xtraTabControl, "Xét nghiệm", new LisHandleUserControl());
            SplashScreenManager.CloseForm();
        }
    }
}