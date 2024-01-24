using System.ComponentModel;

namespace NencerHis.Modules.Inventories.Supplier.Models
{
    public class SupplierModel
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("Mã nhà cung cấp")]
        public string? Code { get; set; }

        [DisplayName("Tên nhà cung cấp")]
        public string? Name { get; set; }

        [DisplayName("Địa chỉ")]
        public string? Address { get; set; }

        [DisplayName("Số điện thoại")]
        public string? ContactPhone { get; set; }

        [DisplayName("Email")]
        public string? ContactEmail { get; set; }

        [DisplayName("Mô tả")]
        public string? Description { get; set; }

        public int TotalCount { get; set; }
    }
}
