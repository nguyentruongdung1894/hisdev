using NencerHis.Modules.CommonManager;
using NencerHis.Modules.Inventories.StockOrder.Models;
using NencerHis.Modules.Inventories.StockOrder.Models.Request;
using NencerHis.Modules.Reception.Models.Request;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace NencerHis.Modules.Inventories.StockOrder.InvoiceInforUserControl
{
    public partial class ExportCustomersUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        // API url
        public const string URL = "http://localhost:5294/";

        // List
        List<StockModel> _cbbStockOutputData = new List<StockModel>();
        List<Province> _provinces = new List<Province>();
        List<Districts> _districts = new List<Districts>();
        List<Wards> _wards = new List<Wards>();

        // Model
        Patient _patient = new Patient();

        // Sử dụng Tuple để truyền nhiều giá trị
        public event EventHandler<(int SelectValue, string SelectedName)> SelectedStockValueChanged;

        public ExportCustomersUserControl()
        {
            InitializeComponent();
        }

        private void ExportCustomersUserControl_Load(object sender, EventArgs e)
        {
            Init();
        }

        private async void Init()
        {
            await createCbbStockOutput();
            createCbbGender();
            await createcbbProvinces();

            // Set focus init
            cbbStockOutput.Focus();
        }

        private async Task createCbbStockOutput()
        {
            // Init SearchStockModel
            SearchStockModel searchModel = new SearchStockModel();
            // Create SkipCount, MaxResultCount
            searchModel.SkipCount = 0;
            searchModel.MaxResultCount = 999999;

            // Khởi tạo HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Chuyển đổi đối tượng SearchModel thành dữ liệu JSON
                    string json = JsonConvert.SerializeObject(searchModel);

                    // Tạo nội dung yêu cầu HTTP từ dữ liệu JSON
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Gửi yêu cầu HTTP POST tới API
                    HttpResponseMessage response = await client.PostAsync(URL + "api/Stock/StockOutput/List", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu từ phản hồi API
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng StockModel
                        _cbbStockOutputData = JsonConvert.DeserializeObject<List<StockModel>>(apiResponse);

                        // Thêm các mục từ danh sách vào ComboBoxEdit
                        foreach (var item in _cbbStockOutputData)
                        {
                            cbbStockOutput.Properties.Items.Add(item.Name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void createCbbGender()
        {
            // Tạo danh sách các đối tượng Bảo hiểm và Tự nguyện
            List<ComboBoxModel> listComboBox = new List<ComboBoxModel>
            {
                new ComboBoxModel(0, "Nam"),
                new ComboBoxModel(1, "Nữ")
            };
            // Thêm các tên của đối tượng vào ComboBoxEdit
            foreach (var cmb in listComboBox)
            {
                cbbGender.Properties.Items.Add(cmb.Value);
            }
            // Chọn giá trị mặc định là blank
            cbbGender.SelectedIndex = -1;
        }

        private async Task createcbbProvinces()
        {
            // Khởi tạo HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Gửi yêu cầu GET đến API
                    HttpResponseMessage response = await client.GetAsync("https://provinces.open-api.vn/api/");
                    string json = await response.Content.ReadAsStringAsync();

                    // Chuyển đổi dữ liệu JSON thành danh sách chuỗi (ví dụ, danh sách các tên tỉnh/thành phố)
                    _provinces = JsonConvert.DeserializeObject<List<Province>>(json);

                    // Thêm các mục từ danh sách vào ComboBoxEdit
                    foreach (var item in _provinces)
                    {
                        cbbProvinces.Properties.Items.Add(item.name);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private async Task createcbbDistricts()
        {
            // Xóa toàn bộ dữ liệu hiện có trong ComboBox
            cbbDistricts.Properties.Items.Clear();
            cbbDistricts.SelectedIndex = -1;
            cbbWards.Properties.Items.Clear();
            cbbWards.SelectedIndex = -1;

            // Khởi tạo HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Gửi yêu cầu GET đến API
                    HttpResponseMessage response = await client.GetAsync("https://provinces.open-api.vn/api/d/");
                    string json = await response.Content.ReadAsStringAsync();

                    // Chuyển đổi dữ liệu JSON thành danh sách chuỗi (ví dụ, danh sách các tên quận/huyện)
                    _districts = JsonConvert.DeserializeObject<List<Districts>>(json);

                    // Lấy province_code
                    string provinceValue = _provinces.FirstOrDefault(d => d.name == cbbProvinces.Text)?.code ?? string.Empty;

                    // Tìm tất cả các Districts có ProvinceCode tỉnh/ thành phố hiện tại
                    List<Districts> lstDistrict = _districts.Where(d => d.province_code == provinceValue).ToList();

                    // Thêm các mục từ danh sách vào ComboBoxEdit
                    foreach (var item in lstDistrict)
                    {
                        cbbDistricts.Properties.Items.Add(item.name);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private async Task createcbbWards()
        {
            // Xóa toàn bộ dữ liệu hiện có trong ComboBox
            cbbWards.Properties.Items.Clear();
            cbbWards.SelectedIndex = -1;

            // Khởi tạo HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Gửi yêu cầu GET đến API
                    HttpResponseMessage response = await client.GetAsync("https://provinces.open-api.vn/api/w/");
                    string json = await response.Content.ReadAsStringAsync();

                    // Chuyển đổi dữ liệu JSON thành danh sách chuỗi (ví dụ, danh sách các tên phường/xã)
                    _wards = JsonConvert.DeserializeObject<List<Wards>>(json);

                    // Lấy province_code
                    string districtValue = _districts.FirstOrDefault(d => d.name == cbbDistricts.Text)?.code ?? string.Empty;

                    // Tìm tất cả các Districts có ProvinceCode tỉnh/ thành phố hiện tại
                    List<Wards> lstWard = _wards.Where(d => d.district_code == districtValue).ToList();

                    // Thêm các mục từ danh sách vào ComboBoxEdit
                    foreach (var item in lstWard)
                    {
                        cbbWards.Properties.Items.Add(item.name);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private async void cbbProvinces_SelectedValueChanged(object sender, EventArgs e)
        {
            await createcbbDistricts();
        }

        private async void cbbDistricts_SelectedValueChanged(object sender, EventArgs e)
        {
            await createcbbWards();
        }

        private void cbbStockOutput_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbStockOutput.SelectedIndex != -1)
            {
                // Lấy giá trị đã chọn từ ComboBox
                int selectedIndex = _cbbStockOutputData.ElementAt(cbbStockOutput.SelectedIndex).Id;
                string selectedName = "cbbStockOutput";

                // Gọi sự kiện và truyền giá trị bằng cách sử dụng Tuple
                SelectedStockValueChanged?.Invoke(this, (selectedIndex, selectedName));
            }
        }

        public void clearExportPatientRequest()
        {
            // Row 1
            cbbStockOutput.SelectedIndex = -1;
            txtPatientCode.Text = string.Empty;
            txtPatientName.Text = string.Empty;
            txtDay.Text = string.Empty;
            txtMonth.Text = string.Empty;
            txtYear.Text = string.Empty;
            txtPhone.Text = string.Empty;

            // Row 2
            mmNote.Text = string.Empty;
            cbbGender.SelectedIndex = -1;
            cbbProvinces.SelectedIndex = -1;
            cbbDistricts.SelectedIndex = -1;
            cbbWards.SelectedIndex = -1;
        }

        public InventoryExportPatientRequest createInventoryExportPatientRequest()
        {
            InventoryExportPatientRequest inventoryExportPatientRequest = new InventoryExportPatientRequest();

            inventoryExportPatientRequest.StockId = _cbbStockOutputData.ElementAt(cbbStockOutput.SelectedIndex).Id;
            inventoryExportPatientRequest.Status = 3;
            inventoryExportPatientRequest.Note = mmNote.Text;
            inventoryExportPatientRequest.PatientNumber = txtPatientCode.Text; ;
            inventoryExportPatientRequest.PatientName = txtPatientName.Text; ;
            inventoryExportPatientRequest.DayBorn = txtDay.Text; ;
            inventoryExportPatientRequest.MonthBorn = txtMonth.Text; ;
            inventoryExportPatientRequest.YearBorn = txtYear.Text; ;
            inventoryExportPatientRequest.Phone = txtPhone.Text; ;
            inventoryExportPatientRequest.Gender = cbbGender.Text; ;
            inventoryExportPatientRequest.CityId = cbbProvinces.SelectedIndex;
            inventoryExportPatientRequest.DistrictId = cbbDistricts.SelectedIndex;
            inventoryExportPatientRequest.WardId = cbbWards.SelectedIndex;

            return inventoryExportPatientRequest;
        }

        private async void txtPatientCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPatientCode.Text))
            {
                string patientCode = txtPatientCode.Text;

                // Khởi tạo HttpClient
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        string url = $"{URL}api/Patient/find/{patientCode}";
                        HttpResponseMessage response = await client.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            // Đọc dữ liệu từ phản hồi API
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng Patient
                            _patient = JsonConvert.DeserializeObject<Patient>(apiResponse);

                            if (_patient == null)
                            {
                                txtPatientCode.Text = string.Empty;
                                Common.ShowMessageWarning("Không có bệnh nhân tương ứng");
                            }
                            else
                            {
                                // Row 1
                                txtPatientName.Text = _patient.Name;
                                txtDay.Text = _patient.DayBorn;
                                txtMonth.Text = _patient.MonthBorn;
                                txtYear.Text = _patient.YearBorn;
                                txtPhone.Text = _patient.Phone;
                                // Row 2
                                mmNote.Text = string.Empty;
                                cbbGender.SelectedIndex = _patient.Gender == "MALE" ? 0 : 1;
                                cbbProvinces.SelectedIndex = _patient.CityId != null ? _patient.CityId.Value : -1;
                                cbbDistricts.SelectedIndex = _patient.DistrictId != null ? _patient.DistrictId.Value : -1;
                                cbbWards.SelectedIndex = _patient.WardId != null ? _patient.WardId.Value : -1;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public void cbbStockOutputFocus()
        {
            cbbStockOutput.Focus();
        }

        public void txtPatientCodeFocus()
        {
            txtPatientCode.Focus();
        }
    }
}
