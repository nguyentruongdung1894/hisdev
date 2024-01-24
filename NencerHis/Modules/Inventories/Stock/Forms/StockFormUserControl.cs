using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using NencerHis.Modules.CommonManager;
using NencerHis.Modules.Inventories.Stock.Models;
using NencerHis.Modules.Inventories.Stock.Models.Request;
using NencerHis.Modules.Reception.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;

namespace NencerHis.Modules.Inventories.Stock.Forms
{
    public partial class StockFormUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        // API url
        public const string URL = "http://localhost:5294/";
        public const string MAKHO = "Mã kho";

        // List
        List<ProductStocksModel> _productStocksData = new List<ProductStocksModel>();
        List<Department> _departmentData = new List<Department>();

        // Request
        ProductStocksRequest productStocksRequest = new ProductStocksRequest();
        ProductStocksRequest infoProductStocks = new ProductStocksRequest();

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

        public StockFormUserControl()
        {
            InitializeComponent();
            paginationControl.PageChanged += PaginationControl_PageChanged;
        }

        private async void PaginationControl_PageChanged(object sender, EventArgs e)
        {
            // Search data after change page
            await searchData(false);
        }

        private void StockFormUserControl_Load(object sender, EventArgs e)
        {
            Init();
            gridViewProductStocks.OptionsBehavior.ReadOnly = true; // Chỉ đọc
            gridViewProductStocks.OptionsBehavior.Editable = false; // Không cho phép chỉnh sửa
            gridViewProductStocks.OptionsBehavior.AllowIncrementalSearch = true; // Cho phép tìm kiếm tăng dần
        }

        private async void Init()
        {
            // Create combobox
            createcbbType();
            await createcbbDepartment();

            // Get data init for gridview
            await searchData(false);

            // Set focus init
            txtCode.Focus();

            // Set FontStyle
            foreach (GridColumn objCol in gridViewProductStocks.Columns)
            {
                objCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                objCol.AppearanceHeader.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }
        }

        private void createcbbType()
        {
            // Tạo danh sách các đối tượng Bảo hiểm và Tự nguyện
            List<ComboBoxModel> listComboBox = new List<ComboBoxModel>
            {
                new ComboBoxModel(0, "Kho nội trú"),
                new ComboBoxModel(1, "Kho ngoại trú")
            };
            // Thêm các tên của đối tượng vào ComboBoxEdit
            foreach (var cmb in listComboBox)
            {
                cbbType.Properties.Items.Add(cmb.Value);
            }
            // Chọn giá trị mặc định là blank
            cbbType.SelectedIndex = -1;
        }

        private async Task createcbbDepartment()
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
                            cbbDepartment.Properties.Items.Add(cmb.Name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private async Task searchData(bool isSearchClick)
        {
            // Init ProductStocksSearchModel
            ProductStocksSearchModel searchModel = new ProductStocksSearchModel();
            searchModel.Code = txtSearchCode.Text == MAKHO ? string.Empty : txtSearchCode.Text;
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

        private async Task getDataGrid(ProductStocksSearchModel searchModel)
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
                    HttpResponseMessage response = await client.PostAsync(URL + "api/Stock/List", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu từ phản hồi API
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng ProductStocksModel
                        _productStocksData = JsonConvert.DeserializeObject<List<ProductStocksModel>>(apiResponse);

                        // Gán dữ liệu vào gridProductBids.DataSource
                        gridProductStocks.DataSource = _productStocksData;

                        // Code để ẩn một cột trong GridView
                        var totalCountColumn = gridViewProductStocks.Columns["TotalCount"];
                        if (totalCountColumn != null)
                        {
                            totalCountColumn.Visible = false;
                        }

                        // Reload paging
                        if ((_productStocksData != null && _productStocksData.Any()))
                        {
                            totalCount = _productStocksData[0].TotalCount;
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

        private void txtSearchCode_Click(object sender, EventArgs e)
        {
            if (txtSearchCode.Text == MAKHO)
            {
                txtSearchCode.Text = string.Empty;
                txtSearchCode.Properties.Appearance.ForeColor = Color.Black;
            }
        }

        private void txtSearchCode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchCode.Text))
            {
                txtSearchCode.Text = MAKHO;
                txtSearchCode.Properties.Appearance.ForeColor = SystemColors.GrayText;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            // Create/ Update
            await create_ProductStocks();
        }

        private void btnAddAndPrint_Click(object sender, EventArgs e)
        {
            // Call func add/ print
            actionAdd_Print_Click();
        }

        private async Task actionAdd_Print_Click()
        {
            // Create/ Update
            await create_ProductStocks();

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
            // Row 1
            txtCode.Text = string.Empty;
            cbbType.SelectedIndex = -1;
            txtName.Text = string.Empty;
            // Row 2
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            cbbDepartment.SelectedIndex = -1;
            // Row 3
            txtNote.Text = string.Empty;
            txtOwner.Text = string.Empty;
            cbPaymentRequire.Checked = false;
            cbStatus.Checked = true;
        }

        private async Task create_ProductStocks()
        {
            // Validate
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                // Show alter warning
                Common.ShowMessageWarning("Mã kho là bắt buộc.");
                txtCode.Focus();
                return;
            }

            // Validate
            if (cbbType.SelectedIndex == -1)
            {
                // Show alter warning
                Common.ShowMessageWarning("Loại kho là bắt buộc.");
                cbbType.Focus();
                return;
            }

            // Validate
            if (string.IsNullOrEmpty(txtName.Text))
            {
                // Show alter warning
                Common.ShowMessageWarning("Tên kho là bắt buộc.");
                txtName.Focus();
                return;
            }

            // Nếu là mode tạo mới
            if (isMode == "Add")
            {
                productStocksRequest = new ProductStocksRequest
                {
                    Id = 0,
                    Code = txtCode.Text,
                    Type = cbbType.SelectedIndex,
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text,
                    DepartmentId = cbbDepartment.SelectedIndex != -1 ? _departmentData.ElementAt(cbbDepartment.SelectedIndex)?.Id : null,
                    PaymentRequire = cbPaymentRequire.Checked == true ? 1 : 0,
                    OwnerId = txtOwner.Text,
                    Description = txtNote.Text,
                    Status = cbStatus.Checked == true ? 1 : 0,
                };
            }
            // Nếu là mode update
            else
            {
                // Tạo đối tượng category để update
                productStocksRequest = infoProductStocks;

                // Update lại các giá trị trên header
                productStocksRequest.Code = txtCode.Text;
                productStocksRequest.Type = cbbType.SelectedIndex;
                productStocksRequest.Name = txtName.Text;
                productStocksRequest.Address = txtAddress.Text;
                productStocksRequest.Phone = txtPhone.Text;
                productStocksRequest.DepartmentId = cbbDepartment.SelectedIndex != -1 ? _departmentData.ElementAt(cbbDepartment.SelectedIndex)?.Id : null;
                productStocksRequest.PaymentRequire = cbPaymentRequire.Checked == true ? 1 : 0;
                productStocksRequest.OwnerId = txtOwner.Text;
                productStocksRequest.Description = txtNote.Text;
                productStocksRequest.Status = cbStatus.Checked == true ? 1 : 0;
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
                        apiUrl = URL + "api/Stock/Stock/Create";
                    }
                    else if (isMode == "Update")
                    {
                        apiUrl = URL + "api/Stock/Stock/Update";
                    }

                    // Convert data to Json
                    string json = JsonConvert.SerializeObject(productStocksRequest);
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

        private async void gridViewProductStocks_DoubleClick(object sender, EventArgs e)
        {
            var isClickHeader = gridViewProductStocks.CalcHitInfo(gridViewProductStocks.GridControl.PointToClient(Control.MousePosition));
            if (!isClickHeader.InColumn)
            {
                var index = gridViewProductStocks.FocusedRowHandle;
                if (index != -1)
                {
                    // Lấy FocusedRowHandle để biết dòng đang được chọn
                    int focusedRowHandle = gridViewProductStocks.FocusedRowHandle;

                    // Lấy giá trị ID từ cột ID của dòng đang được chọn
                    object idValue = gridViewProductStocks.GetRowCellValue(focusedRowHandle, "Id");

                    // Ép kiểu giá trị ID theo kiểu int
                    int id = Convert.ToInt32(idValue);

                    // Khởi tạo HttpClient
                    using (HttpClient client = new HttpClient())
                    {
                        try
                        {
                            string url = $"{URL}api/Stock/Stock/Find/{id}";
                            HttpResponseMessage response = await client.GetAsync(url);

                            if (response.IsSuccessStatusCode)
                            {
                                // Đọc dữ liệu từ phản hồi API
                                string apiResponse = await response.Content.ReadAsStringAsync();

                                // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng ProductStocksRequest
                                infoProductStocks = JsonConvert.DeserializeObject<ProductStocksRequest>(apiResponse);

                                // Hiển thị các thông productStocks để update
                                setInfoProductStocksForHeader(infoProductStocks);
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

        private void setInfoProductStocksForHeader(ProductStocksRequest infoupplier)
        {
            // Change name btnAdd
            btnAdd.Text = "Cập nhật (F2)";
            // Update mode
            isMode = "Update";
            // Create data header
            // Row 1
            txtCode.Text = infoupplier.Code;
            cbbType.SelectedIndex = infoupplier.Type;
            txtName.Text = infoupplier.Name;
            // Row 2
            txtAddress.Text = infoupplier.Address;
            txtPhone.Text = infoupplier.Phone;
            if (infoupplier.DepartmentId.HasValue && _departmentData?.Count > 0)
            {
                cbbDepartment.SelectedIndex = _departmentData.FindIndex(x => x.Id == infoupplier.DepartmentId.Value);
            }
            else
            {
                cbbDepartment.SelectedIndex = -1;
            }
            // Row 3
            txtNote.Text = infoupplier.Description;
            txtOwner.Text = infoupplier.OwnerId;
            cbPaymentRequire.Checked = infoupplier.PaymentRequire == 1;
            cbStatus.Checked = infoupplier.Status == 1;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F2:
                    // Gọi lưu ở đây
                    create_ProductStocks();
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
