using DevExpress.XtraTab;
using NencerHis.Modules.CommonManager;
using NencerHis.Modules.ExaminationManager.ExaminationListUser.Forms;

namespace NencerHis.Modules.Reception.Forms
{
    public partial class ExaminationManagerUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public ExaminationManagerUserControl()
        {
            InitializeComponent();
        }

        private void ExaminationManagerUserControl_Load(object sender, EventArgs e)
        {

        }

        private void xtraTabControl_CloseButtonClick(object sender, EventArgs e)
        {
            xtraTabControl.TabPages.RemoveAt(xtraTabControl.SelectedTabPageIndex);
        }

        private void btnExaminationList_Click(object sender, EventArgs e)
        {
            // Xóa tất cả các tab khác ExaminationListUserControl
            RemoveTabsExcept<ExaminationListUserControl>();

            // Thêm tab mới với ExaminationListUserControl
            Common.AddTab(xtraTabControl, "Thông tin khám bệnh", new ExaminationListUserControl());
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
