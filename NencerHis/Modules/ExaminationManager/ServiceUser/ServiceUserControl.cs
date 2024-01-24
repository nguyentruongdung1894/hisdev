using NencerHis.Modules.ExaminationManager.ServiceAdd;

namespace NencerHis.Modules.ExaminationManager.ServiceUser
{
    public partial class ServiceUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public ServiceUserControl()
        {
            InitializeComponent();
        }

        private void btnChiDinhDichVu_Click(object sender, EventArgs e)
        {
            using (ServiceAddForm frm = new ServiceAddForm())
            {
                frm.ShowDialog();
            }
        }
    }
}
