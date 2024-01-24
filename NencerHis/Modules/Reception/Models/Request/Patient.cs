namespace NencerHis.Modules.Reception.Models.Request
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? IdCardType { get; set; }
        public string? PatientNumber { get; set; }
        public decimal? Credit { get; set; }
        public string? Image { get; set; }
        public string? IdCard { get; set; }
        public DateTime? IssueDate { get; set; }
        public string? Type { get; set; }
        public string? Gender { get; set; }
        public string? DayBorn { get; set; }
        public string? MonthBorn { get; set; }
        public string? YearBorn { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Lang { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }
        public int? PartnerId { get; set; }
        public string? Address { get; set; }
        public string? CountryCode { get; set; }
        public string? Nationality { get; set; }
        public string? PostCode { get; set; }
        public string? Ethnic { get; set; }
        public string? DetailObject { get; set; }
        public string? JobTitle { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
