namespace NencerHis.Modules.Inventories.Category.Models
{
    public class SearchCategoryModel
    {
        public string? Slug { get; set; }

        public int SkipCount { get; set; } = 0;

        public int MaxResultCount { get; set; } = 10;
    }
}
