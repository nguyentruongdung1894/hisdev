using System.ComponentModel;

namespace NencerHis.Modules.Inventories.Product.Models
{
    public class ProductModel
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("Mã thuốc")]
        public string? Sku { get; set; }

        [DisplayName("Tên thuốc")]
        public string? Name { get; set; }

        [DisplayName("Barcode")]
        public string? Barcode { get; set; }

        [DisplayName("Danh mục")]
        public string? CatId { get; set; }

        [Browsable(false)]
        public string? LotCode { get; set; }

        [Browsable(false)]
        public int? Qty { get; set; }

        [DisplayName("Hoạt chất")]
        public string? ActiveIngredient { get; set; }

        [DisplayName("Nồng độ")]
        public string? Concentration { get; set; }

        [DisplayName("Hàm lượng")]
        public string? Content { get; set; }

        [DisplayName("Đường dùng")]
        public string? Usage { get; set; }

        [DisplayName("Quốc gia")]
        public string? CountryCode { get; set; }

        [DisplayName("Hãng sản xuất")]
        public string? Manufacturer { get; set; }

        [Browsable(false)]
        public string? RegistrationNumber { get; set; }

        [DisplayName("Quy cách đóng gói")]
        public string? Packing { get; set; }

        [DisplayName("Đơn vị")]
        public string? Unit { get; set; }

        [DisplayName("Giá nhập")]
        public decimal? PriceInput { get; set; }

        [Browsable(false)]
        public decimal? TaxRate { get; set; }

        [DisplayName("Giá bán")]
        public decimal? Price { get; set; }

        [Browsable(false)]
        public decimal? TotalAmount { get; set; }

        [DisplayName("Giá yêu cầu")]
        public decimal? PriceRequest { get; set; }

        [DisplayName("Giá BHYT")]
        public decimal? PriceIns { get; set; }

        [DisplayName("Mô tả")]
        public string? Description { get; set; }

        [DisplayName("Dùng cho BHYT")]
        public string? UsageIns { get; set; }

        [DisplayName("Trạng thái")]
        public string? Status { get; set; }

        [Browsable(false)]
        public int? BidId { get; set; }

        [Browsable(false)]
        public DateTime? CreatedAt { get; set; }

        [Browsable(false)]
        public DateTime? ExpirationDate { get; set; }

        public int TotalCount { get; set; }
    }
}
