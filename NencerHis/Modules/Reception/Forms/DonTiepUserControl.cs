using NencerHis.Modules.CommonManager;

namespace NencerHis.Modules.Reception.Forms
{
    public partial class DonTiepUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public DonTiepUserControl()
        {
            InitializeComponent();
        }

        private void DonTiepUserControl_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textEdit36_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            Common.AddTab(xtraTabControl, "Thêm Mới Đón tiếp", new ThemMoiDonTiepUserControl());
        }

        private void xtraTabControl_CloseButtonClick(object sender, EventArgs e)
        {
            xtraTabControl.TabPages.RemoveAt(xtraTabControl.SelectedTabPageIndex);
        }
    }
}
