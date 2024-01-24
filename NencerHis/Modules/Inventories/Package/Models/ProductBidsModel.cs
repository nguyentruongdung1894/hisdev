using System.ComponentModel;

namespace NencerHis.Modules.Inventories.Package.Models
{
    public class ProductBidsModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [Browsable(false)]
        public int ProductId { get; set; }

        [Browsable(false)]
        public int? SupplierId { get; set; }

        [DisplayName("Tên nhà cung cấp")]
        public string? SupplierName { get; set; }

        [DisplayName("Mã gói thầu")]
        public string? Code { get; set; }

        [DisplayName("Tên gói thầu")]
        public string? Name { get; set; }

        [DisplayName("Gói thầu số")]
        public string? BidNumber { get; set; }

        [DisplayName("Nhóm thầu")]
        public string? BidGroup { get; set; }

        [DisplayName("Số QĐ thầu")]
        public string? BidPackage { get; set; }

        [DisplayName("Ngày chứng từ")]
        public DateTime? BidDate { get; set; }

        [DisplayName("Năm")]
        public string? BidYear { get; set; }

        [DisplayName("Mô tả")]
        public string? Description { get; set; }

        [Browsable(false)]
        public int? Status { get; set; }

        [DisplayName("Người tạo")]
        public string? CreatorId { get; set; }

        [DisplayName("Người sửa")]
        public string? UpdaterId { get; set; }

        [Browsable(false)]
        public DateTime? CreatedAt { get; set; }

        [Browsable(false)]
        public DateTime? UpdatedAt { get; set; }

        [Browsable(false)]
        public int TotalCount { get; set; }
    }
}
