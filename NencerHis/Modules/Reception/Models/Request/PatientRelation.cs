namespace NencerHis.Modules.Reception.Models.Request
{
    public class PatientRelation
    {
        public int Id { get; set; }

        public int? PatientId { get; set; }

        public string? RelationType { get; set; }

        public string? FaName { get; set; }

        public string? FaIdCard { get; set; }

        public string? FaAddress { get; set; }

        public string? FaPhone { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
