using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using NencerHis.Modules.CommonManager;
using NencerHis.Modules.Inventories.Category.Models;
using NencerHis.Modules.Inventories.Category.Models.Request;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;

namespace NencerHis.Modules.Inventories.Category.Forms
{
    public partial class CategoryUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        // API url
        public const string URL = "http://localhost:5294/";
        public const string MADM = "Mã danh mục";

        // List
        List<CategoryModel> _categoryData = new List<CategoryModel>();

        // Request
        CategoryRequest categoryRequest = new CategoryRequest();
        CategoryRequest infoCategory = new CategoryRequest();

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

        public CategoryUserControl()
        {
            InitializeComponent();
            paginationControl.PageChanged += PaginationControl_PageChanged;
        }

        private async void PaginationControl_PageChanged(object sender, EventArgs e)
        {
            // Search data after change page
            await searchData(false);
        }

        private void CategoryUserControl_Load(object sender, EventArgs e)
        {
            Init();
            gridViewCategory.OptionsBehavior.ReadOnly = true; // Chỉ đọc
            gridViewCategory.OptionsBehavior.Editable = false; // Không cho phép chỉnh sửa
            gridViewCategory.OptionsBehavior.AllowIncrementalSearch = true; // Cho phép tìm kiếm tăng dần
        }

        private async void Init()
        {
            // Get data init for gridview
            await searchData(false);

            // Set focus init
            txtCode.Focus();
            // Set FontStyle
            foreach (GridColumn objCol in gridViewCategory.Columns)
            {
                objCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                objCol.AppearanceHeader.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }
        }

        private async Task searchData(bool isSearchClick)
        {
            // Init SearchCategoryModel
            SearchCategoryModel searchModel = new SearchCategoryModel();
            searchModel.Slug = txtSearchCode.Text == MADM ? string.Empty : txtSearchCode.Text;
            // Create SkipCount, MaxResultCount
            if (!isSearchClick || string.IsNullOrEmpty(searchModel.Slug))
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

        private async Task getDataGrid(SearchCategoryModel searchModel)
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
                    HttpResponseMessage response = await client.PostAsync(URL + "api/Product/Cate/List", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu từ phản hồi API
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng CategoryModel
                        _categoryData = JsonConvert.DeserializeObject<List<CategoryModel>>(apiResponse);

                        // Gán dữ liệu vào gridCategory.DataSource
                        gridCategory.DataSource = _categoryData;

                        // Code để ẩn một cột trong GridView
                        var totalCountColumn = gridViewCategory.Columns["TotalCount"];
                        if (totalCountColumn != null)
                        {
                            totalCountColumn.Visible = false;
                        }

                        // Reload paging
                        if ((_categoryData != null && _categoryData.Any()))
                        {
                            totalCount = _categoryData[0].TotalCount;
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
            await create_Category();
        }

        private async void btnAddAndPrint_Click(object sender, EventArgs e)
        {
            // Call func add/ print
            actionAdd_Print_Click();
        }

        private async Task actionAdd_Print_Click()
        {
            // Create/ Update
            await create_Category();

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
            txtArea.Text = string.Empty;
            cbStatus.Checked = true;
            txtNote.Text = string.Empty;
        }

        private async Task create_Category()
        {
            // Validate
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                // Show alter warning
                Common.ShowMessageWarning("Mã danh mục là bắt buộc.");
                txtCode.Focus();
                return;
            }

            // Nếu là mode tạo mới
            if (isMode == "Add")
            {
                categoryRequest = new CategoryRequest
                {
                    Id = 0,
                    Name = txtName.Text,
                    Slug = txtCode.Text,
                    Area = txtArea.Text,
                    Description = txtNote.Text,
                    Sort = 0,
                    Image = string.Empty,
                    Status = cbStatus.Checked == true ? 1 : 0,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
            }
            // Nếu là mode update
            else
            {
                // Tạo đối tượng category để update
                categoryRequest = infoCategory;

                // Update lại các giá trị trên header
                categoryRequest.Name = txtName.Text;
                categoryRequest.Slug = txtCode.Text;
                categoryRequest.Area = txtArea.Text;
                categoryRequest.Description = txtNote.Text;
                categoryRequest.Status = cbStatus.Checked == true ? 1 : 0;
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
                        apiUrl = URL + "api/Product/Cate/Create";
                    }
                    else if (isMode == "Update")
                    {
                        apiUrl = URL + "api/Product/Cate/Update";
                    }

                    // Convert data to Json
                    string json = JsonConvert.SerializeObject(categoryRequest);
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
            if (txtSearchCode.Text == MADM)
            {
                txtSearchCode.Text = string.Empty;
                txtSearchCode.Properties.Appearance.ForeColor = Color.Black;
            }
        }

        private void txtSearchCode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchCode.Text))
            {
                txtSearchCode.Text = MADM;
                txtSearchCode.Properties.Appearance.ForeColor = SystemColors.GrayText;
            }
        }

        private async void gridViewCategory_DoubleClick(object sender, EventArgs e)
        {
            var isClickHeader = gridViewCategory.CalcHitInfo(gridViewCategory.GridControl.PointToClient(Control.MousePosition));
            if (!isClickHeader.InColumn)
            {
                var index = gridViewCategory.FocusedRowHandle;
                if (index != -1)
                {
                    // Lấy FocusedRowHandle để biết dòng đang được chọn
                    int focusedRowHandle = gridViewCategory.FocusedRowHandle;

                    // Lấy giá trị ID từ cột ID của dòng đang được chọn
                    object idValue = gridViewCategory.GetRowCellValue(focusedRowHandle, "ID");

                    // Ép kiểu giá trị ID theo kiểu long
                    long categoryID = Convert.ToInt64(idValue);

                    // Khởi tạo HttpClient
                    using (HttpClient client = new HttpClient())
                    {
                        try
                        {
                            string url = $"{URL}api/Product/Cate/Find/{categoryID}";
                            HttpResponseMessage response = await client.GetAsync(url);

                            if (response.IsSuccessStatusCode)
                            {
                                // Đọc dữ liệu từ phản hồi API
                                string apiResponse = await response.Content.ReadAsStringAsync();

                                // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng CategoryRequest
                                infoCategory = JsonConvert.DeserializeObject<CategoryRequest>(apiResponse);

                                // Hiển thị các thông category để update
                                setInfoCategoryForHeader(infoCategory);
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

        private void setInfoCategoryForHeader(CategoryRequest infoCategory)
        {
            // Change name btnAdd
            btnAdd.Text = "Cập nhật (F2)";
            // Update mode
            isMode = "Update";
            // Create data header
            txtCode.Text = infoCategory.Slug;
            txtName.Text = infoCategory.Name;
            txtArea.Text = infoCategory.Area;
            cbStatus.Checked = infoCategory.Status == 1;
            txtNote.Text = infoCategory.Description;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F2:
                    // Gọi lưu ở đây
                    create_Category();
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
