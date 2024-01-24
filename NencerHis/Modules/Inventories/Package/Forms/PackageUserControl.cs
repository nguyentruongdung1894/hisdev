using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using NencerHis.Modules.CommonManager;
using NencerHis.Modules.Inventories.Package.Models;
using NencerHis.Modules.Inventories.StockOrder.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace NencerHis.Modules.Inventories.Package.Forms
{
    public partial class PackageUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        // API url
        public const string URL = "http://localhost:5294/";

        // List
        List<ProductBidsModel> _productBidsData = new List<ProductBidsModel>();

        private int totalCount = 0;

        // khai báo biến
        public int TotalCount
        {
            get
            {
                return paginationControl.TotalCount;
            }
        }
        public PackageUserControl()
        {
            InitializeComponent();
            paginationControl.PageChanged += PaginationControl_PageChanged;
        }

        private async void PaginationControl_PageChanged(object sender, EventArgs e)
        {
            // Search data after change page
            await searchData(false);
        }

        private void PackageUserControl_Load(object sender, EventArgs e)
        {
            Init();
            gridViewProductBids.OptionsBehavior.ReadOnly = true; // Chỉ đọc
            gridViewProductBids.OptionsBehavior.Editable = false; // Không cho phép chỉnh sửa
            gridViewProductBids.OptionsBehavior.AllowIncrementalSearch = true; // Cho phép tìm kiếm tăng dần
        }

        private async void Init()
        {
            // Get data init for gridview
            await searchData(false);

            // Set focus init
            txtCode.Focus();

            // Set FontStyle
            foreach (GridColumn objCol in gridViewProductBids.Columns)
            {
                objCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                objCol.AppearanceHeader.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }
        }

        private async Task searchData(bool isSearchClick)
        {
            // Init ProductBidsSearchModel
            ProductBidsSearchModel searchModel = new ProductBidsSearchModel();
            // Create SkipCount, MaxResultCount
            if (!isSearchClick)
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

        private async Task getDataGrid(ProductBidsSearchModel searchModel)
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
                    HttpResponseMessage response = await client.PostAsync(URL + "api/Product/ProductBid/GetAll", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu từ phản hồi API
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng ProductBidsModel
                        _productBidsData = JsonConvert.DeserializeObject<List<ProductBidsModel>>(apiResponse);

                        // Gán dữ liệu vào gridProductBids.DataSource
                        gridProductBids.DataSource = _productBidsData;

                        // Reload paging
                        if ((_productBidsData != null && _productBidsData.Any()))
                        {
                            totalCount = _productBidsData[0].TotalCount;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            openChildWindow();
        }

        private void openChildWindow()
        {
            PackageItemsForm packageItemsForm = new PackageItemsForm();
            packageItemsForm.childWindowClosed += childWindowClosedHandler;
            packageItemsForm.Show();
        }

        private void childWindowClosedHandler(object sender, EventArgs e)
        {
            // Get data init for gridview
            searchData(false);
        }
    }
}
