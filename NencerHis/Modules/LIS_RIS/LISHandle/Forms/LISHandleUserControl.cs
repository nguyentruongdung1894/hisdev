using static NencerHis.Modules.InvoiceAndPayment.InventoryCashier.Models.dbTest;

namespace NencerHis.Modules.LIS_RIS.LISHandle.Forms
{
    public partial class LISHandleUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public LISHandleUserControl()
        {
            InitializeComponent();
        }

        private void labelControl9_Click(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TestUserControl_Load(object sender, EventArgs e)
        {
            List<DSDVXetNghiem> objKH = new List<DSDVXetNghiem>(){
                 new DSDVXetNghiem(){ STT = 1, TenDichVu="Xét nghiệm nước tiểu", SL=1, KetQuaThucHien="",DonVi="",KetQuaMayXN="",GiaTriBT=""},
                new DSDVXetNghiem(){ STT = 2, TenDichVu="Tổng phân tích tế bào máu", SL=1, KetQuaThucHien="",DonVi="",KetQuaMayXN="",GiaTriBT=""},
                new DSDVXetNghiem(){ STT = null, TenDichVu="- WBC", SL=1, KetQuaThucHien="9.84",DonVi="K/ml",KetQuaMayXN="9.84",GiaTriBT="4.4 - 10.9"},
                new DSDVXetNghiem(){ STT = null, TenDichVu="- LYM", SL=1, KetQuaThucHien="12.6",DonVi="K/ml",KetQuaMayXN="12.6",GiaTriBT="10.0 - 58.5"},
                new DSDVXetNghiem(){ STT = null, TenDichVu="- MÔN", SL=1, KetQuaThucHien="5.70",DonVi="K/ml",KetQuaMayXN="5.70",GiaTriBT="0.0 - 12.0"},
            };
            gcData.DataSource = objKH;
        }
    }
}
