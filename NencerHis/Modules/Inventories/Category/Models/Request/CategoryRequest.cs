namespace NencerHis.Modules.Inventories.Category.Models.Request
{
    public class CategoryRequest
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string Slug { get; set; }

        public string? Area { get; set; }

        public string? Description { get; set; }

        public int? Sort { get; set; }

        public string? Image { get; set; }

        public int? Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
