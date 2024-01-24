namespace NencerHis.Modules.Reception.Models.Request
{
    public class CheckinRequest
    {
        public Checkin Checkin { get; set; }
        public Patient Patient { get; set; }
        public PatientDetail PatientDetail { get; set; } // Chi tiết bệnh nhân
        public PatientInsuranceCard? PatientInsuranceCard { get; set; } // BHYT ứng với bệnh nhân
        public List<PatientPrehistoric>? PatientPrehistoric { get; set; } //Tiền sử bệnh
        public List<PatientRelation>? PatientRelation { get; set; } //Gia đình bệnh nhân
    }
}
