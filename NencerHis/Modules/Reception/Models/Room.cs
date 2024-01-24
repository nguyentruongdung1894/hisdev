namespace NencerHis.Modules.Reception.Models
{
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? NameArray { get; set; }

        public string? Code { get; set; }

        public int? RoomType { get; set; }

        public int? DepartmentId { get; set; }

        public int? HospitalId { get; set; }

        public int? LocationId { get; set; }

        public int? AcceptInsurance { get; set; }

        public int? Polyclinic { get; set; }

        public int? BigClinic { get; set; }

        public int? Status { get; set; }

        public int? Sort { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        public string? RoomNumber { get; set; }

        public string? AllowUsers { get; set; }

        public string? TitlePrintName { get; set; }

        public string? RisDevice { get; set; }
    }
}
