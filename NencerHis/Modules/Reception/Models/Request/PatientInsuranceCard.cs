namespace NencerHis.Modules.Reception.Models.Request
{
    public class PatientInsuranceCard
    {
        public int Id { get; set; }

        public int? PatientId { get; set; }

        public string? FullNumber { get; set; }

        public string SubjectCode { get; set; }

        public string BenifitCode { get; set; }

        public string CityCode { get; set; }

        public string? Region { get; set; }

        public string? InsuranceAddress { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string? Status { get; set; } = "valid";

        public string? Note { get; set; }

        public int? BenefitRate { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? Line { get; set; }

        public string? Rank { get; set; }

        public DateTime? InactiveDay { get; set; }

        public DateTime? FullDateFiveYear { get; set; }
    }
}
