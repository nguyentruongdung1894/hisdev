using System.ComponentModel;

namespace NencerHis.Modules.Inventories.Category.Models
{
    public class CategoryModel
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("Mã danh mục")]
        public string? Slug { get; set; }

        [DisplayName("Tên danh mục")]
        public string? Name { get; set; }

        [DisplayName("Khu vực")]
        public string? Area { get; set; }

        [DisplayName("Mô tả")]
        public string? Description { get; set; }

        public int TotalCount { get; set; }
    }
}
