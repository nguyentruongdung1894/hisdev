using NencerHis.Modules.CommonManager;
using NencerHis.Modules.Inventories.StockOrder.Models;
using NencerHis.Modules.Inventories.StockOrder.Models.Request;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace NencerHis.Modules.Inventories.StockOrder.InvoiceInforUserControl
{
    public partial class ImportAnotherWarehouseUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        // API url
        public const string URL = "http://localhost:5294/";

        // List
        List<StockModel> _cbbStockInputData = new List<StockModel>();
        List<StockModel> _cbbStockOutputData = new List<StockModel>();

        // Sử dụng Tuple để truyền nhiều giá trị
        public event EventHandler<(int SelectValue, string SelectedName)> SelectedStockValueChanged;
        public event EventHandler<(string TextChange, string TextName)> TextValueChanged;

        public ImportAnotherWarehouseUserControl()
        {
            InitializeComponent();
        }

        private void ImportAnotherWarehouseUserControl_Load(object sender, EventArgs e)
        {
            Init();
        }

        private async void Init()
        {
            // Create combobox
            await createStockInput();
            await createStockOutput();

            // Set focus init
            cbbStockInput.Focus();
        }

        private async Task createStockInput()
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
                        _cbbStockInputData = JsonConvert.DeserializeObject<List<StockModel>>(apiResponse);

                        // Thêm các mục từ danh sách vào ComboBoxEdit
                        foreach (var item in _cbbStockInputData)
                        {
                            cbbStockInput.Properties.Items.Add(item.Name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private async Task createStockOutput()
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

        private void cbbStockInput_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbStockInput.SelectedIndex != -1 && cbbStockInput.SelectedIndex == cbbStockOutput.SelectedIndex)
            {
                // Show alter warning
                Common.ShowMessageWarning("Kho nhập, kho xuất không được giống nhau");
                cbbStockInput.SelectedIndex = -1;
                cbbStockInput.Focus();
            }
        }

        private void cbbStockOutput_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbStockOutput.SelectedIndex != -1 && cbbStockOutput.SelectedIndex == cbbStockInput.SelectedIndex)
            {
                // Show alter warning
                Common.ShowMessageWarning("Kho nhập, kho xuất không được giống nhau");
                // Gọi sự kiện và truyền giá trị bằng cách sử dụng Tuple
                SelectedStockValueChanged?.Invoke(this, (-1, string.Empty));
                cbbStockOutput.SelectedIndex = -1;
                cbbStockOutput.Focus();
            }
            else
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
        }

        public InventoryTransferRequest createInventoryTransferRequest()
        {
            InventoryTransferRequest inventoryTransferRequest = new InventoryTransferRequest();

            inventoryTransferRequest.StockId = _cbbStockInputData.ElementAt(cbbStockInput.SelectedIndex).Id;
            inventoryTransferRequest.TargetStockId = _cbbStockOutputData.ElementAt(cbbStockOutput.SelectedIndex).Id;
            inventoryTransferRequest.Status = 2;
            inventoryTransferRequest.Note = mmDescription.Text;

            return inventoryTransferRequest;
        }

        private void mmDescription_Leave(object sender, EventArgs e)
        {
            // Lấy giá trị đã nhập từ textbox
            string textChange = mmDescription.Text;
            string textName = "mmDescription";

            // Gọi sự kiện và truyền giá trị bằng cách sử dụng Tuple
            TextValueChanged?.Invoke(this, (textChange, textName));
        }

        public void clearInventoryTransferRequest()
        {
            // Row 1
            cbbStockInput.SelectedIndex = -1;
            cbbStockOutput.SelectedIndex = -1;
            mmDescription.Text = string.Empty;
        }

        public void cbbStockInputFocus()
        {
            cbbStockInput.Focus();
        }

        public void cbbStockOutputFocus()
        {
            cbbStockOutput.Focus();
        }
    }
}
