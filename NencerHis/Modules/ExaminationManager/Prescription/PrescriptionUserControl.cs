using NencerHis.Modules.ExaminationManager.PrescriptionAdd;

namespace NencerHis.Modules.ExaminationManager.Prescription
{
    public partial class PrescriptionUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public PrescriptionUserControl()
        {
            InitializeComponent();
        }

        private void ctlPrescription_Load(object sender, EventArgs e)
        {
            //List<ExaminationListUser.Models.dbTest.DSDoThuoc> objDSDonThuoc = new List<ExaminationListUser.Models.dbTest.DSDoThuoc>(){
            //    new DSDoThuoc(){ Id = 1, MaPhieu="123123",Ngay=DateTime.Now},
            //    new DSDoThuoc(){ Id = 2, MaPhieu="12313",Ngay=DateTime.Now.AddDays(-2)}
            //};
            //gcPhieuThuoc.DataSource = objDSDonThuoc;
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            using (PrescriptionAddForm frm = new PrescriptionAddForm())
            {
                frm.ShowDialog();
            }
        }
    }
}
