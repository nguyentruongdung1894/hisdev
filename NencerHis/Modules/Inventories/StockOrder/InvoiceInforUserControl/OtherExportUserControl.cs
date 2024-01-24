using NencerHis.Modules.Inventories.StockOrder.Models;
using NencerHis.Modules.Inventories.StockOrder.Models.Request;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace NencerHis.Modules.Inventories.StockOrder.InvoiceInforUserControl
{
    public partial class OtherExportUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        // API url
        public const string URL = "http://localhost:5294/";

        // List
        List<StockModel> _cbbStockOutputData = new List<StockModel>();

        // Sử dụng Tuple để truyền nhiều giá trị
        public event EventHandler<(int SelectValue, string SelectedName)> SelectedStockValueChanged;

        // Đối với mục đích minh họa, tạo một danh sách cố định chứa 10 lý do xuất khác
        private List<ExportReasonModel> exportReasons = new List<ExportReasonModel>
        {
            new ExportReasonModel { Id = 1, Name = "Lý do 1" },
            new ExportReasonModel { Id = 2, Name = "Lý do 2" },
            new ExportReasonModel { Id = 3, Name = "Lý do 3" },
            new ExportReasonModel { Id = 4, Name = "Lý do 4" },
            new ExportReasonModel { Id = 5, Name = "Lý do 5" },
            new ExportReasonModel { Id = 6, Name = "Lý do 6" },
            new ExportReasonModel { Id = 7, Name = "Lý do 7" },
            new ExportReasonModel { Id = 8, Name = "Lý do 8" },
            new ExportReasonModel { Id = 9, Name = "Lý do 9" },
            new ExportReasonModel { Id = 10, Name = "Lý do 10" },
        };

        public OtherExportUserControl()
        {
            InitializeComponent();
        }

        private void OtherExportUserControl_Load(object sender, EventArgs e)
        {
            Init();
        }

        private async void Init()
        {
            await createCbbStockOutput();
            createCbbReason();

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

        private void createCbbReason()
        {
            // Thêm các mục từ danh sách vào ComboBoxEdit
            foreach (var item in exportReasons)
            {
                cbbReason.Properties.Items.Add(item.Name);
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

        public void clearOtherExport()
        {
            // Row 1
            cbbStockOutput.SelectedIndex = -1;
            cbbReason.SelectedIndex = -1;
            mmDescription.Text = string.Empty;
        }

        public InventoryExportCancelRequest createInventoryExportCancelRequest()
        {
            InventoryExportCancelRequest inventoryExportCancelRequest = new InventoryExportCancelRequest();

            inventoryExportCancelRequest.StockId = _cbbStockOutputData.ElementAt(cbbStockOutput.SelectedIndex).Id;
            inventoryExportCancelRequest.Reason = cbbReason.Text;
            inventoryExportCancelRequest.Status = 4;
            inventoryExportCancelRequest.Note = mmDescription.Text;

            return inventoryExportCancelRequest;
        }

        public void cbbStockOutputFocus()
        {
            cbbStockOutput.Focus();
        }

        public void cbbReasonFocus()
        {
            cbbReason.Focus();
        }
    }
}
