namespace NencerHis.Modules.ExaminationManager.ExaminationListUser.Models
{
    public class ExaminationPatientsModel
    {
        public long? Id { get; set; }
        public string NameAge { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string Time { get; set; }
        public string PatientNumber { get; set; }
        public Image imageIcon { get; set; }
    }
}
