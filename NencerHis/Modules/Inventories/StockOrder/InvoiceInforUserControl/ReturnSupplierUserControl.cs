using NencerHis.Modules.Inventories.StockOrder.Models;
using NencerHis.Modules.Inventories.StockOrder.Models.Request;
using NencerHis.Modules.Inventories.Supplier.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace NencerHis.Modules.Inventories.StockOrder.InvoiceInforUserControl
{
    public partial class ReturnSupplierUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        // API url
        public const string URL = "http://localhost:5294/";

        // List
        List<StockModel> _cbbStockOutputData = new List<StockModel>();
        List<SupplierModel> _cbbSupplierData = new List<SupplierModel>();

        // Sử dụng Tuple để truyền nhiều giá trị
        public event EventHandler<(int StockValue, int SupplierValue, string SelectedName)> SelectedStockValueChanged;

        public ReturnSupplierUserControl()
        {
            InitializeComponent();
        }

        private void ReturnSupplierUserControl_Load(object sender, EventArgs e)
        {
            Init();
        }

        private async void Init()
        {
            await createCbbStockOutput();
            await createCbbSupplier();

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

        public void clearOtherExport()
        {
            // Row 1
            cbbStockOutput.SelectedIndex = -1;
            cbbSupplier.SelectedIndex = -1;
            txtReceiver.Text = string.Empty;
            mmDescription.Text = string.Empty;
        }

        public InventoryExportCancelRequest createInventoryExportCancelRequest()
        {
            InventoryExportCancelRequest inventoryExportCancelRequest = new InventoryExportCancelRequest();

            inventoryExportCancelRequest.StockId = _cbbStockOutputData.ElementAt(cbbStockOutput.SelectedIndex).Id;
            inventoryExportCancelRequest.Supplier_id = _cbbSupplierData.ElementAt(cbbSupplier.SelectedIndex).ID;
            inventoryExportCancelRequest.Receiver = txtReceiver.Text;
            inventoryExportCancelRequest.Status = 4;
            inventoryExportCancelRequest.Note = mmDescription.Text;

            return inventoryExportCancelRequest;
        }

        public void cbbStockOutputFocus()
        {
            cbbStockOutput.Focus();
        }

        public void cbbSupplierFocus()
        {
            cbbSupplier.Focus();
        }

        public void txtReceiverFocus()
        {
            txtReceiver.Focus();
        }
        private void cbbStockOutput_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbStockOutput.SelectedIndex != -1 && cbbSupplier.SelectedIndex != -1)
            {
                // Lấy giá trị đã chọn từ ComboBox
                int selectedStock = _cbbStockOutputData.ElementAt(cbbStockOutput.SelectedIndex).Id;
                int selectedSupplier = _cbbSupplierData.ElementAt(cbbSupplier.SelectedIndex).ID;
                string selectedName = "cbbStockOutput";
                // Gọi sự kiện và truyền giá trị bằng cách sử dụng Tuple
                SelectedStockValueChanged?.Invoke(this, (selectedStock, selectedSupplier, selectedName));
            }
        }

        private void cbbSupplier_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbSupplier.SelectedIndex != -1 && cbbStockOutput.SelectedIndex != -1)
            {
                // Lấy giá trị đã chọn từ ComboBox
                int selectedSupplier = _cbbSupplierData.ElementAt(cbbSupplier.SelectedIndex).ID;
                int selectedStock = _cbbStockOutputData.ElementAt(cbbStockOutput.SelectedIndex).Id;
                string selectedName = "cbbSupplier";
                // Gọi sự kiện và truyền giá trị bằng cách sử dụng Tuple
                SelectedStockValueChanged?.Invoke(this, (selectedStock, selectedSupplier, selectedName));
            }
        }
    }
}
