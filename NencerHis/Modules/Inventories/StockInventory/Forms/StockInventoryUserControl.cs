using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using NencerHis.Modules.CommonManager;
using NencerHis.Modules.Inventories.StockInventory.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace NencerHis.Modules.Inventories.StockInventory.Forms
{
    public partial class StockInventoryUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        // API url
        public const string URL = "http://localhost:5294/";

        // List
        List<StockInventoryModel> _stockInventoryData = new List<StockInventoryModel>();

        private int totalCount = 0;

        // khai báo biến
        public int TotalCount
        {
            get
            {
                return paginationControl.TotalCount;
            }
        }

        public StockInventoryUserControl()
        {
            InitializeComponent();
            paginationControl.PageChanged += PaginationControl_PageChanged;
        }

        private async void PaginationControl_PageChanged(object sender, EventArgs e)
        {
            // Search data after change page
            await searchData(false);
        }

        private void StockInventoryUserControl_Load(object sender, EventArgs e)
        {
            Init();
            gridViewInventories.OptionsBehavior.ReadOnly = true; // Chỉ đọc
            gridViewInventories.OptionsBehavior.Editable = false; // Không cho phép chỉnh sửa
            gridViewInventories.OptionsBehavior.AllowIncrementalSearch = true; // Cho phép tìm kiếm tăng dần
        }

        private async void Init()
        {
            // Get data init for gridview
            await searchData(false);

            // Set FontStyle
            foreach (GridColumn objCol in gridViewInventories.Columns)
            {
                objCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                objCol.AppearanceHeader.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }
        }

        private async Task searchData(bool isSearchClick)
        {
            // Init StockInventorySearchModel
            StockInventorySearchModel searchModel = new StockInventorySearchModel();
            searchModel.StockId = cbbStock.SelectedIndex == -1 ? -1 : 10;
            // Create SkipCount, MaxResultCount
            if (!isSearchClick || searchModel.StockId == -1)
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

        private async Task getDataGrid(StockInventorySearchModel searchModel)
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
                    HttpResponseMessage response = await client.PostAsync(URL + "api/Stock/Inventory/List", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu từ phản hồi API
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng StockInventoryModel
                        _stockInventoryData = JsonConvert.DeserializeObject<List<StockInventoryModel>>(apiResponse);

                        // Gán dữ liệu vào gridSupplier.DataSource
                        gridInventories.DataSource = _stockInventoryData;

                        // Code để ẩn một cột trong GridView
                        var totalCountColumn = gridViewInventories.Columns["TotalCount"];
                        if (totalCountColumn != null)
                        {
                            totalCountColumn.Visible = false;
                        }

                        // Reload paging
                        if ((_stockInventoryData != null && _stockInventoryData.Any()))
                        {
                            totalCount = _stockInventoryData[0].TotalCount;
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
    }
}
