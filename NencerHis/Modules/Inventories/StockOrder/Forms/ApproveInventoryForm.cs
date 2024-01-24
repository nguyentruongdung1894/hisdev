using DevExpress.PivotGrid.OLAP;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using NencerHis.Modules.CommonManager;
using NencerHis.Modules.Inventories.StockOrder.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;

namespace NencerHis.Modules.Inventories.StockOrder.Forms
{
    public partial class ApproveInventoryForm : DevExpress.XtraEditors.XtraForm
    {
        // API url
        public const string URL = "http://localhost:5294/";

        // Event close form
        public event EventHandler approveInventoryFormClosed;

        // IsMode
        private int _stockOdersId = 0;

        // Khai báo biến bindingDataGrid để lưu trữ dữ liệu
        List<StockOrderDetailModel> bindingDataGrid = new List<StockOrderDetailModel>();

        // Khai báo biến
        public int TotalCount
        {
            get
            {
                return paginationControl.TotalCount;
            }
        }

        public ApproveInventoryForm SetStockOdersId(int stockOdersId)
        {
            _stockOdersId = stockOdersId;
            return this;
        }

        public ApproveInventoryForm()
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
            // Set data for grid
            await searchData();
        }

        private void ApproveInventoryForm_Load(object sender, EventArgs e)
        {
            Init();

            gridViewApproveInventory.OptionsBehavior.ReadOnly = true; // Chỉ đọc
            gridViewApproveInventory.OptionsBehavior.Editable = false; // Không cho phép chỉnh sửa
            gridViewApproveInventory.OptionsBehavior.AllowIncrementalSearch = true; // Cho phép tìm kiếm tăng dần
        }

        private async void Init()
        {
            // Set data for grid
            await searchData();

            // Set FontStyle
            foreach (GridColumn objCol in gridViewApproveInventory.Columns)
            {
                objCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                objCol.AppearanceHeader.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }
        }

        private async Task searchData()
        {
            // Init ApproveInventorySearchModel
            ApproveInventorySearchModel searchModel = new ApproveInventorySearchModel();
            searchModel.StockOdersId = _stockOdersId;
            // Create SkipCount, MaxResultCount
            searchModel.SkipCount = paginationControl.SkipCount;
            searchModel.MaxResultCount = paginationControl.MaxResultCount;

            SplashScreenManager.ShowForm(null, typeof(frmStartApp), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Xin vui lòng chờ...");
            // Call pai search
            await getDataGrid(searchModel);
            SplashScreenManager.CloseForm();
        }

        private async Task getDataGrid(ApproveInventorySearchModel searchModel)
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
                    HttpResponseMessage response = await client.PostAsync(URL + "api/Stock/GetProductStockOrderItems/List", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu từ phản hồi API
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng StockOrderDetailModel
                        bindingDataGrid = JsonConvert.DeserializeObject<List<StockOrderDetailModel>>(apiResponse);

                        // Gán dữ liệu vào gridSupplier.DataSource
                        gridApproveInventory.DataSource = bindingDataGrid;

                        // Thêm định dạng số tiền
                        formatPrice();

                        // Reload paging
                        if ((bindingDataGrid != null && bindingDataGrid.Any()))
                        {
                            paginationControl.RefreshPaging(bindingDataGrid[0].TotalCount);
                        }
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
            var columnsToFormat = new string[] { "Price", "TotalPrice" };

            foreach (var columnName in columnsToFormat)
            {
                var column = gridViewApproveInventory.Columns[columnName] as GridColumn;

                if (column != null)
                {
                    column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    column.DisplayFormat.FormatString = "N2";
                }
            }
        }

        private void closeChildWindow()
        {
            this.Close();

            // Kích hoạt sự kiện khi cửa sổ con được đóng
            onApproveInventoryFormClosedClosed();
        }

        // Hàm kích hoạt sự kiện
        protected virtual void onApproveInventoryFormClosedClosed()
        {
            approveInventoryFormClosed?.Invoke(this, EventArgs.Empty);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Đóng Window con
            closeChildWindow();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            // Khởi tạo HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    int orderId = _stockOdersId;
                    string url = $"{URL}api/Stock/ApproveOrder/{orderId}";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        // Deserialize chuỗi JSON thành một đối tượng JObject
                        JObject responseObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                        if ((string)responseObject["responseCode"] == "200")
                        {
                            // Update message
                            string mes = "Nhập kho thành công.";
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
}