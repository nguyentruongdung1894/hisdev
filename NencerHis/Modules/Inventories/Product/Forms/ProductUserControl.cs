using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using NencerHis.Modules.CommonManager;
using NencerHis.Modules.Inventories.Category.Models;
using NencerHis.Modules.Inventories.Product.Models;
using NencerHis.Modules.Inventories.Product.Models.Request;
using NencerHis.Modules.Reception.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;

namespace NencerHis.Modules.Inventories.Product.Forms
{
    public partial class ProductUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        // API url
        public const string URL = "http://localhost:5294/";
        public const string MATHUOC = "Mã thuốc";

        // List
        List<ProductModel> _productData = new List<ProductModel>();
        List<CategoryModel> _cbbCategoryData = new List<CategoryModel>();
        List<ProductUnitModel> _cbbProductUnitData = new List<ProductUnitModel>();

        // Request
        ProductRequest productRequest = new ProductRequest();
        ProductRequest infoProduct = new ProductRequest();

        // IsMode
        private string isMode = "Add";

        // Const
        private const string MEDICINE = "Thuốc";
        private const string MEDICAA_SUPPLIES = "Vật tư y tế";
        private int totalCount = 0;

        // khai báo biến
        public int TotalCount
        {
            get
            {
                return paginationControl.TotalCount;
            }
        }

        public ProductUserControl()
        {
            InitializeComponent();
            paginationControl.PageChanged += PaginationControl_PageChanged;
        }

        private async void PaginationControl_PageChanged(object sender, EventArgs e)
        {
            // Search data after change page
            await searchData(false);
        }

        private void ProductUserControl_Load(object sender, EventArgs e)
        {
            Init();
            gridViewProduct.OptionsBehavior.ReadOnly = true; // Chỉ đọc
            gridViewProduct.OptionsBehavior.Editable = false; // Không cho phép chỉnh sửa
            gridViewProduct.OptionsBehavior.AllowIncrementalSearch = true; // Cho phép tìm kiếm tăng dần
        }

        private async void Init()
        {
            // Create combobox
            createcbbType();
            await createcbbCatId();
            await createcbbunit();

            // Get data init for gridview
            await searchData(false);

            // Set focus init
            txtCode.Focus();
            // Set FontStyle
            foreach (GridColumn objCol in gridViewProduct.Columns)
            {
                objCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                objCol.AppearanceHeader.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }
        }

        private void createcbbType()
        {
            // Tạo danh sách loại sản phẩm
            List<ComboBoxModel> listComboBox = new List<ComboBoxModel>
            {
                new ComboBoxModel(0, MEDICINE),
                new ComboBoxModel(1, MEDICAA_SUPPLIES),
            };
            // Thêm các tên của đối tượng vào ComboBoxEdit
            foreach (var cmb in listComboBox)
            {
                cbbType.Properties.Items.Add(cmb.Value);
            }
            // Chọn giá trị mặc định là thuốc
            cbbType.SelectedIndex = 0;
        }

        private async Task createcbbCatId()
        {
            // Init SearchCategoryModel
            SearchCategoryModel searchModel = new SearchCategoryModel();
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
                    HttpResponseMessage response = await client.PostAsync(URL + "api/Product/Cate/List", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu từ phản hồi API
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng CategoryModel
                        _cbbCategoryData = JsonConvert.DeserializeObject<List<CategoryModel>>(apiResponse);

                        // Thêm các mục từ danh sách vào ComboBoxEdit
                        foreach (var item in _cbbCategoryData)
                        {
                            cbbCatId.Properties.Items.Add(item.Name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private async Task createcbbunit()
        {
            // Init SearchProductUnitModel
            SearchProductUnitModel searchModel = new SearchProductUnitModel();
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
                    HttpResponseMessage response = await client.PostAsync(URL + "api/Stock/Unit/List", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu từ phản hồi API
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng ProductUnitModel
                        _cbbProductUnitData = JsonConvert.DeserializeObject<List<ProductUnitModel>>(apiResponse);

                        // Thêm các mục từ danh sách vào ComboBoxEdit
                        foreach (var item in _cbbProductUnitData)
                        {
                            cbbUnit.Properties.Items.Add(item.Name);
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
            // Init SearchProductModel
            SearchProductModel searchModel = new SearchProductModel();
            searchModel.Sku = txtSearchCode.Text == MATHUOC ? string.Empty : txtSearchCode.Text;
            // Create SkipCount, MaxResultCount
            if (!isSearchClick || string.IsNullOrEmpty(searchModel.Sku))
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

        private async Task getDataGrid(SearchProductModel searchModel)
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
                    HttpResponseMessage response = await client.PostAsync(URL + "api/Product/GetAll", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu từ phản hồi API
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng ProductModel
                        _productData = JsonConvert.DeserializeObject<List<ProductModel>>(apiResponse);

                        // Gán dữ liệu vào gridProduct.DataSource
                        gridProduct.DataSource = _productData;

                        // Thêm định dạng số tiền
                        formatPrice();

                        // Code để ẩn một cột trong GridView
                        var totalCountColumn = gridViewProduct.Columns["TotalCount"];
                        if (totalCountColumn != null)
                        {
                            totalCountColumn.Visible = false;
                        }

                        // Reload paging
                        if ((_productData != null && _productData.Any()))
                        {
                            totalCount = _productData[0].TotalCount;
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

        private void formatPrice()
        {
            var columnsToFormat = new string[] { "PriceInput", "Price", "PriceRequest", "PriceIns" };

            foreach (var columnName in columnsToFormat)
            {
                var column = gridViewProduct.Columns[columnName] as GridColumn;

                if (column != null)
                {
                    column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    column.DisplayFormat.FormatString = "N2";
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            // Create/ Update
            await create_Product();
        }

        private void btnAddAndPrint_Click(object sender, EventArgs e)
        {
            // Call func add/ print
            actionAdd_Print_Click();
        }

        private async Task actionAdd_Print_Click()
        {
            // Create/ Update
            await create_Product();

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
            txtName.Text = string.Empty;
            txtBarcode.Text = string.Empty;
            cbbCatId.Text = string.Empty;
            // Row 2
            txtActiveIngredient.Text = string.Empty;
            txtConcentration.Text = string.Empty;
            txtContent.Text = string.Empty;
            txtUsage.Text = string.Empty;
            // Row 3
            txtCountryCode.Text = string.Empty;
            txtManufacturer.Text = string.Empty;
            txtPacking.Text = string.Empty;
            cbbUnit.Text = string.Empty;
            // Row 4
            txtPriceInput.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtPriceRequest.Text = string.Empty;
            txtPriceIns.Text = string.Empty;
            // Row 5
            cbbType.SelectedIndex = 0;
            txtCodeIns.Text = string.Empty;
            txtNameIns.Text = string.Empty;
            txtRegistrationNumber.Text = string.Empty;
            // Row 6
            txtNote.Text = string.Empty;
            cbUsageIns.Checked = false;
            cbPrivate.Checked = false;
            cbStatus.Checked = true;
        }

        private async Task create_Product()
        {
            // Validate
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                // Show alter warning
                Common.ShowMessageWarning("Mã sản phẩm là bắt buộc.");
                txtCode.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                // Show alter warning
                Common.ShowMessageWarning("Tên sản phẩm là bắt buộc.");
                txtName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtBarcode.Text))
            {
                // Show alter warning
                Common.ShowMessageWarning("Barcode là bắt buộc.");
                txtBarcode.Focus();
                return;
            }

            // Nếu là mode tạo mới
            if (isMode == "Add")
            {
                productRequest = new ProductRequest
                {
                    // Row 1
                    Id = 0,
                    Sku = txtCode.Text,
                    Name = txtCode.Text,
                    Barcode = txtBarcode.Text,
                    CatId = _cbbCategoryData.FirstOrDefault(d => d.Name == cbbCatId.Text)?.ID ?? -1,
                    // Row 2
                    ActiveIngredient = txtActiveIngredient.Text,
                    Concentration = txtConcentration.Text,
                    Content = txtContent.Text,
                    Usage = txtUsage.Text,
                    // Row 3
                    CountryCode = txtCountryCode.Text,
                    Manufacturer = txtManufacturer.Text,
                    Packing = txtPacking.Text,
                    Unit = _cbbProductUnitData.FirstOrDefault(d => d.Name == cbbUnit.Text)?.Key ?? string.Empty,
                    // Row 4
                    PriceInput = Decimal.Parse(txtPriceInput.Text),
                    Price = Decimal.Parse(txtPrice.Text),
                    PriceRequest = Decimal.Parse(txtPriceRequest.Text),
                    PriceIns = Decimal.Parse(txtPriceIns.Text),
                    // Row 5
                    Type = cbbType.Text,
                    CodeIns = txtCodeIns.Text,
                    NameIns = txtNameIns.Text,
                    RegistrationNumber = txtRegistrationNumber.Text,
                    // Row 6
                    Description = txtNote.Text,
                    UsageIns = cbUsageIns.Checked == true ? 1 : 0,
                    IsPrivate = cbPrivate.Checked == true ? 1 : 0,
                    Status = cbStatus.Checked == true ? 1 : 0,
                };
            }
            // Nếu là mode update
            else
            {
                // Tạo đối tượng product để update
                productRequest = infoProduct;

                // Update lại các giá trị trên header
                // Row 1
                productRequest.Sku = txtCode.Text;
                productRequest.Name = txtCode.Text;
                productRequest.Barcode = txtBarcode.Text;
                productRequest.CatId = _cbbCategoryData.FirstOrDefault(d => d.Name == cbbCatId.Text)?.ID ?? -1;
                // Row 2
                productRequest.ActiveIngredient = txtActiveIngredient.Text;
                productRequest.Concentration = txtConcentration.Text;
                productRequest.Content = txtContent.Text;
                productRequest.Usage = txtUsage.Text;
                // Row 3
                productRequest.CountryCode = txtCountryCode.Text;
                productRequest.Manufacturer = txtManufacturer.Text;
                productRequest.Packing = txtPacking.Text;
                productRequest.Unit = _cbbProductUnitData.FirstOrDefault(d => d.Name == cbbUnit.Text)?.Key ?? string.Empty;
                // Row 4
                productRequest.PriceInput = Decimal.Parse(txtPriceInput.Text);
                productRequest.Price = Decimal.Parse(txtPrice.Text);
                productRequest.PriceRequest = Decimal.Parse(txtPriceRequest.Text);
                productRequest.PriceIns = Decimal.Parse(txtPriceIns.Text);
                // Row 5
                productRequest.Type = cbbType.Text;
                productRequest.CodeIns = txtCodeIns.Text;
                productRequest.NameIns = txtNameIns.Text;
                productRequest.RegistrationNumber = txtRegistrationNumber.Text;
                // Row 6
                productRequest.Description = txtNote.Text;
                productRequest.UsageIns = cbUsageIns.Checked == true ? 1 : 0;
                productRequest.IsPrivate = cbPrivate.Checked == true ? 1 : 0;
                productRequest.Status = cbStatus.Checked == true ? 1 : 0;
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
                        apiUrl = URL + "api/Product/Create";
                    }
                    else if (isMode == "Update")
                    {
                        apiUrl = URL + "api/Product/Update";
                    }

                    // Convert data to Json
                    string json = JsonConvert.SerializeObject(productRequest);
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
            if (txtSearchCode.Text == MATHUOC)
            {
                txtSearchCode.Text = string.Empty;
                txtSearchCode.Properties.Appearance.ForeColor = Color.Black;
            }
        }

        private void txtSearchCode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchCode.Text))
            {
                txtSearchCode.Text = MATHUOC;
                txtSearchCode.Properties.Appearance.ForeColor = SystemColors.GrayText;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F2:
                    // Gọi lưu ở đây
                    create_Product();
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

        private async void gridViewProduct_DoubleClick(object sender, EventArgs e)
        {
            var isClickHeader = gridViewProduct.CalcHitInfo(gridViewProduct.GridControl.PointToClient(Control.MousePosition));
            if (!isClickHeader.InColumn)
            {
                var index = gridViewProduct.FocusedRowHandle;
                if (index != -1)
                {
                    // Lấy FocusedRowHandle để biết dòng đang được chọn
                    int focusedRowHandle = gridViewProduct.FocusedRowHandle;

                    // Lấy giá trị ID từ cột ID của dòng đang được chọn
                    object idValue = gridViewProduct.GetRowCellValue(focusedRowHandle, "ID");

                    // Ép kiểu giá trị ID theo kiểu int
                    int productID = Convert.ToInt32(idValue);

                    // Khởi tạo HttpClient
                    using (HttpClient client = new HttpClient())
                    {
                        try
                        {
                            string url = $"{URL}api/Product/Find/{productID}";
                            HttpResponseMessage response = await client.GetAsync(url);

                            if (response.IsSuccessStatusCode)
                            {
                                // Đọc dữ liệu từ phản hồi API
                                string apiResponse = await response.Content.ReadAsStringAsync();

                                // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng ProductRequest
                                infoProduct = JsonConvert.DeserializeObject<ProductRequest>(apiResponse);

                                // Hiển thị các thông product để update
                                setInfoProductForHeader(infoProduct);
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

        private void setInfoProductForHeader(ProductRequest infoupplier)
        {
            // Change name btnAdd
            btnAdd.Text = "Cập nhật (F2)";
            // Update mode
            isMode = "Update";
            // Create data header
            // Row 1
            txtCode.Text = infoupplier.Sku;
            txtName.Text = infoupplier.Name;
            txtBarcode.Text = infoupplier.Barcode;
            cbbCatId.Text = _cbbCategoryData.FirstOrDefault(d => d.ID == infoupplier.CatId)?.Name ?? string.Empty;
            // Row 2
            txtActiveIngredient.Text = infoupplier.ActiveIngredient;
            txtConcentration.Text = infoupplier.Concentration;
            txtContent.Text = infoupplier.Content;
            txtUsage.Text = infoupplier.Usage;
            // Row 3
            txtCountryCode.Text = infoupplier.CountryCode;
            txtManufacturer.Text = infoupplier.Manufacturer.ToString();
            txtPacking.Text = infoupplier.Packing;
            cbbUnit.Text = _cbbProductUnitData.FirstOrDefault(d => d.Key == infoupplier.Unit)?.Name ?? string.Empty;
            // Row 4
            txtPriceInput.Text = infoupplier.PriceInput?.ToString("#.00");
            txtPrice.Text = infoupplier.Price?.ToString("#.00");
            txtPriceRequest.Text = infoupplier.PriceRequest?.ToString("#.00");
            txtPriceIns.Text = infoupplier.PriceIns?.ToString("#.00");
            // Row 5
            cbbType.SelectedIndex = 0;
            txtCodeIns.Text = infoupplier.CodeIns;
            txtNameIns.Text = infoupplier.NameIns;
            txtRegistrationNumber.Text = infoupplier.RegistrationNumber;
            // Row 6
            txtNote.Text = infoupplier.Description;
            cbUsageIns.Checked = infoupplier.UsageIns == 1;
            cbPrivate.Checked = infoupplier.IsPrivate == 1;
            cbStatus.Checked = infoupplier.Status == 1;
        }
    }
}
