using System.ComponentModel;

namespace NencerHis.Modules.Inventories.Package.Models
{
    public class ProductBidsItemsModel
    {
        [Browsable(false)]
        [ReadOnly(true)]
        public int? ProductId { get; set; }

        [DisplayName("Tên sản phẩm")]
        [ReadOnly(true)]
        public string? ProductName { get; set; }

        [DisplayName("Số lượng")]
        public int? Qty { get; set; }

        [DisplayName("VAT")]
        public int? Vat { get; set; }

        [DisplayName("Đơn vị")]
        [ReadOnly(true)]
        public string? Unit { get; set; }

        [DisplayName("Đơn giá bán")]
        [ReadOnly(true)]
        public decimal? Price { get; set; }

        [DisplayName("Giá bảo hiểm")]
        [ReadOnly(true)]
        public decimal? PriceIns { get; set; }

        [DisplayName("Tổng tiền")]
        public decimal? TotalPrice { get; set; }

        [Browsable(false)]
        [ReadOnly(true)]
        public int? Status { get; set; }
    }
}
