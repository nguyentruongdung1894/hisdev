using System.ComponentModel;

namespace NencerHis.Modules.Reception.Models
{
    public class PatientsModel
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        public long CheckInID { get; set; }

        [DisplayName("Mã bệnh nhân")]
        public string MaBenhNhan { get; set; }

        [DisplayName("Tên bệnh nhân")]
        public string TenBenhNhan { get; set; }

        [DisplayName("Số điện thoại")]
        public string SoDT { get; set; }

        [DisplayName("Số CCCD")]
        public string CCCD { get; set; }

        [DisplayName("Đối tượng")]
        public string DoiTuong { get; set; }

        [DisplayName("Giới tính")]
        public string GioiTinh { get; set; }

        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [DisplayName("Ngày sinh")]
        public string ngaysinh { get; set; }

        [DisplayName("Khoa Khám")]
        public string khoakham { get; set; }

        [DisplayName("Tên phòng")]
        public string tenphong { get; set; }

        [DisplayName("Lý do khám")]
        public string lydokham { get; set; }

        [DisplayName("Số tiếp đón")]
        public int sotiepdon { get; set; }

        [DisplayName("Thời gian tiếp đón")]
        public string thoigiantiepdon { get; set; }

        [DisplayName("Trạng thái")]
        public string trangthai { get; set; }

        [DisplayName("Ưu tiên")]
        public string uutien { get; set; }
        
        public int TotalCount { get; set; }
    }
}
