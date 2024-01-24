namespace NencerHis.Modules.Inventories.Supplier.Models.Request
{
    public class SupplierRequest
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? ContactPhone { get; set; }

        public string? ContactEmail { get; set; }

        public string? Description { get; set; }

        public int? Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
