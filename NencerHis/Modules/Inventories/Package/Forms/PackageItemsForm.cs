using DevExpress.Mvvm.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using NencerHis.Modules.CommonManager;
using NencerHis.Modules.Inventories.Package.Models;
using NencerHis.Modules.Inventories.Package.Models.Request;
using NencerHis.Modules.Inventories.Product.Models;
using NencerHis.Modules.Inventories.Supplier.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Net.Http;
using System.Text;

namespace NencerHis.Modules.Inventories.Package.Forms
{
    public partial class PackageItemsForm : DevExpress.XtraEditors.XtraForm
    {
        // API url
        public const string URL = "http://localhost:5294/";

        // List
        List<ProductModel> _cbbProductData = new List<ProductModel>();
        List<SupplierModel> _cbbSupplierData = new List<SupplierModel>();
        // Lấy danh sách các mục đã chọn
        List<string> selectedProductNames = new List<string>();

        // Khai báo biến bindingDataGrid để lưu trữ dữ liệu
        BindingList<ProductBidsItemsModel> bindingDataGrid = new BindingList<ProductBidsItemsModel>();

        // Request
        ProductBidsRequest productBidsRequest = new ProductBidsRequest();

        // Event close form
        public event EventHandler childWindowClosed;

        // Khai báo biến
        public int TotalCount
        {
            get
            {
                return paginationControl.TotalCount;
            }
        }
        public int CurrentPage
        {
            get
            {
                return paginationControl.CurrentPage;
            }
        }

        public PackageItemsForm()
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
            gridProductBidItems.DataSource = bindingDataGrid.Skip(paginationControl.SkipCount)
                                        .Take(paginationControl.MaxResultCount)
                                        .ToList();

            // Reload paging
            paginationControl.RefreshPaging((bindingDataGrid != null && bindingDataGrid.Any()) ? bindingDataGrid.Count : 0);
        }

        private void gridProductBidItems_Load(object sender, EventArgs e)
        {
            Init();
        }

        private async void Init()
        {
            // Create combobox
            await createCbbSupplier();
            await createcbbProductName();

            // Set FontStyle
            foreach (GridColumn objCol in gridViewProductBidItems.Columns)
            {
                objCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                objCol.AppearanceHeader.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }
        }

        private async Task createCbbSupplier()
        {
            // Init SearchSupplierModel
            SearchSupplierModel searchModel = new SearchSupplierModel();
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
                    HttpResponseMessage response = await client.PostAsync(URL + "api/Product/Supplier/List", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu từ phản hồi API
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng SupplierModel
                        _cbbSupplierData = JsonConvert.DeserializeObject<List<SupplierModel>>(apiResponse);

                        // Thêm các mục từ danh sách vào ComboBoxEdit
                        foreach (var item in _cbbSupplierData)
                        {
                            cbbSupplier.Properties.Items.Add(item.Name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private async Task createcbbProductName()
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
                    HttpResponseMessage response = await client.PostAsync(URL + "api/Product/GetAll", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu từ phản hồi API
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng ProductModel
                        _cbbProductData = JsonConvert.DeserializeObject<List<ProductModel>>(apiResponse);

                        // Thêm các mục từ danh sách vào ComboBoxEdit
                        for (int i = 0; i < _cbbProductData.Count; i++)
                        {
                            CheckedListBoxItem item = new CheckedListBoxItem(_cbbProductData[i].Name, false);
                            item.Tag = i; // Lưu index vào Tag của mỗi item
                            cbbProductName.Properties.Items.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void cbbProductName_CloseUp(object sender, CloseUpEventArgs e)
        {
            // Kiểm tra xem người dùng đã nhấn nút "OK" hay không
            if (e.CloseMode == PopupCloseMode.Normal)
            {
                // Nếu infoProduct có giá trị, thêm vào danh sách và cập nhật DataGridView
                int currentPage = 1;

                // Khởi tạo lại BindingList<ProductBidsItemsModel>
                bindingDataGrid = new BindingList<ProductBidsItemsModel>();

                // Lặp qua từng mục trong CheckedComboBoxEdit
                foreach (CheckedListBoxItem item in cbbProductName.Properties.Items)
                {
                    if (item.CheckState == CheckState.Checked)
                    {
                        // Nếu mục đã được chọn, thêm vào danh sách
                        selectedProductNames.Add(item.Value.ToString());
                    }
                }

                // Lấy danh sách các mục đã chọn
                List<int> selectedProductIndexes = new List<int>();

                // Lặp qua từng mục trong CheckedComboBoxEdit
                for (int i = 0; i < cbbProductName.Properties.Items.Count; i++)
                {
                    CheckedListBoxItem item = cbbProductName.Properties.Items[i] as CheckedListBoxItem;
                    if (item != null && item.CheckState == CheckState.Checked)
                    {
                        // Nếu mục đã được chọn, thêm index vào danh sách
                        selectedProductIndexes.Add((int)item.Tag);
                    }
                }

                if (selectedProductIndexes.Count > 0)
                {
                    // Thực hiện một số hành động với danh sách các index đã chọn
                    foreach (int selectedIndex in selectedProductIndexes)
                    {
                        // Thêm vào grid dựa trên index
                        if (selectedIndex >= 0 && selectedIndex < _cbbProductData.Count)
                        {
                            bindingDataGrid.Add(setDataForGrid(_cbbProductData[selectedIndex]));
                        }
                    }

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
                    gridProductBidItems.DataSource = bindingDataGrid.Skip(skipValue)
                                                .Take(paginationControl.MaxResultCount)
                                                .ToList();

                    // Thêm định dạng số tiền
                    formatPrice();

                    // Cập nhật hiển thị DataGridView
                    gridProductBidItems.Refresh();
                }

                // Reload paging
                paginationControl.SetCurrentPage(currentPage + 1);
                paginationControl.RefreshPaging((bindingDataGrid != null && bindingDataGrid.Any()) ? bindingDataGrid.Count : 0);

                // Focus product name
                cbbProductName.Focus();
            }
        }

        private void formatPrice()
        {
            var columnsToFormat = new string[] { "Price", "PriceIns", "TotalPrice" };

            foreach (var columnName in columnsToFormat)
            {
                var column = gridViewProductBidItems.Columns[columnName] as GridColumn;

                if (column != null)
                {
                    column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    column.DisplayFormat.FormatString = "N2";
                }
            }
        }

        private ProductBidsItemsModel setDataForGrid(ProductModel productModel)
        {
            ProductBidsItemsModel productBidsItemsModel = new ProductBidsItemsModel();
            productBidsItemsModel.ProductId = productModel.ID;
            productBidsItemsModel.ProductName = productModel.Name;
            productBidsItemsModel.Qty = 1;
            productBidsItemsModel.Vat = 0;
            productBidsItemsModel.Unit = productModel.Unit;
            productBidsItemsModel.Price = productModel.Price;
            productBidsItemsModel.PriceIns = productModel.PriceIns;
            productBidsItemsModel.TotalPrice = productModel.Price;
            productBidsItemsModel.Status = 1;

            return productBidsItemsModel;
        }

        private void gridViewProductBidItems_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Qty")
            {
                int rowHandle = e.RowHandle;

                // Lấy giá trị mới của "Quantity"
                int? newQuantity = e.Value as int?;

                // Kiểm tra giá trị mới của "Quantity"
                if (newQuantity.HasValue && rowHandle >= 0)
                {
                    // Lấy giá trị hiện tại của "Price"
                    decimal? price = gridViewProductBidItems.GetRowCellValue(rowHandle, "Price") as decimal?;

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
                        gridViewProductBidItems.RefreshData();
                    }
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            // Gọi lưu ở đây
            await create_ProductBids();
        }

        private void btnAddAndPrint_Click(object sender, EventArgs e)
        {
            // Call func add/ print
            actionAdd_Print_Click();
        }

        private async Task actionAdd_Print_Click()
        {
            // Gọi lưu ở đây
            await create_ProductBids();

            // Print
            Common.ShowMessageSuccess("In thành công!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearDataHeader();
        }

        private void clearDataHeader()
        {

        }

        private async Task create_ProductBids()
        {
            productBidsRequest = new ProductBidsRequest();

            productBidsRequest.Id = 0;
            productBidsRequest.ProductId = 0;
            productBidsRequest.SupplierId = cbbSupplier.SelectedIndex != -1 ? _cbbSupplierData.ElementAt(cbbSupplier.SelectedIndex)?.ID : null;
            // Kiểm tra xem đã nhập mã gói thầu chưa
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                // Show alter warning
                Common.ShowMessageWarning("Bạn chưa nhập mã gói thầu.");
                txtCode.Focus();
                return;
            }
            else
            {
                productBidsRequest.Code = txtCode.Text;
            }
            productBidsRequest.Name = txtName.Text;
            productBidsRequest.BidNumber = txtBidNumber.Text;
            productBidsRequest.BidGroup = txtBidGroup.Text;
            productBidsRequest.BidPackage = txtBidPackage.Text;
            if (!string.IsNullOrEmpty(deBidDate.Text))
            {
                productBidsRequest.BidDate = DateTime.Parse(deBidDate.Text);
            }
            productBidsRequest.BidYear = txtBidYear.Text;
            productBidsRequest.Description = mmNote.Text;
            productBidsRequest.Status = 1;
            productBidsRequest.Items = createPatientItems();

            // Khởi tạo HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Init Url
                    string json = JsonConvert.SerializeObject(productBidsRequest);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Gửi yêu cầu GET đến API
                    HttpResponseMessage response = await client.PostAsync(URL + "api/Product/ProductBid/Create", content);

                    // Deserialize chuỗi JSON thành một đối tượng JObject
                    JObject responseObject = JObject.Parse(await response.Content.ReadAsStringAsync());

                    if (response.IsSuccessStatusCode)
                    {
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
                    else
                    {
                        // Show alter success
                        Common.ShowMessageWarning((string)responseObject["message"]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private List<ProductBidsItemsRequest> createPatientItems()
        {
            var lstProductBidsItemsRequest = new List<ProductBidsItemsRequest>();

            bindingDataGrid.ForEach((data, index) =>
            {
                var productBidsItems = new ProductBidsItemsRequest();
                productBidsItems.Id = 0;
                productBidsItems.BidId = 0;
                productBidsItems.ProductId = data.ProductId.Value;
                productBidsItems.Quantity = data.Qty.Value;
                productBidsItems.Vat = data.Vat.Value;
                productBidsItems.Unit = data.Unit;
                productBidsItems.Price = data.Price.Value;
                productBidsItems.PriceIns = data.PriceIns.Value;
                productBidsItems.Status = 1;

                lstProductBidsItemsRequest.Add(productBidsItems);
            });

            return lstProductBidsItemsRequest;
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
    }
}