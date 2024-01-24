using System.ComponentModel;

namespace NencerHis.Modules.Inventories.Stock.Models
{
    public class ProductStocksModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Mã kho")]
        public string Code { get; set; }

        [Browsable(false)]
        public int? Type { get; set; }

        [DisplayName("Loại")]
        public string? TypeName { get; set; }

        [DisplayName("Tên kho")]
        public string Name { get; set; }

        [DisplayName("Địa chỉ")]
        public string? Address { get; set; }

        [DisplayName("Số điện thoại")]
        public string? Phone { get; set; }

        [Browsable(false)]
        public int? DepartmentId { get; set; }

        [DisplayName("Bộ phận")]
        public string? DepartmentName { get; set; }

        [DisplayName("Quản lý kho")]
        public string? OwnerId { get; set; }

        [DisplayName("Mô tả")]
        public string? Description { get; set; }

        [Browsable(false)]
        public int? PaymentRequire { get; set; }

        [Browsable(false)]
        public int? Status { get; set; }

        [Browsable(false)]
        public DateTime? CreatedAt { get; set; }

        [Browsable(false)]
        public int TotalCount { get; set; }
    }
}
