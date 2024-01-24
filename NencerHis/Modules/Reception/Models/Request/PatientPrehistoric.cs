namespace NencerHis.Modules.Reception.Models.Request
{
    public class PatientPrehistoric
    {
        public int Id { get; set; }

        public int DiseaseId { get; set; }

        public int PatientId { get; set; }

        public string? Description { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
