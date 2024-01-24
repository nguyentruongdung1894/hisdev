namespace NencerHis.Modules.InvoiceAndPayment.InventoryCashier.Models
{
    public class dbTest
    {
        public class KhachHangKham
        {
            public int Id { get; set; }
            public string KhachHang { get; set; }
            public string DiaChi { get; set; }
            public int TrangThai { get; set; }
            public string Gio { get; set; }
            public string MaKH { get; set; }
            public Image TT { get; set; }
        }


        public class DSDoThuoc
        {
            public int Id { get; set; }
            public string MaPhieu { get; set; }
            public DateTime Ngay { get; set; }
        }

        public class DSDVOder
        {
            public string MaDV { get; set; }
            public string TenDV { get; set; }
            public string NhomDV { get; set; }
            public int SL { get; set; }
            public decimal DonGia { get; set; }
            public decimal ThanhTien { get; set; }
            public string DoiTuong { get; set; }
            public string TrangThaiTT { get; set; }
        }

        public class DSDVXetNghiem
        {
            public int? STT { get; set; }
            public string TenDichVu { get; set; }
            public int SL { get; set; }
            public string KetQuaThucHien { get; set; }
            public string DonVi { get; set; }
            public string KetQuaMayXN { get; set; }
            public string GiaTriBT { get; set; }
        }
    }
}
