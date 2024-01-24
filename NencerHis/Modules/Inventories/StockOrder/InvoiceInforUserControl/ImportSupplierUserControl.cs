using NencerHis.Modules.Inventories.StockOrder.Models;
using NencerHis.Modules.Inventories.StockOrder.Models.Request;
using NencerHis.Modules.Inventories.Supplier.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace NencerHis.Modules.Inventories.StockOrder.InvoiceInforUserControl
{
    public partial class ImportSupplierUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        // API url
        public const string URL = "http://localhost:5294/";

        // List
        List<StockModel> _cbbStockData = new List<StockModel>();
        List<SupplierModel> _cbbSupplierData = new List<SupplierModel>();

        // Sử dụng Tuple để truyền nhiều giá trị
        public event EventHandler<(int SelectedIndex, string SelectedName)> SelectedValueChanged;
        public event EventHandler<(string TextChange, string TextName)> TextValueChanged;

        public ImportSupplierUserControl()
        {
            InitializeComponent();
        }

        private void ImportSupplierUserControl_Load(object sender, EventArgs e)
        {
            Init();
        }

        private async void Init()
        {
            // Init OrderDate
            dpkOrderDate.DateTime = DateTime.Now;

            // Create combobox
            await createcbbStock();
            await createcbbSupplier();

            // Set focus init
            cbbStock.Focus();
        }

        private async Task createcbbStock()
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
                    HttpResponseMessage response = await client.PostAsync(URL + "api/Stock/List", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu từ phản hồi API
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng StockModel
                        _cbbStockData = JsonConvert.DeserializeObject<List<StockModel>>(apiResponse);

                        // Thêm các mục từ danh sách vào ComboBoxEdit
                        foreach (var item in _cbbStockData)
                        {
                            cbbStock.Properties.Items.Add(item.Name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private async Task createcbbSupplier()
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

        public ProductStockOrdersRequest createProductStockOrders()
        {
            ProductStockOrdersRequest productStockOrders = new ProductStockOrdersRequest();

            productStockOrders.StockId = cbbStock.SelectedIndex != -1 ? _cbbStockData.ElementAt(cbbStock.SelectedIndex)?.Id : -1;
            productStockOrders.SupplierId = cbbSupplier.SelectedIndex != -1 ? _cbbSupplierData.ElementAt(cbbSupplier.SelectedIndex).ID : -1;
            productStockOrders.Code = txtBillsNumber.Text;
            if (!string.IsNullOrEmpty(dpkOrderDate.Text))
            {
                productStockOrders.OrderDate = DateTime.Parse(dpkOrderDate.Text);
            }
            productStockOrders.Receiver = txtReceiver.Text;
            productStockOrders.Deliver = txtDeliver.Text;

            return productStockOrders;
        }

        public void clearProductStockOrders()
        {
            // Row 1
            cbbStock.SelectedIndex = -1;
            txtBillsNumber.Text = string.Empty;
            dpkOrderDate.Text = string.Empty;
            // Row 2
            cbbSupplier.SelectedIndex = -1;
            txtDeliver.Text = string.Empty;
            txtReceiver.Text = string.Empty;
        }

        public void cbbStockFocus()
        {
            cbbStock.Focus();
        }

        public void cbbSupplierFocus()
        {
            cbbSupplier.Focus();
        }

        public void txtBillsNumberFocus()
        {
            txtBillsNumber.Focus();
        }

        private void cbbStock_SelectedValueChanged(object sender, EventArgs e)
        {
            // Lấy giá trị đã chọn từ ComboBox
            int selectedIndex = _cbbStockData.ElementAt(cbbStock.SelectedIndex).Id;
            string selectedName = "cbbStock";

            // Gọi sự kiện và truyền giá trị bằng cách sử dụng Tuple
            SelectedValueChanged?.Invoke(this, (selectedIndex, selectedName));
        }

        private void cbbSupplier_SelectedValueChanged(object sender, EventArgs e)
        {
            // Lấy giá trị đã chọn từ ComboBox
            int selectedIndex = _cbbSupplierData.ElementAt(cbbSupplier.SelectedIndex).ID;
            string selectedName = "cbbSupplier";

            // Gọi sự kiện và truyền giá trị bằng cách sử dụng Tuple
            SelectedValueChanged?.Invoke(this, (selectedIndex, selectedName));
        }

        private void txtBillsNumber_Leave(object sender, EventArgs e)
        {
            // Lấy giá trị đã nhập từ textbox
            string textChange = txtBillsNumber.Text;
            string textName = "txtBillsNumber";

            // Gọi sự kiện và truyền giá trị bằng cách sử dụng Tuple
            TextValueChanged?.Invoke(this, (textChange, textName));
        }

        private void txtDeliver_Leave(object sender, EventArgs e)
        {
            // Lấy giá trị đã nhập từ textbox
            string textChange = txtDeliver.Text;
            string textName = "txtDeliver";

            // Gọi sự kiện và truyền giá trị bằng cách sử dụng Tuple
            TextValueChanged?.Invoke(this, (textChange, textName));
        }

        private void dpkOrderDate_Leave(object sender, EventArgs e)
        {
            // Lấy giá trị đã chọn từ date time picker
            string textChange = dpkOrderDate.Text;
            string textName = "dpkOrderDate";

            // Gọi sự kiện và truyền giá trị bằng cách sử dụng Tuple
            TextValueChanged?.Invoke(this, (textChange, textName));
        }

        private void txtReceiver_Leave(object sender, EventArgs e)
        {
            // Lấy giá trị đã nhập từ textbox
            string textChange = txtReceiver.Text;
            string textName = "txtReceiver";

            // Gọi sự kiện và truyền giá trị bằng cách sử dụng Tuple
            TextValueChanged?.Invoke(this, (textChange, textName));
        }
    }
}
