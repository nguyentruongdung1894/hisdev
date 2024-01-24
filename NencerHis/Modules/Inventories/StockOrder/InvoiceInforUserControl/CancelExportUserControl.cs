using NencerHis.Modules.Inventories.StockOrder.Models;
using NencerHis.Modules.Inventories.StockOrder.Models.Request;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace NencerHis.Modules.Inventories.StockOrder.InvoiceInforUserControl
{
    public partial class CancelExportUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        // API url
        public const string URL = "http://localhost:5294/";

        // List
        List<StockModel> _cbbStockOutputData = new List<StockModel>();

        // Sử dụng Tuple để truyền nhiều giá trị
        public event EventHandler<(int SelectValue, string SelectedName)> SelectedStockValueChanged;

        public CancelExportUserControl()
        {
            InitializeComponent();
        }

        private void CancelExportUserControl_Load(object sender, EventArgs e)
        {
            Init();
        }

        private async void Init()
        {
            await createCbbStockOutput();

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

        private void cbbStockOutput_SelectedValueChanged(object sender, EventArgs e)
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

        public void clearCancelExport()
        {
            // Row 1
            cbbStockOutput.SelectedIndex = -1;
            mmDescription.Text = string.Empty;
        }

        public InventoryExportCancelRequest createInventoryExportCancelRequest()
        {
            InventoryExportCancelRequest inventoryExportCancelRequest = new InventoryExportCancelRequest();

            inventoryExportCancelRequest.StockId = _cbbStockOutputData.ElementAt(cbbStockOutput.SelectedIndex).Id;
            inventoryExportCancelRequest.Reason = string.Empty;
            inventoryExportCancelRequest.Status = 4;
            inventoryExportCancelRequest.Note = mmDescription.Text;

            return inventoryExportCancelRequest;
        }

        public void cbbStockOutputFocus()
        {
            cbbStockOutput.Focus();
        }
    }
}
