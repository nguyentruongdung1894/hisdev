namespace NencerHis.Modules.Reception.Models
{
    public class SearchModel
    {
        public string? MaBenhNhan { get; set; }

        public string? SoDT { get; set; }

        public string? SoCCCD { get; set; }

        public string? FromDate { get; set; }

        public string? ToDate { get; set; }

        public int SkipCount { get; set; } = 0;

        public int MaxResultCount { get; set; } = 10;
    }
}
