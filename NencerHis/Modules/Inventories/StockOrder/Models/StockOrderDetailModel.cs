using System.ComponentModel;

namespace NencerHis.Modules.Inventories.StockOrder.Models
{
    public class StockOrderDetailModel
    {
        [DisplayName("Tên thuốc")]
        [ReadOnly(true)]
        public string? Name { get; set; }

        [DisplayName("Nồng độ")]
        [ReadOnly(true)]
        public string? Concentration { get; set; }

        [DisplayName("Hàm lượng")]
        [ReadOnly(true)]
        public string? Content { get; set; }

        [DisplayName("Số lượng")]
        public int? Quantity { get; set; }

        [DisplayName("Giá bán")]
        [ReadOnly(true)]
        public decimal? Price { get; set; }

        [DisplayName("Thành tiền")]
        [ReadOnly(true)]
        public decimal? TotalPrice { get; set; }

        [DisplayName("Số lô")]
        [ReadOnly(true)]
        public string? LotCode { get; set; }

        [DisplayName("QĐ thầu")]
        [ReadOnly(true)]
        public string? BidDecisionNumber { get; set; }

        [DisplayName("Nhóm thầu")]
        [ReadOnly(true)]
        public string? ContractorGroup { get; set; }

        [DisplayName("Gói thầu")]
        [ReadOnly(true)]
        public string? BidId { get; set; }

        [DisplayName("Năm thầu")]
        [ReadOnly(true)]
        public string? BidYear { get; set; }

        [Browsable(false)]
        public int TotalCount { get; set; }
    }
}
