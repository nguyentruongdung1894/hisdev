using DevExpress.Mvvm.Native;
using DevExpress.Utils.Extensions;
using DevExpress.XtraGrid.Columns;
using NencerHis.Modules.CommonManager;
using NencerHis.Modules.Inventories.Category.Models;
using NencerHis.Modules.Inventories.Package.Models;
using NencerHis.Modules.Inventories.Product.Models;
using NencerHis.Modules.Inventories.Product.Models.Request;
using NencerHis.Modules.Inventories.StockOrder.InvoiceInforUserControl;
using NencerHis.Modules.Inventories.StockOrder.Models;
using NencerHis.Modules.Inventories.StockOrder.Models.Request;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Net.Http;
using System.Text;

namespace NencerHis.Modules.Inventories.StockOrder.Forms
{
    public partial class StockOrderDetailForm : DevExpress.XtraEditors.XtraForm
    {
        // API url
        public const string URL = "http://localhost:5294/";

        // List
        List<ProductModel> _cbbProductData = new List<ProductModel>();
        List<CategoryModel> _cbbCategoryData = new List<CategoryModel>();
        List<ProductUnitModel> _cbbProductUnitData = new List<ProductUnitModel>();
        List<ProductBidsModel> _cbbBidId = new List<ProductBidsModel>();

        // Khai báo biến bindingDataGrid để lưu trữ dữ liệu
        BindingList<StockOrderDetailModel> bindingDataGrid = new BindingList<StockOrderDetailModel>();

        // Request
        ProductRequest infoProduct = new ProductRequest();
        StockRequest stockRequest = new StockRequest();
        InventoryAddRequest inventoryAddRequest = new InventoryAddRequest();
        InventoryTransferRequest inventoryTransferRequest = new InventoryTransferRequest();
        InventoryExportPatientRequest inventoryExportPatientRequest = new InventoryExportPatientRequest();
        InventoryExportCancelRequest inventoryExportCancelRequest = new InventoryExportCancelRequest();

        // IsMode
        private string _isType = "";

        // Const
        private const string IMPORTSUPPLIER = "ImportSupplier";
        private const string IMPORTPROGRAM = "ImportProgram";
        private const string IMPORTANOTHERWAREHOUSE = "ImportAnotherWarehouse";
        private const string EXPORTCUSTOMERS = "ExportCustomers";
        private const string CANCELEXPORT = "CancelExport";
        private const string OTHEREXPORT = "OtherExport";
        private const string RETURNSUPPLIER = "ReturnSupplier";

        // Event close form
        public event EventHandler childWindowClosed;

        // Khai báo biến thành viên để lưu trữ thể hiện
        private ImportSupplierUserControl importSupplier;
        private ImportProgramUserControl importProgram;
        private ImportAnotherWarehouseUserControl importAnother;
        private ExportCustomersUserControl exportCustomers;
        private CancelExportUserControl cancelExport;
        private OtherExportUserControl otherExport;
        private ReturnSupplierUserControl returnSupplier;

        // Khai báo biến
        public int TotalCount
        {
            get
            {
                return paginationControl.TotalCount;
            }
        }

        public StockOrderDetailForm SetIsType(string isType)
        {
            _isType = isType;
            return this;
        }

        // Khai báo biến
        public int CurrentPage
        {
            get
            {
                return paginationControl.CurrentPage;
            }
        }

        public StockOrderDetailForm()
        {
            InitializeComponent();

            // Đặt vị trí của form ở giữa màn hình
            this.StartPosition = FormStartPosition.CenterScreen;

            // Init paging
            paginationControl.PageChanged += PaginationControl_PageChanged;
            paginationControl.RefreshPaging(0);
        }

        private async void PaginationControl_PageChanged(object sender, EventArgs e)
        {
            // Gán danh sách vào DataSource của DataGridView
            gridStockOders.DataSource = bindingDataGrid.Skip(paginationControl.SkipCount)
                                        .Take(paginationControl.MaxResultCount)
                                        .ToList();

            // Reload paging
            paginationControl.RefreshPaging((bindingDataGrid != null && bindingDataGrid.Any()) ? bindingDataGrid.Count : 0);
        }

        private void StockOrderDetailForm_Load(object sender, EventArgs e)
        {
            Init();
        }

        private async void Init()
        {
            // Show/hide item
            showHideItem();

            // Create combobox
            if (_isType == IMPORTSUPPLIER)
            {
                await createcbbProductName(IMPORTSUPPLIER, -1);
            }
            await createcbbCatId();
            await createcbbunit();
            await createcbbBidId();

            // Set FontStyle
            foreach (GridColumn objCol in gridViewStockOders.Columns)
            {
                objCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                objCol.AppearanceHeader.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }
        }

        private void showHideItem()
        {
            if (_isType == IMPORTSUPPLIER)
            {
                importSupplier = new ImportSupplierUserControl() { Dock = DockStyle.Fill };
                panelInvoiceInfor.Controls.Add(importSupplier);
                panelInvoiceInfor.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                // Đăng ký sự kiện SelectedValueChanged từ importSupplier
                importSupplier.SelectedValueChanged += ImportSupplier_SelectedValueChanged;
                importSupplier.TextValueChanged += ImportSupplier_TextValueChanged;
            }
            else if (_isType == IMPORTPROGRAM)
            {
                importProgram = new ImportProgramUserControl() { Dock = DockStyle.Fill };
                panelInvoiceInfor.Controls.Add(importProgram);
                panelInvoiceInfor.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
            else if (_isType == IMPORTANOTHERWAREHOUSE)
            {
                importAnother = new ImportAnotherWarehouseUserControl() { Dock = DockStyle.Fill };
                panelInvoiceInfor.Controls.Add(importAnother);
                panelInvoiceInfor.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                // Đăng ký sự kiện SelectedStockValueChanged từ importAnother
                importAnother.SelectedStockValueChanged += ImportAnother_SelectedValueChanged;
                importAnother.TextValueChanged += ImportAnother_TextValueChanged;
            }
            else if (_isType == EXPORTCUSTOMERS)
            {
                exportCustomers = new ExportCustomersUserControl() { Dock = DockStyle.Fill };
                panelInvoiceInfor.Controls.Add(exportCustomers);
                panelInvoiceInfor.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                // Đăng ký sự kiện SelectedStockValueChanged từ exportCustomers
                exportCustomers.SelectedStockValueChanged += ExportCustomers_SelectedValueChanged;
            }
            else if (_isType == CANCELEXPORT)
            {
                cancelExport = new CancelExportUserControl() { Dock = DockStyle.Fill };
                panelInvoiceInfor.Controls.Add(cancelExport);
                panelInvoiceInfor.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                // Đăng ký sự kiện SelectedStockValueChanged từ cancelExport
                cancelExport.SelectedStockValueChanged += CancelExport_SelectedValueChanged;
            }
            else if (_isType == OTHEREXPORT)
            {
                otherExport = new OtherExportUserControl() { Dock = DockStyle.Fill };
                panelInvoiceInfor.Controls.Add(otherExport);
                panelInvoiceInfor.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                // Đăng ký sự kiện SelectedStockValueChanged từ otherExport
                otherExport.SelectedStockValueChanged += OtherExport_SelectedValueChanged;
            }
            else if (_isType == RETURNSUPPLIER)
            {
                returnSupplier = new ReturnSupplierUserControl() { Dock = DockStyle.Fill };
                panelInvoiceInfor.Controls.Add(returnSupplier);
                panelInvoiceInfor.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                // Đăng ký sự kiện SelectedStockValueChanged từ returnSupplier
                returnSupplier.SelectedStockValueChanged += ReturnSupplier_SelectedValueChanged;
            }
        }

        private void ImportSupplier_SelectedValueChanged(object sender, (int SelectedIndex, string SelectedName) e)
        {
            if (e.SelectedName == "cbbStock")
            {
                cbbStock_SelectedValueChanged(e.SelectedIndex);
            }
            else if (e.SelectedName == "cbbSupplier")
            {
                cbbSupplier_SelectedValueChanged(e.SelectedIndex);
            }
        }

        private void ImportSupplier_TextValueChanged(object sender, (string TextChange, string TextName) e)
        {
            if (e.TextName == "txtBillsNumber")
            {
                txtBillsNumber_Leave(e.TextChange);
            }
            else if (e.TextName == "txtDeliver")
            {
                txtDeliver_Leave(e.TextChange);
            }
            else if (e.TextName == "dpkOrderDate")
            {
                dpkOrderDate_Leave(e.TextChange);
            }
            else if (e.TextName == "txtReceiver")
            {
                txtReceiver_Leave(e.TextChange);
            }
        }

        private void ImportAnother_TextValueChanged(object sender, (string TextChange, string TextName) e)
        {
            if (e.TextName == "mmDescription")
            {
                mmDescription_Leave(e.TextChange);
            }
        }

        private async void ImportAnother_SelectedValueChanged(object sender, (int SelectValue, string SelectedName) e)
        {
            // Xóa hết dữ liệu trong cbbProductName
            cbbProductName.Properties.Items.Clear();
            cbbProductName.SelectedIndex = -1;
            cbbProductName.Text = string.Empty;
            // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng ProductModel
            _cbbProductData = null;
            await createcbbProductName(IMPORTANOTHERWAREHOUSE, e.SelectValue);
        }

        private async void ExportCustomers_SelectedValueChanged(object sender, (int SelectValue, string SelectedName) e)
        {
            // Xóa hết dữ liệu trong cbbProductName
            cbbProductName.Properties.Items.Clear();
            cbbProductName.SelectedIndex = -1;
            cbbProductName.Text = string.Empty;
            // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng ProductModel
            _cbbProductData = null;
            await createcbbProductName(EXPORTCUSTOMERS, e.SelectValue);
        }

        private async void CancelExport_SelectedValueChanged(object sender, (int SelectValue, string SelectedName) e)
        {
            // Xóa hết dữ liệu trong cbbProductName
            cbbProductName.Properties.Items.Clear();
            cbbProductName.SelectedIndex = -1;
            cbbProductName.Text = string.Empty;
            // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng ProductModel
            _cbbProductData = null;
            await createcbbProductName(CANCELEXPORT, e.SelectValue);
        }

        private async void OtherExport_SelectedValueChanged(object sender, (int SelectValue, string SelectedName) e)
        {
            // Xóa hết dữ liệu trong cbbProductName
            cbbProductName.Properties.Items.Clear();
            cbbProductName.SelectedIndex = -1;
            cbbProductName.Text = string.Empty;
            // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng ProductModel
            _cbbProductData = null;
            await createcbbProductName(OTHEREXPORT, e.SelectValue);
        }

        private async void ReturnSupplier_SelectedValueChanged(object sender, (int StockValue, int SupplierValue, string SelectedName) e)
        {
            // Xóa hết dữ liệu trong cbbProductName
            cbbProductName.Properties.Items.Clear();
            cbbProductName.SelectedIndex = -1;
            cbbProductName.Text = string.Empty;
            // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng ProductModel
            _cbbProductData = null;
            await createcbbProductName(RETURNSUPPLIER, e.StockValue, e.SupplierValue);
        }

        private async Task createcbbProductName(string isType, int stockId, int? supplierId = null)
        {
            // Init SearchProductModel
            SearchProductModel searchModel = new SearchProductModel();
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
                    HttpResponseMessage response = null;
                    string linkApi = string.Empty;
                    if (isType == IMPORTSUPPLIER)
                    {
                        linkApi = "api/Product/GetAll";
                        response = await client.PostAsync(URL + linkApi, content);
                    }
                    else if (isType == IMPORTANOTHERWAREHOUSE || isType == EXPORTCUSTOMERS || isType == CANCELEXPORT || isType == OTHEREXPORT)
                    {
                        linkApi = $"{URL}api/Product/GetAllProductByStockId/{stockId}";
                        response = await client.GetAsync(linkApi);
                    }
                    else if (isType == RETURNSUPPLIER)
                    {
                        linkApi = $"{URL}api/Product/GetAllProductByStockIdAndSupplierId/{stockId}/{supplierId}";
                        response = await client.GetAsync(linkApi);
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu từ phản hồi API
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng ProductModel
                        _cbbProductData = JsonConvert.DeserializeObject<List<ProductModel>>(apiResponse);

                        // Thêm các mục từ danh sách vào ComboBoxEdit
                        foreach (var item in _cbbProductData)
                        {
                            cbbProductName.Properties.Items.Add(item.Name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
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

        private async Task createcbbBidId()
        {
            // Init ProductBidsSearchModel
            ProductBidsSearchModel searchModel = new ProductBidsSearchModel();
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
                    HttpResponseMessage response = await client.PostAsync(URL + "api/Product/ProductBid/GetAll", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu từ phản hồi API
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng ProductBidsModel
                        _cbbBidId = JsonConvert.DeserializeObject<List<ProductBidsModel>>(apiResponse);

                        // Thêm các mục từ danh sách vào ComboBoxEdit
                        cbbBidId.Properties.Items.AddRange(_cbbBidId.Where(item => item.Name != null).Select(item => item.Name).ToArray());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private async void cbbProductName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbProductName.SelectedIndex != -1)
            {
                int productID = _cbbProductData.ElementAt(cbbProductName.SelectedIndex).ID;

                // Khởi tạo HttpClient
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        string url = string.Empty;
                        if (_isType == IMPORTSUPPLIER)
                        {
                            url = $"{URL}api/Product/Find/{productID}";
                        }
                        else if (_isType == IMPORTANOTHERWAREHOUSE || _isType == EXPORTCUSTOMERS || _isType == CANCELEXPORT || _isType == OTHEREXPORT || _isType == RETURNSUPPLIER)
                        {
                            url = $"{URL}api/Product/FindByInventorieId/{productID}";
                        }
                        HttpResponseMessage response = await client.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            // Đọc dữ liệu từ phản hồi API
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng ProductRequest
                            infoProduct = JsonConvert.DeserializeObject<ProductRequest>(apiResponse);

                            // Hiển thị các thông product
                            setInforDrugsSupplies(infoProduct);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void setInforDrugsSupplies(ProductRequest infoupplier)
        {
            // Row 1
            txtProductCode.Text = infoupplier.Sku;
            txtConcentration.Text = infoupplier.Concentration;
            txtContent.Text = infoupplier.Content;
            cbbCatId.Text = _cbbCategoryData.FirstOrDefault(d => d.ID == infoupplier.CatId)?.Name ?? string.Empty;
            txtLotCode.Text = infoupplier.LotCode;
            // Row 2
            txtCountryCode.Text = infoupplier.CountryCode;
            txtManufacturer.Text = infoupplier.Manufacturer;
            txtRegistrationNumber.Text = infoupplier.RegistrationNumber;
            cbbUnit.Text = _cbbProductUnitData.FirstOrDefault(d => d.Key == infoupplier.Unit)?.Name ?? string.Empty;
            txtUsage.Text = infoupplier.Usage;
            if (infoupplier.ExpirationDate.HasValue)
            {
                int day = infoupplier.ExpirationDate.Value.Day;
                int month = infoupplier.ExpirationDate.Value.Month;
                int year = infoupplier.ExpirationDate.Value.Year;

                txtDay.Text = day.ToString();
                txtMonth.Text = month.ToString();
                txtYear.Text = year.ToString();
            }
            // Row 3
            txtQuantity.Text = infoupplier.Qty.ToString();
            txtPriceInput.Text = infoupplier.PriceInput?.ToString("#.00");
            txtTaxRate.Text = string.Format("{0:P}", infoupplier.TaxRate);
            txtPrice.Text = infoupplier.Price?.ToString("#.00");
            txtTotalPrice.Text = infoupplier.TotalAmount?.ToString("#.00");
            txtPriceIns.Text = infoupplier.PriceIns?.ToString("#.00");
            // Row 4
            cbbBidId.Text = _cbbBidId.FirstOrDefault(x => x.Id == infoupplier.BidId)?.Name ?? string.Empty;
            txtContractorGroup.Text = infoupplier.BidGroup;
            txtBidDecisionNumber.Text = infoupplier.BidNumber;
            txtBidYear.Text = infoupplier.BidYear;
            txtTollPrice.Text = infoupplier.Price?.ToString("#.00");
            txtPriceRequest.Text = infoupplier.PriceRequest?.ToString("#.00");
        }

        private async void btnAddInforDrugsSupplies_Click(object sender, EventArgs e)
        {
            // Gọi thêm thông tin thuốc, vật tư
            await addInforDrugsSupplies();
        }

        private async Task addInforDrugsSupplies()
        {
            // Validate
            if (cbbProductName.SelectedIndex == -1)
            {
                // Show alter warning
                Common.ShowMessageWarning("Bạn chưa chọn sản phẩm.");
                cbbProductName.Focus();
                return;
            }

            // Nếu infoProduct có giá trị, thêm vào danh sách và cập nhật DataGridView
            int currentPage = 1;
            if (infoProduct != null)
            {
                // Thêm vào grid
                stockRequest = setStockRequest();
                bindingDataGrid.Add(setDataForGrid());

                // Set value for SkipCount
                int pageSize = paginationControl.MaxResultCount;
                int skipValue = 0;
                if (bindingDataGrid.Count % pageSize == 0)
                {
                    currentPage = bindingDataGrid.Count / pageSize - 1;
                    skipValue = (bindingDataGrid.Count / pageSize - 1) * pageSize;
                }
                else
                {
                    currentPage = bindingDataGrid.Count / pageSize;
                    skipValue = (bindingDataGrid.Count / pageSize) * pageSize;
                }

                // Gán danh sách vào DataSource của DataGridView
                gridStockOders.DataSource = bindingDataGrid.Skip(skipValue)
                                            .Take(paginationControl.MaxResultCount)
                                            .ToList();

                // Thêm định dạng số tiền
                formatPrice();

                // Cập nhật hiển thị DataGridView
                gridStockOders.Refresh();
            }

            // Khởi tạo lại thông tin thuốc, vật tư sau khi thêm thành công
            clearInforDrugsSupplies();

            // Reload paging
            paginationControl.SetCurrentPage(currentPage + 1);
            paginationControl.RefreshPaging((bindingDataGrid != null && bindingDataGrid.Any()) ? bindingDataGrid.Count : 0);

            // Focus product name
            cbbProductName.Focus();
        }

        private StockRequest setStockRequest()
        {
            // Nếu là _isType là ImportSupplier
            if (_isType == IMPORTSUPPLIER)
            {
                // Kiểm tra và khởi tạo nếu listProductStockOrderItemsRequest là null
                if (stockRequest.listProductStockOrderItemsRequest == null)
                {
                    stockRequest.listProductStockOrderItemsRequest = new List<ProductStockOrderItemsRequest>();
                }
                stockRequest.productStockOrdersRequest = importSupplier.createProductStockOrders();
                stockRequest.listProductStockOrderItemsRequest.AddRange(createProductStockOrderItems());
            }
            else if (_isType == IMPORTANOTHERWAREHOUSE)
            {
                // Kiểm tra và khởi tạo nếu InventoryTransferRequest là null
                if (stockRequest.inventoryTransferRequest == null)
                {
                    stockRequest.inventoryTransferRequest = new InventoryTransferRequest();
                }

                // Kiểm tra và khởi tạo nếu Items trong InventoryTransferRequest là null
                if (stockRequest.inventoryTransferRequest.Items == null)
                {
                    stockRequest.inventoryTransferRequest.Items = new List<InventoryTransferRequestItems>();
                }

                // Kiểm tra xem createInventoryTransferRequest() có trả về đối tượng mới không
                var newTransferRequest = importAnother.createInventoryTransferRequest();
                if (newTransferRequest != null)
                {
                    // Chỉ cập nhật inventoryTransferRequest nếu có đối tượng mới được trả về
                    stockRequest.inventoryTransferRequest = newTransferRequest;

                    // Kiểm tra và khởi tạo nếu Items trong InventoryTransferRequest là null
                    if (stockRequest.inventoryTransferRequest.Items == null)
                    {
                        stockRequest.inventoryTransferRequest.Items = new List<InventoryTransferRequestItems>();
                    }

                    stockRequest.inventoryTransferRequest.Items.AddRange(createInventoryTransferRequestItems());
                }
            }
            else if (_isType == EXPORTCUSTOMERS)
            {
                // Kiểm tra và khởi tạo nếu InventoryExportPatientRequest là null
                if (stockRequest.inventoryExportPatientRequest == null)
                {
                    stockRequest.inventoryExportPatientRequest = new InventoryExportPatientRequest();
                }

                // Kiểm tra và khởi tạo nếu Items trong InventoryExportPatientRequest là null
                if (stockRequest.inventoryExportPatientRequest.Items == null)
                {
                    stockRequest.inventoryExportPatientRequest.Items = new List<InventoryExportPatientRequestItem>();
                }

                // Kiểm tra xem createInventoryExportPatientRequestItem() có trả về đối tượng mới không
                var newExportPatientRequest = exportCustomers.createInventoryExportPatientRequest();
                if (newExportPatientRequest != null)
                {
                    // Chỉ cập nhật inventoryTransferRequest nếu có đối tượng mới được trả về
                    stockRequest.inventoryExportPatientRequest = newExportPatientRequest;

                    // Kiểm tra và khởi tạo nếu Items trong inventoryExportPatientRequest là null
                    if (stockRequest.inventoryExportPatientRequest.Items == null)
                    {
                        stockRequest.inventoryExportPatientRequest.Items = new List<InventoryExportPatientRequestItem>();
                    }

                    stockRequest.inventoryExportPatientRequest.Items.AddRange(createInventoryExportPatientRequestItems());
                }
            }
            else if (_isType == CANCELEXPORT || _isType == OTHEREXPORT || _isType == RETURNSUPPLIER)
            {
                // Kiểm tra và khởi tạo nếu InventoryExportCancelRequest là null
                if (stockRequest.inventoryExportCancelRequest == null)
                {
                    stockRequest.inventoryExportCancelRequest = new InventoryExportCancelRequest();
                }

                // Kiểm tra và khởi tạo nếu Items trong InventoryExportCancelRequest là null
                if (stockRequest.inventoryExportCancelRequest.Items == null)
                {
                    stockRequest.inventoryExportCancelRequest.Items = new List<InventoryExportCancelRequestItem>();
                }

                // Kiểm tra xem createInventoryExportCancelRequest() có trả về đối tượng mới không
                var newInventoryExportCancel = new InventoryExportCancelRequest();
                if (_isType == CANCELEXPORT)
                {
                    newInventoryExportCancel = cancelExport.createInventoryExportCancelRequest();
                }
                else if (_isType == OTHEREXPORT)
                {
                    newInventoryExportCancel = otherExport.createInventoryExportCancelRequest();
                }
                else if (_isType == RETURNSUPPLIER)
                {
                    newInventoryExportCancel = returnSupplier.createInventoryExportCancelRequest();
                }

                if (newInventoryExportCancel != null)
                {
                    // Chỉ cập nhật inventoryTransferRequest nếu có đối tượng mới được trả về
                    stockRequest.inventoryExportCancelRequest = newInventoryExportCancel;

                    // Kiểm tra và khởi tạo nếu Items trong inventoryExportPatientRequest là null
                    if (stockRequest.inventoryExportCancelRequest.Items == null)
                    {
                        stockRequest.inventoryExportCancelRequest.Items = new List<InventoryExportCancelRequestItem>();
                    }

                    stockRequest.inventoryExportCancelRequest.Items.AddRange(createInventoryExportCancelRequestItem());
                }
            }
            return stockRequest;
        }

        private List<ProductStockOrderItemsRequest> createProductStockOrderItems()
        {
            // Init ProductStockOrderItemsRequest
            List<ProductStockOrderItemsRequest> listProductStockOrderItemsRequest = new List<ProductStockOrderItemsRequest>();
            ProductStockOrderItemsRequest productStockOrderItems = new ProductStockOrderItemsRequest();

            // Row 1
            productStockOrderItems.Name = cbbProductName.SelectedIndex;
            productStockOrderItems.Code = txtProductCode.Text;
            productStockOrderItems.Concentration = txtConcentration.Text;
            productStockOrderItems.Content = txtContent.Text;
            productStockOrderItems.CatId = cbbCatId.SelectedIndex;
            productStockOrderItems.LootCode = txtLotCode.Text;
            // Row 2
            productStockOrderItems.CountryCode = txtCountryCode.Text;
            productStockOrderItems.Manufacturer = txtManufacturer.Text;
            productStockOrderItems.RegistrationNumber = txtRegistrationNumber.Text;
            productStockOrderItems.Unit = cbbUnit.SelectedIndex;
            productStockOrderItems.Usage = txtUsage.Text;
            productStockOrderItems.Day = txtDay.Text;
            productStockOrderItems.Month = txtMonth.Text;
            productStockOrderItems.Year = txtYear.Text;
            // Row 3
            productStockOrderItems.Quantity = string.IsNullOrEmpty(txtQuantity.Text) == true ? 0 : int.Parse(txtQuantity.Text);
            productStockOrderItems.PriceInput = string.IsNullOrEmpty(txtPriceInput.Text) == true ? 0 : Decimal.Parse(txtPriceInput.Text);
            productStockOrderItems.Tax = string.IsNullOrEmpty(txtTaxRate.Text) == true ? 0 : Decimal.Parse(txtTaxRate.Text);
            productStockOrderItems.Price = string.IsNullOrEmpty(txtPrice.Text) == true ? 0 : Decimal.Parse(txtPrice.Text);
            productStockOrderItems.TotalPrice = string.IsNullOrEmpty(txtTotalPrice.Text) == true ? 0 : Decimal.Parse(txtTotalPrice.Text);
            productStockOrderItems.PriceIns = string.IsNullOrEmpty(txtPriceIns.Text) == true ? 0 : Decimal.Parse(txtPriceIns.Text);
            // Row 4
            productStockOrderItems.BidDecisionNumber = cbbBidId.Text;
            productStockOrderItems.ContractorGroup = cbbBidId.Text;
            // Row 5
            productStockOrderItems.BidId = cbbBidId.SelectedIndex != -1 ? _cbbBidId.ElementAt(cbbBidId.SelectedIndex).Id : null;
            productStockOrderItems.BidYear = txtBidYear.Text;
            productStockOrderItems.TollPrice = string.IsNullOrEmpty(txtTollPrice.Text) == true ? 0 : Decimal.Parse(txtTollPrice.Text);
            productStockOrderItems.PriceRequest = string.IsNullOrEmpty(txtPriceRequest.Text) == true ? 0 : Decimal.Parse(txtPriceRequest.Text);

            listProductStockOrderItemsRequest.Add(productStockOrderItems);
            return listProductStockOrderItemsRequest;
        }

        private List<InventoryTransferRequestItems> createInventoryTransferRequestItems()
        {
            // Init InventoryTransferRequestItems
            List<InventoryTransferRequestItems> lstInventoryTransferRequestItems = new List<InventoryTransferRequestItems>();
            InventoryTransferRequestItems inventoryTransferRequestItems = new InventoryTransferRequestItems();

            inventoryTransferRequestItems.InventoryId = _cbbProductData.ElementAt(cbbProductName.SelectedIndex).ID;
            inventoryTransferRequestItems.Qty = string.IsNullOrEmpty(txtQuantity.Text) == true ? 0 : int.Parse(txtQuantity.Text);
            inventoryTransferRequestItems.Unit = _cbbProductUnitData.ElementAt(cbbUnit.SelectedIndex)?.Key ?? string.Empty;
            inventoryTransferRequestItems.PackageCode = txtLotCode.Text;
            inventoryTransferRequestItems.ExpirationDate = convertStringToDate(txtDay.Text, txtMonth.Text, txtYear.Text);
            inventoryTransferRequestItems.Price = string.IsNullOrEmpty(txtPrice.Text) == true ? 0 : Decimal.Parse(txtPrice.Text);
            inventoryTransferRequestItems.BidNumber = txtBidDecisionNumber.Text;

            lstInventoryTransferRequestItems.Add(inventoryTransferRequestItems);
            return lstInventoryTransferRequestItems;
        }

        private List<InventoryExportPatientRequestItem> createInventoryExportPatientRequestItems()
        {
            // Init InventoryExportPatientRequestItem
            List<InventoryExportPatientRequestItem> lstInventoryExportPatientRequestItem = new List<InventoryExportPatientRequestItem>();
            InventoryExportPatientRequestItem inventoryExportPatientRequestItem = new InventoryExportPatientRequestItem();

            inventoryExportPatientRequestItem.InventoryId = _cbbProductData.ElementAt(cbbProductName.SelectedIndex).ID;
            inventoryExportPatientRequestItem.Qty = string.IsNullOrEmpty(txtQuantity.Text) == true ? 0 : int.Parse(txtQuantity.Text);
            inventoryExportPatientRequestItem.Unit = _cbbProductUnitData.ElementAt(cbbUnit.SelectedIndex)?.Key ?? string.Empty;

            lstInventoryExportPatientRequestItem.Add(inventoryExportPatientRequestItem);
            return lstInventoryExportPatientRequestItem;
        }

        private List<InventoryExportCancelRequestItem> createInventoryExportCancelRequestItem()
        {
            // Init InventoryExportCancelRequestItem
            List<InventoryExportCancelRequestItem> lstInventoryExportCancelRequestItem = new List<InventoryExportCancelRequestItem>();
            InventoryExportCancelRequestItem inventoryExportCancelRequestItem = new InventoryExportCancelRequestItem();

            inventoryExportCancelRequestItem.InventoryId = _cbbProductData.ElementAt(cbbProductName.SelectedIndex).ID;
            inventoryExportCancelRequestItem.Qty = string.IsNullOrEmpty(txtQuantity.Text) == true ? 0 : int.Parse(txtQuantity.Text);
            inventoryExportCancelRequestItem.Unit = _cbbProductUnitData.ElementAt(cbbUnit.SelectedIndex)?.Key ?? string.Empty;

            lstInventoryExportCancelRequestItem.Add(inventoryExportCancelRequestItem);
            return lstInventoryExportCancelRequestItem;
        }

        private StockOrderDetailModel setDataForGrid()
        {
            StockOrderDetailModel stockOrderDetailModel = new StockOrderDetailModel();
            stockOrderDetailModel.Name = cbbProductName.Text;
            stockOrderDetailModel.Concentration = txtConcentration.Text;
            stockOrderDetailModel.Content = txtContent.Text;
            decimal priceInput = string.IsNullOrEmpty(txtPriceInput.Text) == true ? 0 : Decimal.Parse(txtPriceInput.Text);
            decimal taxRate = string.IsNullOrEmpty(txtTaxRate.Text) == true ? 0 : Decimal.Parse(txtTaxRate.Text);
            decimal quantity = string.IsNullOrEmpty(txtQuantity.Text) == true ? 0 : Decimal.Parse(txtQuantity.Text);
            stockOrderDetailModel.Quantity = (int?)quantity;
            stockOrderDetailModel.Price = priceInput * taxRate / 100 + priceInput;
            stockOrderDetailModel.TotalPrice = quantity * (priceInput * taxRate / 100 + priceInput);
            stockOrderDetailModel.LotCode = txtLotCode.Text;
            stockOrderDetailModel.BidDecisionNumber = txtBidDecisionNumber.Text;
            stockOrderDetailModel.ContractorGroup = txtContractorGroup.Text;
            stockOrderDetailModel.BidId = cbbBidId.SelectedIndex != -1 ? _cbbBidId.ElementAt(cbbBidId.SelectedIndex).Id.ToString() : string.Empty;
            stockOrderDetailModel.BidYear = txtYear.Text;

            return stockOrderDetailModel;
        }

        private void formatPrice()
        {
            var columnsToFormat = new string[] { "Price", "TotalPrice" };

            foreach (var columnName in columnsToFormat)
            {
                var column = gridViewStockOders.Columns[columnName] as GridColumn;

                if (column != null)
                {
                    column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    column.DisplayFormat.FormatString = "N2";
                }
            }
        }

        private void clearInforDrugsSupplies()
        {
            // Row 1
            cbbProductName.SelectedIndex = -1;
            txtProductCode.Text = string.Empty;
            txtConcentration.Text = string.Empty;
            txtContent.Text = string.Empty;
            cbbCatId.SelectedIndex = -1;
            txtLotCode.Text = string.Empty;
            // Row 2
            txtCountryCode.Text = string.Empty;
            txtManufacturer.Text = string.Empty;
            txtRegistrationNumber.Text = string.Empty;
            cbbUnit.SelectedIndex = -1;
            txtUsage.Text = string.Empty;
            txtDay.Text = string.Empty;
            txtMonth.Text = string.Empty;
            txtYear.Text = string.Empty;
            // Row 3
            txtQuantity.Text = string.Empty;
            txtPriceInput.Text = string.Empty;
            txtTaxRate.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtTotalPrice.Text = string.Empty;
            txtPriceIns.Text = string.Empty;
            // Row 4
            cbbBidId.Text = string.Empty;
            txtContractorGroup.Text = string.Empty;
            txtBidDecisionNumber.Text = string.Empty;
            txtBidYear.Text = string.Empty;
            txtTollPrice.Text = string.Empty;
            txtPriceRequest.Text = string.Empty;
        }

        private void setPriceAfterFocus()
        {
            decimal priceInput = string.IsNullOrEmpty(txtPriceInput.Text) == true ? 0 : Decimal.Parse(txtPriceInput.Text);
            decimal taxRate = string.IsNullOrEmpty(txtTaxRate.Text) == true ? 0 : Decimal.Parse(txtTaxRate.Text);
            decimal quantity = string.IsNullOrEmpty(txtQuantity.Text) == true ? 0 : Decimal.Parse(txtQuantity.Text);
            txtPrice.Text = ((priceInput * taxRate / 100 + priceInput) != 0) ? (priceInput * taxRate / 100 + priceInput).ToString("#.00") : string.Empty;
            txtTotalPrice.Text = ((quantity * (priceInput * taxRate / 100 + priceInput)) != 0) ? (quantity * (priceInput * taxRate / 100 + priceInput)).ToString("#.00") : string.Empty;
            txtPriceIns.Text = txtPrice.Text;
            txtTollPrice.Text = txtPrice.Text;
            txtPriceRequest.Text = txtPrice.Text;
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            setPriceAfterFocus();
        }

        private void txtPriceInput_Leave(object sender, EventArgs e)
        {
            setPriceAfterFocus();
        }

        private void txtTaxRate_Leave(object sender, EventArgs e)
        {
            setPriceAfterFocus();
        }

        private void gridViewStockOders_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Quantity")
            {
                int rowHandle = e.RowHandle;

                // Lấy giá trị mới của "Quantity"
                int? newQuantity = e.Value as int?;

                // Kiểm tra giá trị mới của "Quantity"
                if (newQuantity.HasValue && rowHandle >= 0)
                {
                    // Lấy giá trị hiện tại của "Price"
                    decimal? price = gridViewStockOders.GetRowCellValue(rowHandle, "Price") as decimal?;

                    // Kiểm tra giá trị của "Price"
                    if (price.HasValue)
                    {
                        // Tính toán giá trị mới cho "TotalPrice"
                        decimal newTotalPrice = newQuantity.Value * price.Value;

                        // Cập nhật giá trị của "TotalPrice" trong bindingDataGrid
                        var dataSource = bindingDataGrid.Skip(paginationControl.SkipCount)
                                        .Take(paginationControl.MaxResultCount)
                                        .ToList();
                        if (dataSource != null)
                        {
                            dataSource[rowHandle].TotalPrice = newTotalPrice;
                        }

                        // Làm mới grid để hiển thị ngay lập tức
                        gridViewStockOders.RefreshData();
                    }
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            // Gọi lưu ở đây
            await create_Stock();
        }

        private DateTime convertStringToDate(string dayValue, string monthValue, string yearValue)
        {
            string dayString = dayValue;
            string monthString = monthValue;
            string yearString = yearValue;
            DateTime result = new DateTime();
            if (int.TryParse(dayString, out int day) && int.TryParse(monthString, out int month) && int.TryParse(yearString, out int year))
            {
                result = new DateTime(year, month, day);
            }

            return result;
        }

        private List<Items> createItems()
        {
            var items = new List<Items>();

            bindingDataGrid.ForEach((data, index) =>
            {
                var item = new Items();

                item.ProductId = _cbbProductData.FirstOrDefault(x => x.Name == data.Name).ID;
                item.Qty = data.Quantity.Value;
                item.Unit = _cbbProductUnitData[stockRequest.listProductStockOrderItemsRequest[index].Unit.Value]?.Key ?? string.Empty;
                item.PriceInput = stockRequest.listProductStockOrderItemsRequest[index].PriceInput;
                item.Tax = stockRequest.listProductStockOrderItemsRequest[index].Tax;
                item.PackageCode = stockRequest.listProductStockOrderItemsRequest[index].LootCode;

                item.ExpirationDate = convertStringToDate(stockRequest.listProductStockOrderItemsRequest[index].Day, stockRequest.listProductStockOrderItemsRequest[index].Month, stockRequest.listProductStockOrderItemsRequest[index].Year);
                item.Price = data.Price;
                item.PriceIns = data.Price;
                item.PriceRequest = data.Price;
                item.BidNumber = stockRequest.listProductStockOrderItemsRequest[index].BidDecisionNumber;
                item.BidGroup = stockRequest.listProductStockOrderItemsRequest[index].ContractorGroup;
                item.BidPackage = string.Empty;
                item.BidYear = stockRequest.listProductStockOrderItemsRequest[index].BidYear;
                item.BidId = stockRequest.listProductStockOrderItemsRequest[index].BidId;
                item.LotCode = stockRequest.listProductStockOrderItemsRequest[index].LootCode;

                items.Add(item);
            });

            return items;
        }

        private List<InventoryTransferRequestItems> createTransferItems()
        {
            var lstTransferItems = new List<InventoryTransferRequestItems>();

            bindingDataGrid.ForEach((data, index) =>
            {
                var transferItem = new InventoryTransferRequestItems();

                transferItem.InventoryId = stockRequest.inventoryTransferRequest.Items[index].InventoryId;
                transferItem.Qty = data.Quantity.Value;
                transferItem.Unit = stockRequest.inventoryTransferRequest.Items[index].Unit;
                transferItem.PackageCode = stockRequest.inventoryTransferRequest.Items[index].PackageCode;
                transferItem.ExpirationDate = stockRequest.inventoryTransferRequest.Items[index].ExpirationDate;
                transferItem.Price = stockRequest.inventoryTransferRequest.Items[index].Price;
                transferItem.BidNumber = stockRequest.inventoryTransferRequest.Items[index].BidNumber;

                lstTransferItems.Add(transferItem);
            });

            return lstTransferItems;
        }

        private List<InventoryExportPatientRequestItem> createPatientItems()
        {
            var lstPatientItems = new List<InventoryExportPatientRequestItem>();

            bindingDataGrid.ForEach((data, index) =>
            {
                var patientItem = new InventoryExportPatientRequestItem();

                patientItem.InventoryId = stockRequest.inventoryExportPatientRequest.Items[index].InventoryId;
                patientItem.Qty = data.Quantity.Value;
                patientItem.Unit = stockRequest.inventoryExportPatientRequest.Items[index].Unit;

                lstPatientItems.Add(patientItem);
            });

            return lstPatientItems;
        }

        private List<InventoryExportCancelRequestItem> createCancelRequestItems()
        {
            var lstCancelRequestItems = new List<InventoryExportCancelRequestItem>();

            bindingDataGrid.ForEach((data, index) =>
            {
                var cancelRequestItem = new InventoryExportCancelRequestItem();

                cancelRequestItem.InventoryId = stockRequest.inventoryExportCancelRequest.Items[index].InventoryId;
                cancelRequestItem.Qty = data.Quantity.Value;
                cancelRequestItem.Unit = stockRequest.inventoryExportCancelRequest.Items[index].Unit;

                lstCancelRequestItems.Add(cancelRequestItem);
            });

            return lstCancelRequestItems;
        }

        private async Task create_Stock()
        {
            if ((_isType == IMPORTSUPPLIER && stockRequest.productStockOrdersRequest == null) ||
                (_isType == IMPORTSUPPLIER && stockRequest.listProductStockOrderItemsRequest == null) ||
                (_isType == IMPORTANOTHERWAREHOUSE && stockRequest.inventoryTransferRequest == null) ||
                (_isType == EXPORTCUSTOMERS && stockRequest.inventoryExportPatientRequest == null) ||
                (_isType == CANCELEXPORT && stockRequest.inventoryExportCancelRequest == null) ||
                (_isType == OTHEREXPORT && stockRequest.inventoryExportCancelRequest == null) ||
                (_isType == RETURNSUPPLIER && stockRequest.inventoryExportCancelRequest == null))
            {
                // Show alter warning
                Common.ShowMessageWarning("Vui lòng thêm mới sản phẩm.");
                btnAddInforDrugsSupplies.Focus();
                return;
            }
            else
            {
                // Kiểm tra xem có thông tin thuốc nào chưa có số lượng hay không
                var item = bindingDataGrid.FirstOrDefault(x => x.Quantity == 0);
                // Validate
                if (item != null)
                {
                    // Show alter warning
                    Common.ShowMessageWarning("Vui lòng nhập số lượng cho thuốc: " + item.Name);
                    cbbProductName.Focus();
                    return;
                }

                // Nếu là _isType là ImportSupplier
                if (_isType == IMPORTSUPPLIER)
                {
                    inventoryAddRequest = new InventoryAddRequest();

                    // Kiểm tra xem đã chọn kho chưa
                    if (stockRequest.productStockOrdersRequest.StockId == -1)
                    {
                        // Show alter warning
                        Common.ShowMessageWarning("Bạn chưa chọn kho.");
                        importSupplier.cbbStockFocus();
                        return;
                    }
                    else
                    {
                        inventoryAddRequest.StockId = stockRequest.productStockOrdersRequest.StockId.Value;
                    }
                    // Kiểm tra xem đã chọn nhà cung cấp chưa
                    if (stockRequest.productStockOrdersRequest.SupplierId == -1)
                    {
                        // Show alter warning
                        Common.ShowMessageWarning("Bạn chưa chọn nhà cung cấp.");
                        importSupplier.cbbSupplierFocus();
                        return;
                    }
                    else
                    {
                        inventoryAddRequest.SupplierId = stockRequest.productStockOrdersRequest.SupplierId.Value;
                    }
                    // Kiểm tra xem đã nhập số hóa đơn
                    if (string.IsNullOrEmpty(stockRequest.productStockOrdersRequest.Code))
                    {
                        // Show alter warning
                        Common.ShowMessageWarning("Bạn chưa nhập số hóa đơn.");
                        importSupplier.txtBillsNumberFocus();
                        return;
                    }
                    else
                    {
                        inventoryAddRequest.Code = stockRequest.productStockOrdersRequest.Code;
                    }
                    inventoryAddRequest.Receiver = stockRequest.productStockOrdersRequest.Receiver;
                    inventoryAddRequest.BillDate = stockRequest.productStockOrdersRequest.OrderDate;
                    inventoryAddRequest.Deliver = stockRequest.productStockOrdersRequest.Deliver;
                    inventoryAddRequest.Status = 1;
                    inventoryAddRequest.Note = string.Empty;
                    inventoryAddRequest.Items = createItems();
                }
                else if (_isType == IMPORTANOTHERWAREHOUSE)
                {
                    inventoryTransferRequest = new InventoryTransferRequest();

                    // Kiểm tra xem đã chọn kho chưa
                    if (stockRequest.inventoryTransferRequest.StockId == -1)
                    {
                        // Show alter warning
                        Common.ShowMessageWarning("Bạn chưa chọn kho nhập.");
                        importAnother.cbbStockInputFocus();
                        return;
                    }
                    else
                    {
                        inventoryTransferRequest.StockId = stockRequest.inventoryTransferRequest.StockId;
                    }
                    // Kiểm tra xem đã chọn kho chưa
                    if (stockRequest.inventoryTransferRequest.TargetStockId == -1)
                    {
                        // Show alter warning
                        Common.ShowMessageWarning("Bạn chưa chọn kho xuất.");
                        importAnother.cbbStockOutputFocus();
                        return;
                    }
                    else
                    {
                        inventoryTransferRequest.TargetStockId = stockRequest.inventoryTransferRequest.TargetStockId;
                    }
                    inventoryTransferRequest.Status = stockRequest.inventoryTransferRequest.Status;
                    inventoryTransferRequest.Note = stockRequest.inventoryTransferRequest.Note;
                    inventoryTransferRequest.Items = createTransferItems();
                }
                else if (_isType == EXPORTCUSTOMERS)
                {
                    inventoryExportPatientRequest = new InventoryExportPatientRequest();

                    // Kiểm tra xem đã chọn kho chưa
                    if (stockRequest.inventoryExportPatientRequest.StockId == -1)
                    {
                        // Show alter warning
                        Common.ShowMessageWarning("Bạn chưa chọn kho xuất.");
                        exportCustomers.cbbStockOutputFocus();
                        return;
                    }
                    else
                    {
                        inventoryExportPatientRequest.StockId = stockRequest.inventoryExportPatientRequest.StockId;
                    }
                    // Kiểm tra xem đã nhập mã bệnh nhân chưa
                    if (string.IsNullOrEmpty(stockRequest.inventoryExportPatientRequest.PatientNumber))
                    {
                        // Show alter warning
                        Common.ShowMessageWarning("Bạn chưa nhập mã bệnh nhân chưa.");
                        exportCustomers.txtPatientCodeFocus();
                        return;
                    }
                    else
                    {
                        inventoryExportPatientRequest.PatientNumber = stockRequest.inventoryExportPatientRequest.PatientNumber;
                    }
                    inventoryExportPatientRequest.Status = stockRequest.inventoryExportPatientRequest.Status;
                    inventoryExportPatientRequest.Note = stockRequest.inventoryExportPatientRequest.Note;
                    inventoryExportPatientRequest.PatientName = stockRequest.inventoryExportPatientRequest.PatientName;
                    inventoryExportPatientRequest.DayBorn = stockRequest.inventoryExportPatientRequest.DayBorn;
                    inventoryExportPatientRequest.MonthBorn = stockRequest.inventoryExportPatientRequest.MonthBorn;
                    inventoryExportPatientRequest.YearBorn = stockRequest.inventoryExportPatientRequest.YearBorn;
                    inventoryExportPatientRequest.Phone = stockRequest.inventoryExportPatientRequest.Phone;
                    inventoryExportPatientRequest.Gender = stockRequest.inventoryExportPatientRequest.Gender;
                    inventoryExportPatientRequest.CityId = stockRequest.inventoryExportPatientRequest.CityId;
                    inventoryExportPatientRequest.DistrictId = stockRequest.inventoryExportPatientRequest.DistrictId;
                    inventoryExportPatientRequest.WardId = stockRequest.inventoryExportPatientRequest.WardId;
                    inventoryExportPatientRequest.Items = createPatientItems();
                }
                else if (_isType == CANCELEXPORT || _isType == OTHEREXPORT || _isType == RETURNSUPPLIER)
                {
                    inventoryExportCancelRequest = new InventoryExportCancelRequest();

                    // Kiểm tra xem đã chọn kho chưa
                    if (stockRequest.inventoryExportCancelRequest.StockId == -1)
                    {
                        // Show alter warning
                        Common.ShowMessageWarning("Bạn chưa chọn kho xuất.");
                        if (_isType == OTHEREXPORT)
                        {
                            otherExport.cbbStockOutputFocus();
                        }
                        else if (_isType == RETURNSUPPLIER)
                        {
                            returnSupplier.cbbStockOutputFocus();
                        }
                        else
                        {
                            cancelExport.cbbStockOutputFocus();
                        }
                        return;
                    }
                    else
                    {
                        inventoryExportCancelRequest.StockId = stockRequest.inventoryExportCancelRequest.StockId;
                    }
                    // Nếu là mode OTHEREXPORT
                    if (_isType == OTHEREXPORT)
                    {
                        // Kiểm tra xem đã chọn lý do xuất chưa
                        if (string.IsNullOrEmpty(stockRequest.inventoryExportCancelRequest.Reason))
                        {
                            // Show alter warning
                            Common.ShowMessageWarning("Bạn chưa chọn lý do xuất.");
                            otherExport.cbbReasonFocus();
                            return;
                        }
                        else
                        {
                            inventoryExportCancelRequest.Reason = stockRequest.inventoryExportCancelRequest.Reason;
                        }
                    }
                    else
                    {
                        inventoryExportCancelRequest.Reason = string.Empty;
                    }
                    inventoryExportCancelRequest.Status = stockRequest.inventoryExportCancelRequest.Status;
                    inventoryExportCancelRequest.Note = stockRequest.inventoryExportCancelRequest.Note;
                    // Nếu là mode RETURNSUPPLIER
                    if (_isType == RETURNSUPPLIER)
                    {
                        // Kiểm tra xem đã chọn kho chưa
                        if (stockRequest.inventoryExportCancelRequest.Supplier_id == -1)
                        {
                            // Show alter warning
                            Common.ShowMessageWarning("Bạn chưa chọn nhà cung cấp.");
                            returnSupplier.cbbSupplierFocus();
                            return;
                        }
                        else
                        {
                            inventoryExportCancelRequest.Supplier_id = stockRequest.inventoryExportCancelRequest.Supplier_id;
                        }
                        // Kiểm tra xem đã nhập người nhận
                        if (string.IsNullOrEmpty(stockRequest.inventoryExportCancelRequest.Receiver))
                        {
                            // Show alter warning
                            Common.ShowMessageWarning("Bạn chưa nhập người nhận.");
                            returnSupplier.txtReceiverFocus();
                            return;
                        }
                        else
                        {
                            inventoryExportCancelRequest.Receiver = stockRequest.inventoryExportCancelRequest.Receiver;
                        }
                    }
                    inventoryExportCancelRequest.Items = createCancelRequestItems();
                }

                // Khởi tạo HttpClient
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        // Init Url
                        string apiUrl = string.Empty;
                        string json = string.Empty;

                        // If _isType = ImportSupplier
                        if (_isType == IMPORTSUPPLIER)
                        {
                            apiUrl = URL + "api/Stock/CreateTicketImport";
                            json = JsonConvert.SerializeObject(inventoryAddRequest);
                        }
                        else if (_isType == IMPORTANOTHERWAREHOUSE)
                        {
                            apiUrl = URL + "api/Stock/CreateTicketTransfer";
                            json = JsonConvert.SerializeObject(inventoryTransferRequest);
                        }
                        else if (_isType == EXPORTCUSTOMERS)
                        {
                            apiUrl = URL + "api/Stock/CreateTicketExportPatient";
                            json = JsonConvert.SerializeObject(inventoryExportPatientRequest);
                        }
                        else if (_isType == CANCELEXPORT || _isType == OTHEREXPORT || _isType == RETURNSUPPLIER)
                        {
                            apiUrl = URL + "api/Stock/CreateTicketExportCancel";
                            json = JsonConvert.SerializeObject(inventoryExportCancelRequest);
                        }

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
                                string mes = "Đăng ký thành công.";
                                // Show alter success
                                Common.ShowMessageSuccess(mes);

                                // Đóng Window con
                                closeChildWindow();
                            }
                            else
                            {
                                // Show alter success
                                Common.ShowMessageWarning((string)responseObject["message"]);
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

        private void closeChildWindow()
        {
            this.Close();

            // Kích hoạt sự kiện khi cửa sổ con được đóng
            onChildWindowClosed();
        }

        // Hàm kích hoạt sự kiện
        protected virtual void onChildWindowClosed()
        {
            childWindowClosed?.Invoke(this, EventArgs.Empty);
        }

        private async void btnAddAndPrint_Click(object sender, EventArgs e)
        {
            // Call func add/ print
            actionAdd_Print_Click();
        }

        private async Task actionAdd_Print_Click()
        {
            // Create/ Update
            await create_Stock();

            // Print
            Common.ShowMessageSuccess("In thành công!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearDataHeader();
        }

        private void clearDataHeader()
        {
            if (_isType == IMPORTSUPPLIER)
            {
                // Set focus init
                importSupplier.cbbStockFocus();
                // Reset data header
                importSupplier.clearProductStockOrders();
            }
            else if (_isType == IMPORTPROGRAM)
            {

            }
            else if (_isType == IMPORTANOTHERWAREHOUSE)
            {
                importAnother.clearInventoryTransferRequest();
            }
            else if (_isType == EXPORTCUSTOMERS)
            {
                exportCustomers.clearExportPatientRequest();
            }
            else if (_isType == CANCELEXPORT)
            {
                cancelExport.clearCancelExport();
            }
            else if (_isType == OTHEREXPORT)
            {
                otherExport.clearOtherExport();
            }
            else if (_isType == RETURNSUPPLIER)
            {
                returnSupplier.clearOtherExport();
            }
            clearInforDrugsSupplies();
            // Khai báo biến bindingDataGrid để lưu trữ dữ liệu
            bindingDataGrid = new BindingList<StockOrderDetailModel>();
            // Request
            infoProduct = new ProductRequest();
            stockRequest = new StockRequest();
            inventoryAddRequest = new InventoryAddRequest();
            inventoryTransferRequest = new InventoryTransferRequest();
            inventoryExportPatientRequest = new InventoryExportPatientRequest();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                    // Gọi thêm thông tin thuốc, vật tư
                    addInforDrugsSupplies();
                    return true;
                case Keys.F2:
                    // Gọi lưu ở đây
                    create_Stock();
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

        private void cbbStock_SelectedValueChanged(int selectedIndex)
        {
            if (stockRequest.productStockOrdersRequest != null)
            {
                stockRequest.productStockOrdersRequest.StockId = selectedIndex;
            }
        }

        private void cbbSupplier_SelectedValueChanged(int selectedIndex)
        {
            if (stockRequest.productStockOrdersRequest != null)
            {
                stockRequest.productStockOrdersRequest.SupplierId = selectedIndex;
            }
        }

        private void txtBillsNumber_Leave(string textChange)
        {
            if (stockRequest.productStockOrdersRequest != null)
            {
                stockRequest.productStockOrdersRequest.Code = textChange;
            }
        }

        private void txtDeliver_Leave(string textChange)
        {
            if (stockRequest.productStockOrdersRequest != null)
            {
                stockRequest.productStockOrdersRequest.Deliver = textChange;
            }
        }

        private void dpkOrderDate_Leave(string textChange)
        {
            if (stockRequest.productStockOrdersRequest != null)
            {
                stockRequest.productStockOrdersRequest.OrderDate = DateTime.Parse(textChange);
            }
        }

        private void txtReceiver_Leave(string textChange)
        {
            if (stockRequest.productStockOrdersRequest != null)
            {
                stockRequest.productStockOrdersRequest.Receiver = textChange;
            }
        }

        private void mmDescription_Leave(string textChange)
        {
            if (stockRequest.inventoryTransferRequest != null)
            {
                stockRequest.inventoryTransferRequest.Note = textChange;
            }
        }

        private void StockOrderDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Người dùng đang đóng form
                onChildWindowClosed();
            }
        }

        private void cbbBidId_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbBidId.SelectedIndex != -1)
            {
                txtContractorGroup.Text = _cbbBidId.ElementAt(cbbBidId.SelectedIndex).BidGroup;
                txtBidDecisionNumber.Text = _cbbBidId.ElementAt(cbbBidId.SelectedIndex).BidNumber;
                txtBidYear.Text = _cbbBidId.ElementAt(cbbBidId.SelectedIndex).BidYear;
            }
        }
    }
}