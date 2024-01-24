namespace NencerHis.Modules.Inventories.Stock.Models.Request
{
    public class ProductStocksRequest
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public int Type { get; set; }

        public string Name { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public int? DepartmentId { get; set; }

        public string? OwnerId { get; set; }

        public int? PaymentRequire { get; set; }

        public string? Description { get; set; }

        public int? Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
