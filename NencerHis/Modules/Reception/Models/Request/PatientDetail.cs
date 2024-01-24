namespace NencerHis.Modules.Reception.Models.Request
{
    public class PatientDetail
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string? Address { get; set; }

        public string? AddressWorkplace { get; set; }

        public int? Married { get; set; }

        public int? Children { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public string? JobTitle { get; set; }

        public string? Company { get; set; }

        public string? Education { get; set; }

        public string? Prehistoric { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
