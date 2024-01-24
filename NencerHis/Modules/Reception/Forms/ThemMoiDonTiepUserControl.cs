using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using NencerHis.Modules.CommonManager;
using NencerHis.Modules.Reception.Models;
using NencerHis.Modules.Reception.Models.Request;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using Checkin = NencerHis.Modules.Reception.Models.Request.Checkin;

namespace NencerHis.Modules.Reception.Forms
{
    public partial class ThemMoiDonTiepUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        // API url
        public const string URL = "http://localhost:5294/";
        public const string MABN = "Mã bệnh nhân";
        public const string SODT = "Số điện thoại";
        public const string SOCCCD = "Số CCCD";
        // Const
        private const string INSURANCE_VI = "Bảo hiểm";
        private const string INSURANCE_EN = "INSURANCE";
        private const string MEDICAL_FEE_VI = "Viện phí";
        private const string MEDICAL_FEE_EN = "MEDICAL_FEE";
        private const string REQUEST_VI = "Yêu cầu";
        private const string REQUEST_EN = "REQUEST";
        private const string FREE_VI = "Miễn phí";
        private const string FREE_EN = "FREE";
        private const string EXAMINATION_VI = "Khám bệnh";
        private const string EXAMINATION_EN = "EXAMINATION";
        private const string EMERGENCY_VI = "Cấp cứu";
        private const string EMERGENCY_EN = "EMERGENCY";

        // List
        List<PatientsModel> _patientsData = new List<PatientsModel>();
        List<Province> _provinces = new List<Province>();
        List<Districts> _districts = new List<Districts>();
        List<Wards> _wards = new List<Wards>();
        List<Department> _departmentData = new List<Department>();
        List<Room> _roomsData = new List<Room>();
        // Request
        CheckinRequest checkinRequest = new CheckinRequest();
        CheckinRequest _infoCheckIn = new CheckinRequest();
        // IsMode
        private string isMode = "Add";
        private int totalCount = 0;

        // khai báo biến
        public int TotalCount
        {
            get
            {
                return paginationControl.TotalCount;
            }
        }

        public ThemMoiDonTiepUserControl()
        {
            InitializeComponent();
            paginationControl.PageChanged += PaginationControl_PageChanged;
        }

        private async void PaginationControl_PageChanged(object sender, EventArgs e)
        {
            // Search data after change page
            await searchData(false);
        }

        private async void ThemMoiDonTiepUserControl_Load(object sender, EventArgs e)
        {
            Init();
            gridViewCheckIn.OptionsBehavior.ReadOnly = true; // Chỉ đọc
            gridViewCheckIn.OptionsBehavior.Editable = false; // Không cho phép chỉnh sửa
            gridViewCheckIn.OptionsBehavior.AllowIncrementalSearch = true; // Cho phép tìm kiếm tăng dần
        }

        private async void Init()
        {
            cbbquoctich.SelectedIndex = 0;
            dpkSearchDateFrom.DateTime = new DateTime(2000, 1, 1);
            dpkSearchDateTo.DateTime = DateTime.Now;
            dateTimeOffsetEdit1.DateTimeOffset = DateTimeOffset.Now;

            // Create combobox
            createcbbDoiTuong();
            createcbbGioiTinh();
            createcbbdkk();
            await createcbbTinhThanhPho();
            await createcomboQuanHuyen();
            await createcomboPhuongXa();
            await createcbbKhoaKham();
            await createcmdPhongKham();

            // Get data init for gridview
            await searchData(false);

            // Set FontStyle
            foreach (GridColumn objCol in gridViewCheckIn.Columns)
            {
                objCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                objCol.AppearanceHeader.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }
        }

        private void createcbbDoiTuong()
        {
            // Tạo danh sách các đối tượng Bảo hiểm và Tự nguyện
            List<ComboBoxModel> listComboBox = new List<ComboBoxModel>
            {
                new ComboBoxModel(0, MEDICAL_FEE_VI),
                new ComboBoxModel(1, REQUEST_VI),
                new ComboBoxModel(2, FREE_VI),
                new ComboBoxModel(3, INSURANCE_VI),
            };
            // Thêm các tên của đối tượng vào ComboBoxEdit
            foreach (var cmb in listComboBox)
            {
                cbbDoiTuong.Properties.Items.Add(cmb.Value);
            }
            // Chọn giá trị mặc định là bảo hiểm
            cbbDoiTuong.SelectedIndex = 3;
        }

        private void createcbbGioiTinh()
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
                cbbgioitinh.Properties.Items.Add(cmb.Value);
            }
            // Chọn giá trị mặc định là bảo hiểm
            cbbgioitinh.SelectedIndex = 0;
        }

        private void createcbbdkk()
        {
            // Tạo danh sách các đối tượng đăng ký khám
            List<ComboBoxModel> listComboBox = new List<ComboBoxModel>
            {
                new ComboBoxModel(0, EXAMINATION_VI),
                new ComboBoxModel(1, EMERGENCY_VI)
            };
            // Thêm các tên của đối tượng vào ComboBoxEdit
            foreach (var cmb in listComboBox)
            {
                cbbdkk.Properties.Items.Add(cmb.Value);
            }
            // Chọn giá trị mặc định là Khám bệnh
            cbbdkk.SelectedIndex = 0;
        }

        private async Task createcbbTinhThanhPho()
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
                        cbbTinhThanhPho.Properties.Items.Add(item.name);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private async Task createcbbKhoaKham()
        {
            // Khởi tạo HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Gửi yêu cầu GET đến API
                    HttpResponseMessage response = await client.GetAsync(URL + "api/Room/Department/GetAll");
                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu từ phản hồi API
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng Department
                        _departmentData = JsonConvert.DeserializeObject<List<Department>>(apiResponse);

                        // Thêm các tên của đối tượng vào ComboBoxEdit
                        foreach (var cmb in _departmentData)
                        {
                            cbbkhoakham.Properties.Items.Add(cmb.Name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private async Task getDataGrid(SearchModel searchModel)
        {
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
                    HttpResponseMessage response = await client.PostAsync(URL + "Checkin", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu từ phản hồi API
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng PatientsModel
                        _patientsData = JsonConvert.DeserializeObject<List<PatientsModel>>(apiResponse);
                        // lblSum.Text = "Tổng số: " + _patientsData[0].TotalCount + " dòng";

                        // Gọi hàm ánh xạ giá trị enum thành chuỗi tương ứng
                        foreach (var item in _patientsData)
                        {
                            item.DoiTuong = GetServiceObjectDescription(item.DoiTuong);
                        }

                        // Gán dữ liệu vào gridCheckin.DataSource
                        gridCheckin.DataSource = _patientsData;

                        // Code để ẩn một cột trong GridView
                        var checkInIDColumn = gridViewCheckIn.Columns["CheckInID"];
                        var totalCountColumn = gridViewCheckIn.Columns["TotalCount"];
                        if (checkInIDColumn != null)
                        {
                            checkInIDColumn.Visible = false;
                        }
                        if (totalCountColumn != null)
                        {
                            totalCountColumn.Visible = false;
                        }

                        // Reload paging
                        if ((_patientsData != null && _patientsData.Any()))
                        {
                            totalCount = _patientsData[0].TotalCount;
                        }
                        paginationControl.RefreshPaging(totalCount);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // Hàm ánh xạ giá trị enum thành chuỗi tương ứng
        private string GetServiceObjectDescription(string serviceObject)
        {
            switch (serviceObject)
            {
                case INSURANCE_EN:
                    return INSURANCE_VI;
                case MEDICAL_FEE_EN:
                    return MEDICAL_FEE_VI;
                case REQUEST_EN:
                    return REQUEST_VI;
                case FREE_EN:
                    return FREE_VI;
                default:
                    return string.Empty;
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            // After click button search
            await searchData(true);
        }

        private async Task searchData(bool isSearchClick)
        {
            // Init SearchModel
            SearchModel searchModel = new SearchModel();
            searchModel.MaBenhNhan = txtSearchMaBN.Text == MABN ? string.Empty : txtSearchMaBN.Text;
            searchModel.SoDT = txtSearchSoDT.Text == SODT ? string.Empty : txtSearchSoDT.Text;
            searchModel.SoCCCD = txtSearchSoCCCD.Text == SOCCCD ? string.Empty : txtSearchSoCCCD.Text;
            searchModel.FromDate = dpkSearchDateFrom.Text;
            searchModel.ToDate = dpkSearchDateTo.Text;
            // Create SkipCount, MaxResultCount
            if (!isSearchClick || (string.IsNullOrEmpty(searchModel.MaBenhNhan) &&
                                   string.IsNullOrEmpty(searchModel.SoDT) &&
                                   string.IsNullOrEmpty(searchModel.SoCCCD) &&
                                   searchModel.FromDate.Equals("1/1/2000") &&
                                   searchModel.ToDate.Equals(DateTime.Now.ToString("M/d/yyyy"))))
            {
                searchModel.SkipCount = paginationControl.SkipCount;
                searchModel.MaxResultCount = paginationControl.MaxResultCount;
            }
            else
            {
                searchModel.SkipCount = 0;
                searchModel.MaxResultCount = totalCount;
            }

            SplashScreenManager.ShowForm(null, typeof(frmStartApp), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Xin vui lòng chờ...");
            // Call pai search
            await getDataGrid(searchModel);
            SplashScreenManager.CloseForm();
        }


        private void txtSearchMaBN_Click(object sender, EventArgs e)
        {
            if (txtSearchMaBN.Text == MABN)
            {
                txtSearchMaBN.Text = string.Empty;
                txtSearchMaBN.Properties.Appearance.ForeColor = Color.Black;
            }
        }

        private void txtSearchMaBN_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchMaBN.Text))
            {
                txtSearchMaBN.Text = MABN;
                txtSearchMaBN.Properties.Appearance.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtSearchSoDT_Click(object sender, EventArgs e)
        {
            if (txtSearchSoDT.Text == SODT)
            {
                txtSearchSoDT.Text = string.Empty;
                txtSearchSoDT.Properties.Appearance.ForeColor = Color.Black;
            }
        }

        private void txtSearchSoDT_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchSoDT.Text))
            {
                txtSearchSoDT.Text = SODT;
                txtSearchSoDT.Properties.Appearance.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtSearchSoCCCD_Click(object sender, EventArgs e)
        {
            if (txtSearchSoCCCD.Text == SOCCCD)
            {
                txtSearchSoCCCD.Text = string.Empty;
                txtSearchSoCCCD.Properties.Appearance.ForeColor = Color.Black;
            }
        }

        private void txtSearchSoCCCD_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchSoCCCD.Text))
            {
                txtSearchSoCCCD.Text = SOCCCD;
                txtSearchSoCCCD.Properties.Appearance.ForeColor = SystemColors.GrayText;
            }
        }

        private async void cbbTinhThanhPho_SelectedValueChanged(object sender, EventArgs e)
        {
            await createcomboQuanHuyen();
        }

        private async Task createcomboQuanHuyen()
        {
            // Xóa toàn bộ dữ liệu hiện có trong ComboBox
            comboQuanHuyen.Properties.Items.Clear();
            comboQuanHuyen.SelectedIndex = -1;
            comboPhuongXa.Properties.Items.Clear();
            comboPhuongXa.SelectedIndex = -1;

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
                    string provinceValue = _provinces.FirstOrDefault(d => d.name == cbbTinhThanhPho.Text)?.code ?? string.Empty;

                    // Tìm tất cả các Districts có ProvinceCode tỉnh/ thành phố hiện tại
                    List<Districts> lstDistrict = _districts.Where(d => d.province_code == provinceValue).ToList();

                    // Thêm các mục từ danh sách vào ComboBoxEdit
                    foreach (var item in lstDistrict)
                    {
                        comboQuanHuyen.Properties.Items.Add(item.name);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private async void comboQuanHuyen_SelectedValueChanged(object sender, EventArgs e)
        {
            await createcomboPhuongXa();
        }

        private async Task createcomboPhuongXa()
        {
            // Xóa toàn bộ dữ liệu hiện có trong ComboBox
            comboPhuongXa.Properties.Items.Clear();
            comboPhuongXa.SelectedIndex = -1;

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
                    string districtValue = _districts.FirstOrDefault(d => d.name == comboQuanHuyen.Text)?.code ?? string.Empty;

                    // Tìm tất cả các Districts có ProvinceCode tỉnh/ thành phố hiện tại
                    List<Wards> lstWard = _wards.Where(d => d.district_code == districtValue).ToList();

                    // Thêm các mục từ danh sách vào ComboBoxEdit
                    foreach (var item in lstWard)
                    {
                        comboPhuongXa.Properties.Items.Add(item.name);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private async void cbbkhoakham_SelectedValueChanged(object sender, EventArgs e)
        {
            await createcmdPhongKham();
        }

        private async Task createcmdPhongKham()
        {
            // Xóa toàn bộ dữ liệu hiện có trong ComboBox
            cmdPhongKham.Properties.Items.Clear();
            cmdPhongKham.SelectedIndex = -1;

            // Khởi tạo HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Bất kỳ giá trị nào bạn muốn truyền
                    int departmentId = _departmentData.FirstOrDefault(d => d.Name == cbbkhoakham.Text)?.Id ?? -1;

                    // Gửi yêu cầu GET đến API
                    string apiUrl = $"{URL}api/Room/GetRoomByDepartment/{departmentId}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu từ phản hồi API
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng PatientsModel
                        _roomsData = JsonConvert.DeserializeObject<List<Room>>(apiResponse);

                        // Thêm các tên của đối tượng vào ComboBoxEdit
                        foreach (var cmb in _roomsData)
                        {
                            cmdPhongKham.Properties.Items.Add(cmb.Name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            // Create/ Update
            await create_Checkin();
        }

        private Checkin createCheckin()
        {
            string serviceObject = string.Empty;
            if (cbbDoiTuong.Text.Equals(MEDICAL_FEE_VI))
            {
                serviceObject = MEDICAL_FEE_EN;
            }
            else if (cbbDoiTuong.Text.Equals(REQUEST_VI))
            {
                serviceObject = REQUEST_EN;
            }
            else if (cbbDoiTuong.Text.Equals(FREE_VI))
            {
                serviceObject = FREE_EN;
            }
            else
            {
                serviceObject = INSURANCE_EN;
            }
            // Tạo đối tượng Checkin
            return new Checkin
            {
                // Auto
                Id = 0,
                // After register patient
                PatientId = 0,
                PatientNumber = string.Empty,
                ServiceObject = serviceObject,
                Type = cbbdkk.Text == EXAMINATION_VI ? EXAMINATION_EN : EMERGENCY_EN,
                // Backend xử lý
                CheckinNumber = 0,
                Priority = chkPrioritize.Checked != true ? 0 : 1,
                DepartmentId = _departmentData.FirstOrDefault(d => d.Name == cbbkhoakham.Text)?.Id ?? -1,
                RoomId = _roomsData.FirstOrDefault(d => d.Name == cmdPhongKham.Text)?.Id ?? -1,
                RoomCode = cmdPhongKham.Text,
                // K có
                DoctorId = 0,
                DoctorName = string.Empty,
                Reason = txtReason.Text,
                Status = string.Empty,
                ChamberId = 0,
                BedId = 0,
                ServiceId = 0,
                CheckinTime = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }

        private Patient createPatient()
        {
            // Tạo đối tượng Patient
            return new Patient
            {
                Id = 0,
                Name = txtName.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                IdCardType = "CCCD",
                PatientNumber = txtPatientNumber.Text,
                Credit = 0,
                Image = string.Empty,
                IdCard = txtIdCardType.Text,
                IssueDate = DateTime.Now,
                Type = cbbdkk.Text == EXAMINATION_VI ? EXAMINATION_EN : EMERGENCY_EN,
                Gender = cbbgioitinh.Text,
                DayBorn = txtDayBorn.Text,
                MonthBorn = txtMonthBorn.Text,
                YearBorn = txtYearBorn.Text,
                Birthday = DateTime.Now,
                Lang = "vi",
                CityId = int.Parse(_provinces.FirstOrDefault(d => d.name == cbbTinhThanhPho.Text)?.code ?? "-1"),
                DistrictId = int.Parse(_districts.FirstOrDefault(d => d.name == comboQuanHuyen.Text)?.code ?? "-1"),
                WardId = int.Parse(_wards.FirstOrDefault(d => d.name == comboPhuongXa.Text)?.code ?? "-1"),
                Address = txtAddress.Text,
                CountryCode = cbbquoctich.Text,
                Nationality = cbbquoctich.Text,
                PostCode = cbbquoctich.Text,
                PartnerId = 0,
                Ethnic = cbbDanToc.Text,
                DetailObject = string.Empty,
                JobTitle = txtJob.Text,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }

        private PatientDetail createPatientDetail()
        {
            // Tạo đối tượng PatientDetail
            return new PatientDetail
            {
                Id = 0,
                PatientId = 0,
                Address = string.Empty,
                AddressWorkplace = string.Empty,
                Married = 0,
                Children = 0,
                Description = string.Empty,
                Image = string.Empty,
                JobTitle = string.Empty,
                Company = string.Empty,
                Education = string.Empty,
                Prehistoric = string.Empty,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }

        private void btnAddAndPrint_Click(object sender, EventArgs e)
        {
            // Call func add/ print
            actionAdd_Print_Click();
        }

        private async Task actionAdd_Print_Click()
        {
            // Create/ Update
            await create_Checkin();

            // Print
            MessageBox.Show("Bạn có muốn in không?", Properties.NencerResource.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearDataHeader();
        }

        private Checkin createModeUpdateCheckin()
        {
            string serviceObject = string.Empty;
            if (cbbDoiTuong.Text.Equals(MEDICAL_FEE_VI))
            {
                serviceObject = MEDICAL_FEE_EN;
            }
            else if (cbbDoiTuong.Text.Equals(REQUEST_VI))
            {
                serviceObject = REQUEST_EN;
            }
            else if (cbbDoiTuong.Text.Equals(FREE_VI))
            {
                serviceObject = FREE_EN;
            }
            else
            {
                serviceObject = INSURANCE_EN;
            }
            Checkin _checkin = _infoCheckIn.Checkin;
            _checkin.ServiceObject = serviceObject;
            _checkin.Type = cbbdkk.Text == EXAMINATION_VI ? EXAMINATION_EN : EMERGENCY_EN;
            _checkin.Priority = chkPrioritize.Checked != true ? 0 : 1;
            _checkin.CheckinTime = DateTime.Now;
            _checkin.Reason = txtReason.Text;
            _checkin.DepartmentId = _departmentData.FirstOrDefault(d => d.Name == cbbkhoakham.Text)?.Id ?? -1;
            _checkin.RoomId = _roomsData.FirstOrDefault(d => d.Name == cmdPhongKham.Text)?.Id ?? -1;
            _checkin.RoomCode = _roomsData.FirstOrDefault(d => d.Name == cmdPhongKham.Text)?.Code ?? string.Empty;

            return _checkin;
        }

        private Patient createModeUpdatePatient()
        {
            Patient _patient = _infoCheckIn.Patient;
            _patient.Phone = txtPhone.Text;
            _patient.IdCardType = "CCCD";
            _patient.PatientNumber = txtPatientNumber.Text;
            _patient.Name = txtName.Text;
            _patient.Type = cbbdkk.Text == EXAMINATION_VI ? EXAMINATION_EN : EMERGENCY_EN;
            _patient.Gender = cbbgioitinh.Text;
            _patient.DayBorn = txtDayBorn.Text;
            _patient.MonthBorn = txtMonthBorn.Text;
            _patient.YearBorn = txtYearBorn.Text;
            _patient.YearBorn = txtYearBorn.Text;
            _patient.CityId = int.Parse(_provinces.FirstOrDefault(d => d.name == cbbTinhThanhPho.Text)?.code ?? "-1");
            _patient.DistrictId = int.Parse(_districts.FirstOrDefault(d => d.name == comboQuanHuyen.Text)?.code ?? "-1");
            _patient.WardId = int.Parse(_wards.FirstOrDefault(d => d.name == comboPhuongXa.Text)?.code ?? "-1");
            _patient.Address = txtAddress.Text;
            _patient.JobTitle = txtJob.Text;
            _patient.Ethnic = cbbDanToc.Text;
            _patient.CountryCode = cbbquoctich.Text;
            _patient.Email = txtEmail.Text;

            return _patient;
        }

        private PatientInsuranceCard createPatientInsuranceCard()
        {
            string dateFrom = $"{txtFromYear}-{txtFromMonth}-{txtFromDay}";
            string dateTo = $"{txtToDay}-{txtToMonth}-{txtToYear}";
            DateTime dateOnlyFrom;
            DateTime dateOnlyTo;
            DateTime.TryParse(dateFrom, out dateOnlyFrom);
            DateTime.TryParse(dateTo, out dateOnlyTo);
            // Tạo đối tượng thẻ
            return new PatientInsuranceCard
            {
                Id = 0,
                PatientId = 0,
                FullNumber = txtObjectCode.Text + " " + txtBenefitsCode.Text + " " + txtCityCode.Text + " " + txtBHXHCode.Text,
                SubjectCode = "123",
                BenifitCode = "123",
                CityCode = "123",
                FromDate = dateOnlyFrom,
                ExpirationDate = dateOnlyTo,
                InsuranceAddress = txtAddressCard.Text,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }

        private PatientDetail createModeUpdatePatientDetail()
        {
            PatientDetail _patientDetail = _infoCheckIn.PatientDetail;
            return _patientDetail;
        }

        private async Task create_Checkin()
        {
            // Nếu là mode tạo mới
            if (isMode == "Add")
            {
                // Tạo đối tượng Checkin
                Checkin checkin = createCheckin();

                // Tạo đối tượng Patient
                Patient patient = createPatient();

                // Tạo đối tượng PatientDetail
                PatientDetail patientDetail = createPatientDetail();

                // Khởi tạo các đối tượng cho phép null
                PatientInsuranceCard patientInsuranceCard = new PatientInsuranceCard();
                if (cbbDoiTuong.Text.Equals(INSURANCE_VI))
                {
                    patientInsuranceCard = createPatientInsuranceCard();
                }
                else
                {
                    patientInsuranceCard = null;
                }
                List<PatientPrehistoric> lstPatientPrehistoric = new List<PatientPrehistoric>();
                List<PatientRelation> lstPatientRelation = new List<PatientRelation>();

                checkinRequest = new CheckinRequest
                {
                    Checkin = checkin,
                    Patient = patient,
                    PatientDetail = patientDetail,
                    PatientInsuranceCard = patientInsuranceCard,
                    PatientPrehistoric = null,
                    PatientRelation = null,
                };
            }
            // Nếu là mode update
            else
            {
                // Tạo đối tượng Checkin
                Checkin checkin = createModeUpdateCheckin();

                // Tạo đối tượng Patient
                Patient patient = createModeUpdatePatient();

                // Tạo đối tượng PatientDetail
                PatientDetail patientDetail = createModeUpdatePatientDetail();

                // Khởi tạo các đối tượng cho phép null
                PatientInsuranceCard patientInsuranceCard = new PatientInsuranceCard();
                if (cbbDoiTuong.Text.Equals(INSURANCE_VI))
                {
                    patientInsuranceCard = createPatientInsuranceCard();
                }
                else
                {
                    patientInsuranceCard = null;
                }
                List<PatientPrehistoric> lstPatientPrehistoric = new List<PatientPrehistoric>();
                List<PatientRelation> lstPatientRelation = new List<PatientRelation>();

                checkinRequest = new CheckinRequest
                {
                    Checkin = checkin,
                    Patient = patient,
                    PatientDetail = patientDetail,
                    PatientInsuranceCard = patientInsuranceCard,
                    PatientPrehistoric = null,
                    PatientRelation = null,
                };
            }

            // Khởi tạo HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Init Url
                    string apiUrl = string.Empty;
                    // If mode = Add, Create : Update
                    if (isMode == "Add")
                    {
                        apiUrl = URL + "api/Checkin/Create";
                    }
                    else if (isMode == "Update")
                    {
                        apiUrl = URL + "api/Checkin/Update";
                    }

                    // Convert data to Json
                    string json = JsonConvert.SerializeObject(checkinRequest);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Gửi yêu cầu GET đến API
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Deserialize chuỗi JSON thành một đối tượng JObject
                        JObject responseObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                        if ((string)responseObject["responseCode"] == "00")
                        {
                            // Update message
                            string mes = string.Empty;
                            if (isMode == "Add")
                            {
                                mes = "Đăng ký thành công.";
                            }
                            else if (isMode == "Update")
                            {
                                mes = "Cập nhật thành công.";
                            }
                            // Show alter success
                            Common.ShowMessageSuccess(mes);

                            // Init after register
                            clearDataHeader();

                            // Search data after register succ
                            await searchData(false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void cbbDoiTuong_SelectedValueChanged(object sender, EventArgs e)
        {
            groupBHYT.Enabled = cbbDoiTuong.Text.Equals(INSURANCE_VI);
        }

        private async void gridViewCheckIn_DoubleClick(object sender, EventArgs e)
        {
            var isClickHeader = gridViewCheckIn.CalcHitInfo(gridViewCheckIn.GridControl.PointToClient(Control.MousePosition));
            if (!isClickHeader.InColumn)
            {
                var index = gridViewCheckIn.FocusedRowHandle;
                if (index != -1)
                {
                    // Lấy FocusedRowHandle để biết dòng đang được chọn
                    int focusedRowHandle = gridViewCheckIn.FocusedRowHandle;

                    // Lấy giá trị ID từ cột ID của dòng đang được chọn
                    object idValue = gridViewCheckIn.GetRowCellValue(focusedRowHandle, "CheckInID");

                    // Ép kiểu giá trị ID theo kiểu long
                    long checkInID = Convert.ToInt64(idValue);

                    // Khởi tạo HttpClient
                    using (HttpClient client = new HttpClient())
                    {
                        try
                        {
                            string url = $"{URL}GetInfoCheckInById/{checkInID}";
                            HttpResponseMessage response = await client.GetAsync(url);

                            if (response.IsSuccessStatusCode)
                            {
                                // Đọc dữ liệu từ phản hồi API
                                string apiResponse = await response.Content.ReadAsStringAsync();

                                // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng CheckinRequest
                                _infoCheckIn = JsonConvert.DeserializeObject<CheckinRequest>(apiResponse);

                                // Hiển thị các thông checkin để update
                                setInfoCheckinForHeader(_infoCheckIn);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }

        private async void setInfoCheckinForHeader(CheckinRequest infoCheckIn)
        {
            // Change name btnAdd
            btnAdd.Text = "Cập nhật (F2)";
            // Update mode
            isMode = "Update";
            // Row 1
            string serviceObject = string.Empty;
            if (infoCheckIn.Checkin.ServiceObject.Equals(MEDICAL_FEE_EN))
            {
                serviceObject = MEDICAL_FEE_VI;
            }
            else if (infoCheckIn.Checkin.ServiceObject.Equals(REQUEST_EN))
            {
                serviceObject = REQUEST_VI;
            }
            else if (infoCheckIn.Checkin.ServiceObject.Equals(FREE_EN))
            {
                serviceObject = FREE_VI;
            }
            else
            {
                serviceObject = INSURANCE_VI;
            }
            cbbDoiTuong.Text = serviceObject;
            txtPhone.Text = infoCheckIn.Patient.Phone;
            txtIdCardType.Text = infoCheckIn.Patient.IdCard;
            txtKCB.Text = "Fix cung";
            // Row 2
            txtPatientNumber.Text = infoCheckIn.Patient.PatientNumber;
            txtName.Text = infoCheckIn.Patient.Name;
            cbbgioitinh.Text = infoCheckIn.Patient.Gender;
            txtDayBorn.Text = infoCheckIn.Patient.DayBorn;
            txtMonthBorn.Text = infoCheckIn.Patient.MonthBorn;
            txtYearBorn.Text = infoCheckIn.Patient.YearBorn;
            // Row 3
            cbbTinhThanhPho.Text = _provinces.FirstOrDefault(x => x.code == infoCheckIn.Patient.CityId.ToString())?.name ?? string.Empty;
            comboQuanHuyen.Text = _districts.FirstOrDefault(x => x.code == infoCheckIn.Patient.DistrictId.ToString())?.name ?? string.Empty;
            comboPhuongXa.Text = _wards.FirstOrDefault(x => x.code == infoCheckIn.Patient.WardId.ToString())?.name ?? string.Empty;
            txtTTQHPX.Text = cbbTinhThanhPho.Text + " - " + comboQuanHuyen.Text + " - " + comboPhuongXa.Text;
            // Row 4
            txtAddress.Text = infoCheckIn.Patient.Address;
            txtJob.Text = infoCheckIn.Patient.JobTitle;
            cbbDanToc.Text = infoCheckIn.Patient.Ethnic;
            // Row 5
            cbbquoctich.Text = infoCheckIn.Patient.CountryCode;
            txtEmail.Text = infoCheckIn.Patient.Email;
            txtWorkplace.Text = "Fix cung";
            txtPosition.Text = "Fix cung";
            // Row 6
            cbbdkk.Text = infoCheckIn.Checkin.Type == EXAMINATION_EN ? EXAMINATION_VI : EMERGENCY_VI;
            dateTimeOffsetEdit1.Text = DateTime.Now.ToString();
            txtReason.Text = infoCheckIn.Checkin.Reason;
            // Row 7
            cbbkhoakham.Text = _departmentData.FirstOrDefault(x => x.Id == infoCheckIn.Checkin.DepartmentId)?.Name ?? string.Empty;
            await Task.Delay(100);
            cmdPhongKham.Text = _roomsData.FirstOrDefault(x => x.Id == infoCheckIn.Checkin.RoomId)?.Name ?? string.Empty;
            // Row 8
            chkPrioritize.Checked = infoCheckIn.Checkin.Priority == 0 ? false : true;
            // BHYT
            groupBHYT.Enabled = cbbDoiTuong.Text.Equals(INSURANCE_VI);
            if (infoCheckIn.Checkin.ServiceObject.Equals(INSURANCE_EN))
            {
                if (infoCheckIn.PatientInsuranceCard != null)
                {
                    if (!string.IsNullOrEmpty(infoCheckIn.PatientInsuranceCard.FullNumber))
                    {
                        string[] parts = infoCheckIn.PatientInsuranceCard.FullNumber.Split(' ');

                        txtObjectCode.Text = parts[0];
                        txtBenefitsCode.Text = parts[1];
                        txtCityCode.Text = parts[2];
                        txtBHXHCode.Text = parts[3];
                    }
                }
            }
            else
            {
                clearInsurance();
            }
        }

        private void clearDataHeader()
        {
            // Change name btnAdd
            btnAdd.Text = "Thêm mới (F2)";
            // Update mode
            isMode = "Add";
            // Row 1
            cbbDoiTuong.SelectedIndex = 3;
            txtPhone.Text = string.Empty;
            txtIdCardType.Text = string.Empty;
            txtKCB.Text = string.Empty;
            // Row 2
            txtPatientNumber.Text = string.Empty;
            txtName.Text = string.Empty;
            cbbgioitinh.SelectedIndex = 0;
            txtDayBorn.Text = string.Empty;
            txtMonthBorn.Text = string.Empty;
            txtYearBorn.Text = string.Empty;
            // Row 3
            txtTTQHPX.Text = string.Empty;
            cbbTinhThanhPho.SelectedIndex = -1;
            comboQuanHuyen.SelectedIndex = -1;
            comboPhuongXa.SelectedIndex = -1;
            // Row 4
            txtAddress.Text = string.Empty;
            txtJob.Text = "Trẻ em dưới 6 tuổi đi học";
            cbbDanToc.Text = "Kinh";
            // Row 5
            cbbquoctich.SelectedIndex = 0;
            txtEmail.Text = string.Empty;
            txtWorkplace.Text = string.Empty;
            txtPosition.Text = string.Empty;
            // Row 6
            cbbdkk.SelectedIndex = 0;
            dateTimeOffsetEdit1.Text = DateTime.Now.ToString();
            txtReason.Text = string.Empty;
            // Row 7
            cbbkhoakham.SelectedIndex = -1;
            cmdPhongKham.SelectedIndex = -1;
            // Row 8
            chkPrioritize.Checked = false;
            // BHYT
            groupBHYT.Enabled = true;
            if (cbbDoiTuong.Text.Equals(INSURANCE_VI))
            {
                clearInsurance();
            }
        }

        private void clearInsurance()
        {
            // Row 1
            txtObjectCode.Text = string.Empty;
            txtBenefitsCode.Text = string.Empty;
            txtCityCode.Text = string.Empty;
            txtBHXHCode.Text = string.Empty;
            // Row 2
            txtCodeKCBBD.Text = string.Empty;
            txtNameKCBBD.Text = string.Empty;
            // Row 3
            txtFromDay.Text = string.Empty;
            txtFromMonth.Text = string.Empty;
            txtFromYear.Text = string.Empty;
            txtToDay.Text = string.Empty;
            txtToMonth.Text = string.Empty;
            txtToYear.Text = string.Empty;
            // Row 4
            txtAddressCard.Text = string.Empty;
            cbbPlace.SelectedIndex = -1;
            // Row 5
            txtLineKCB.Text = string.Empty;
            lblRate.Text = "80%";
            // Row 6
            txtExemptionDay.Text = string.Empty;
            txtExemptionMonth.Text = string.Empty;
            txtExemptionYear.Text = string.Empty;
            txt5NDay.Text = string.Empty;
            txt5NMonth.Text = string.Empty;
            txt5NYear.Text = string.Empty;
            // Row 7
            rbtHavingCard.Checked = false;
            cbDebt.Checked = false;
            // Row 8
            rbtNotCard.Checked = false;
            cbGCN.Checked = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F2:
                    // Gọi lưu ở đây
                    create_Checkin();
                    return true;
                case Keys.F3:
                    // Gọi lưu và in ở đây
                    actionAdd_Print_Click();
                    return true;
                case Keys.F4:
                    // Gọi hàm hủy bỏ ở đây
                    clearDataHeader();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
