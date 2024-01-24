namespace NencerHis.Modules.Reception.Models.Request
{
    public class Checkin
    {
        public long Id { get; set; }
        public int PatientId { get; set; }
        public string? PatientNumber { get; set; }
        public string? ServiceObject { get; set; }
        public string? Type { get; set; }
        public int? CheckinNumber { get; set; }
        public int? Priority { get; set; }
        public int? RoomId { get; set; }
        public string? RoomCode { get; set; }
        public int? DepartmentId { get; set; }
        public int? DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public string? Reason { get; set; }
        public string? Status { get; set; }
        public int? ChamberId { get; set; }
        public int? BedId { get; set; }
        public int? ServiceId { get; set; }
        public DateTime? CheckinTime { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
