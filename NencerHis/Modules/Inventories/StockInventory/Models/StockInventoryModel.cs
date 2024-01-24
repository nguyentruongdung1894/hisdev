using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NencerHis.Modules.Inventories.StockInventory.Models
{
    public class StockInventoryModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [Browsable(false)]
        public int? StockId { get; set; }

        [DisplayName("Tên kho")]
        public string? StockName { get; set; }

        [Browsable(false)]
        public int? ProductId { get; set; }

        [DisplayName("Tên sản phẩm")]
        public string? ProductName { get; set; }

        [DisplayName("Barcode")]
        public string? Barcode { get; set; }

        [DisplayName("Số lô")]
        public string? PackageCode { get; set; }

        [Browsable(false)]
        public int? SupplierId { get; set; }

        [DisplayName("Tên nhà cung cấp")]
        public string? SupplierName { get; set; }

        [Browsable(false)]
        public int? BidId { get; set; }

        [DisplayName("Tên gói thầu")]
        public string? BidName { get; set; }

        [DisplayName("Số lượng")]
        public int? Qty { get; set; }

        [Browsable(false)]
        public int? LockedQty { get; set; }

        [Browsable(false)]
        public string? CertificateCode { get; set; }

        [Browsable(false)]
        public DateTime? ProductionDate { get; set; }

        [Browsable(false)]
        public DateTime? ExpirationDate { get; set; }

        [Browsable(false)]
        public string? Position { get; set; }

        [Browsable(false)]
        public int? Status { get; set; }

        [Browsable(false)]
        public int? CreatorId { get; set; }

        [Browsable(false)]
        public int? UpdaterId { get; set; }

        [DisplayName("Giá nhâp")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal? PriceInput { get; set; }

        [DisplayName("Giá bán")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal? Price { get; set; }

        [DisplayName("Giá yêu cầu")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal? PriceRequest { get; set; }

        [DisplayName("Giá yêu bảo hiểm")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal? PriceIns { get; set; }

        [DisplayName("Mô tả")]
        public string? Description { get; set; }

        [Browsable(false)]
        public DateTime? CreatedAt { get; set; }

        [Browsable(false)]
        public DateTime? UpdatedAt { get; set; }

        [Browsable(false)]
        public int TotalCount { get; set; }
    }
}
