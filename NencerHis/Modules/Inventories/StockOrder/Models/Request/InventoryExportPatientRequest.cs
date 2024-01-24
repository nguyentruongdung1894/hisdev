namespace NencerHis.Modules.Inventories.StockOrder.Models.Request
{
    public class InventoryExportPatientRequest
    {
        public int StockId { get; set; }
        public int? Status { get; set; }
        public string? Note { get; set; }
        public string? PatientNumber { get; set; }
        public string? PatientName { get; set; }
        public string? DayBorn { get; set; }
        public string? MonthBorn { get; set; }
        public string? YearBorn { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }
        public List<InventoryExportPatientRequestItem> Items { get; set; }
    }
}
