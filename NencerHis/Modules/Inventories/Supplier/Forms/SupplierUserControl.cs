using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using NencerHis.Modules.CommonManager;
using NencerHis.Modules.Inventories.Supplier.Models;
using NencerHis.Modules.Inventories.Supplier.Models.Request;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;

namespace NencerHis.Modules.Inventories.Supplier.Forms
{
    public partial class SupplierUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        // API url
        public const string URL = "http://localhost:5294/";
        public const string MANCC = "Mã nhà cung cấp";

        // List
        List<SupplierModel> _supplierData = new List<SupplierModel>();

        // Request
        SupplierRequest supplierRequest = new SupplierRequest();
        SupplierRequest infoSupplier = new SupplierRequest();

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

        public SupplierUserControl()
        {
            InitializeComponent();
            paginationControl.PageChanged += PaginationControl_PageChanged;
        }

        private async void PaginationControl_PageChanged(object sender, EventArgs e)
        {
            // Search data after change page
            await searchData(false);
        }

        private void SupplierUserControl_Load(object sender, EventArgs e)
        {
            Init();
            gridViewSupplier.OptionsBehavior.ReadOnly = true; // Chỉ đọc
            gridViewSupplier.OptionsBehavior.Editable = false; // Không cho phép chỉnh sửa
            gridViewSupplier.OptionsBehavior.AllowIncrementalSearch = true; // Cho phép tìm kiếm tăng dần
        }

        private async void Init()
        {
            // Get data init for gridview
            await searchData(false);

            // Set focus init
            txtCode.Focus();
            // Set FontStyle
            foreach (GridColumn objCol in gridViewSupplier.Columns)
            {
                objCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                objCol.AppearanceHeader.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }
        }

        private async Task searchData(bool isSearchClick)
        {
            // Init SearchSupplierModel
            SearchSupplierModel searchModel = new SearchSupplierModel();
            searchModel.Code = txtSearchCode.Text == MANCC ? string.Empty : txtSearchCode.Text;
            // Create SkipCount, MaxResultCount
            if (!isSearchClick || string.IsNullOrEmpty(searchModel.Code))
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

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            // After click button search
            await searchData(true);
        }

        private async Task getDataGrid(SearchSupplierModel searchModel)
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
                    HttpResponseMessage response = await client.PostAsync(URL + "api/Product/Supplier/List", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu từ phản hồi API
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng SupplierModel
                        _supplierData = JsonConvert.DeserializeObject<List<SupplierModel>>(apiResponse);

                        // Gán dữ liệu vào gridSupplier.DataSource
                        gridSupplier.DataSource = _supplierData;

                        // Code để ẩn một cột trong GridView
                        var totalCountColumn = gridViewSupplier.Columns["TotalCount"];
                        if (totalCountColumn != null)
                        {
                            totalCountColumn.Visible = false;
                        }

                        // Reload paging
                        if ((_supplierData != null && _supplierData.Any()))
                        {
                            totalCount = _supplierData[0].TotalCount;
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

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            // Create/ Update
            await create_Supplier();
        }

        private void btnAddAndPrint_Click(object sender, EventArgs e)
        {
            // Call func add/ print
            actionAdd_Print_Click();
        }

        private async Task actionAdd_Print_Click()
        {
            // Create/ Update
            await create_Supplier();

            // Print
            Common.ShowMessageSuccess("In thành công!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearDataHeader();
        }

        private void clearDataHeader()
        {
            // Set focus init
            txtCode.Focus();
            // Change name btnAdd
            btnAdd.Text = "Thêm mới (F2)";
            // Update mode
            isMode = "Add";
            // Reset data header
            txtCode.Text = string.Empty;
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtNote.Text = string.Empty;
            cbStatus.Checked = true;
        }

        private async Task create_Supplier()
        {
            // Validate
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                // Show alter warning
                Common.ShowMessageWarning("Mã nhà cung cấp là bắt buộc.");
                txtCode.Focus();
                return;
            }

            // Nếu là mode tạo mới
            if (isMode == "Add")
            {
                supplierRequest = new SupplierRequest
                {
                    Id = 0,
                    Code = txtCode.Text,
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    ContactPhone = txtPhone.Text,
                    ContactEmail = txtEmail.Text,
                    Description = txtNote.Text,
                    Status = cbStatus.Checked == true ? 1 : 0,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
            }
            // Nếu là mode update
            else
            {
                // Tạo đối tượng category để update
                supplierRequest = infoSupplier;

                // Update lại các giá trị trên header
                supplierRequest.Code = txtCode.Text;
                supplierRequest.Name = txtName.Text;
                supplierRequest.Address = txtAddress.Text;
                supplierRequest.ContactPhone = txtPhone.Text;
                supplierRequest.ContactEmail = txtEmail.Text;
                supplierRequest.Description = txtNote.Text;
                supplierRequest.Status = cbStatus.Checked == true ? 1 : 0;
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
                        apiUrl = URL + "api/Product/Supplier/Create";
                    }
                    else if (isMode == "Update")
                    {
                        apiUrl = URL + "api/Product/Supplier/Update";
                    }

                    // Convert data to Json
                    string json = JsonConvert.SerializeObject(supplierRequest);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Gửi yêu cầu GET đến API
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Deserialize chuỗi JSON thành một đối tượng JObject
                        JObject responseObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                        if ((string)responseObject["responseCode"] == "200")
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

        private void txtSearchCode_Click(object sender, EventArgs e)
        {
            if (txtSearchCode.Text == MANCC)
            {
                txtSearchCode.Text = string.Empty;
                txtSearchCode.Properties.Appearance.ForeColor = Color.Black;
            }
        }

        private void txtSearchCode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchCode.Text))
            {
                txtSearchCode.Text = MANCC;
                txtSearchCode.Properties.Appearance.ForeColor = SystemColors.GrayText;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F2:
                    // Gọi lưu ở đây
                    create_Supplier();
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

        private async void gridViewSupplier_DoubleClick(object sender, EventArgs e)
        {
            var isClickHeader = gridViewSupplier.CalcHitInfo(gridViewSupplier.GridControl.PointToClient(Control.MousePosition));
            if (!isClickHeader.InColumn)
            {
                var index = gridViewSupplier.FocusedRowHandle;
                if (index != -1)
                {
                    // Lấy FocusedRowHandle để biết dòng đang được chọn
                    int focusedRowHandle = gridViewSupplier.FocusedRowHandle;

                    // Lấy giá trị ID từ cột ID của dòng đang được chọn
                    object idValue = gridViewSupplier.GetRowCellValue(focusedRowHandle, "ID");

                    // Ép kiểu giá trị ID theo kiểu long
                    long supplierID = Convert.ToInt64(idValue);

                    // Khởi tạo HttpClient
                    using (HttpClient client = new HttpClient())
                    {
                        try
                        {
                            string url = $"{URL}api/Product/Supplier/Find/{supplierID}";
                            HttpResponseMessage response = await client.GetAsync(url);

                            if (response.IsSuccessStatusCode)
                            {
                                // Đọc dữ liệu từ phản hồi API
                                string apiResponse = await response.Content.ReadAsStringAsync();

                                // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng SupplierRequest
                                infoSupplier = JsonConvert.DeserializeObject<SupplierRequest>(apiResponse);

                                // Hiển thị các thông supplier để update
                                setInfoSupplierForHeader(infoSupplier);
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

        private void setInfoSupplierForHeader(SupplierRequest infoupplier)
        {
            // Change name btnAdd
            btnAdd.Text = "Cập nhật (F2)";
            // Update mode
            isMode = "Update";
            // Create data header
            txtCode.Text = infoupplier.Code;
            txtName.Text = infoupplier.Name;
            txtAddress.Text = infoupplier.Address;
            txtPhone.Text = infoupplier.ContactPhone;
            txtEmail.Text = infoupplier.ContactEmail;
            txtNote.Text = infoupplier.Description;
            cbStatus.Checked = infoupplier.Status == 1;
        }
    }
}
