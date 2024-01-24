using System.ComponentModel;

namespace NencerHis.Modules.Inventories.StockOrder.Models
{
    public class StockOdersModel
    {
        [Browsable(false)]
        public int? Id { get; set; }

        [DisplayName("Mã phiếu")]
        public string? Code { get; set; }

        [DisplayName("Phiếu")]
        public string? Coupon { get; set; }

        [DisplayName("Nhà cung cấp")]
        public string? Supplier { get; set; }

        [DisplayName("Kho nhập")]
        public string? Stock { get; set; }

        [DisplayName("Kho xuất")]
        public string? TargetStock { get; set; }

        [DisplayName("Trạng thái phiếu")]
        public string? Status { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime? ImportDate { get; set; }

        [DisplayName("Ngày duyệt")]
        public DateTime? ApproveDate { get; set; }

        [DisplayName("Ngày xuất kho")]
        public DateTime? ExportDate { get; set; }

        [DisplayName("Khoa, phòng")]
        public string? DepartmentRoom { get; set; }

        [DisplayName("Tên bệnh nhân")]
        public string? Name { get; set; }

        [DisplayName("Ghi chú")]
        public string? Note { get; set; }

        public int TotalCount { get; set; }
    }
}
