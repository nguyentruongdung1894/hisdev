using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using NencerHis.Modules.CommonManager;
using NencerHis.Modules.Inventories.StockOrder.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace NencerHis.Modules.Inventories.StockOrder.Forms
{
    public partial class StockOdersUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        // API url
        public const string URL = "http://localhost:5294/";
        // Const
        private const string RECEIPT = "Nhập";
        private const string DELIVERY = "Xuất";
        private const string STOCK_TRANSFER = "Chuyển kho";
        private const string WAITING = "Chờ nhập kho";
        private const string WAREHOUSED = "Đã nhập kho";
        private const string RELEASED = "Đã xuất kho";
        private const string IMPORTSUPPLIER = "ImportSupplier";
        private const string IMPORTPROGRAM = "ImportProgram";
        private const string IMPORTANOTHERWAREHOUSE = "ImportAnotherWarehouse";
        private const string EXPORTCUSTOMERS = "ExportCustomers";
        private const string CANCELEXPORT = "CancelExport";
        private const string OTHEREXPORT = "OtherExport";
        private const string RETURNSUPPLIER = "ReturnSupplier";

        // List
        List<StockOdersModel> _stockOdersData = new List<StockOdersModel>();
        private int totalCount = 0;

        // khai báo biến
        public int TotalCount
        {
            get
            {
                return paginationControl.TotalCount;
            }
        }

        public StockOdersUserControl()
        {
            InitializeComponent();
            paginationControl.PageChanged += PaginationControl_PageChanged;
        }

        private async void PaginationControl_PageChanged(object sender, EventArgs e)
        {
            // Search data after change page
            await searchData(false);
        }

        private void StockOdersUserControl_Load(object sender, EventArgs e)
        {
            Init();
            gridViewStockOders.OptionsBehavior.ReadOnly = true; // Chỉ đọc
            gridViewStockOders.OptionsBehavior.Editable = false; // Không cho phép chỉnh sửa
            gridViewStockOders.OptionsBehavior.AllowIncrementalSearch = true; // Cho phép tìm kiếm tăng dần
        }

        private async void Init()
        {
            // Set default date
            dpkSearchFromDate.DateTime = new DateTime(2000, 1, 1);
            dpkSearchToDate.DateTime = DateTime.Now;

            // Create combobox
            createcbbSearchType();

            // Get data init for gridview
            await searchData(false);

            // Set focus init
            cbbAdd.Focus();

            // Set FontStyle
            foreach (GridColumn objCol in gridViewStockOders.Columns)
            {
                objCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                objCol.AppearanceHeader.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }
        }

        private void createcbbSearchType()
        {
            // Tạo danh sách các đối tượng Bảo hiểm và Tự nguyện
            List<ComboBoxModel> listComboBox = new List<ComboBoxModel>
            {
                new ComboBoxModel(0, string.Empty),
                new ComboBoxModel(1, RECEIPT),
                new ComboBoxModel(2, DELIVERY),
                new ComboBoxModel(3, STOCK_TRANSFER),
            };
            // Thêm các tên của đối tượng vào ComboBoxEdit
            foreach (var cmb in listComboBox)
            {
                cbbSearchType.Properties.Items.Add(cmb.Value);
            }
            // Chọn giá trị mặc định là blank
            cbbSearchType.SelectedIndex = 0;
        }

        private async Task searchData(bool isSearchClick)
        {
            // Init SearchStockOdersModel
            SearchStockOdersModel searchModel = new SearchStockOdersModel();
            searchModel.Type = cbbSearchType.SelectedIndex;
            // Create SkipCount, MaxResultCount
            if (!isSearchClick || searchModel.Type <= 0)
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

        private async Task getDataGrid(SearchStockOdersModel searchModel)
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
                    HttpResponseMessage response = await client.PostAsync(URL + "api/Stock/StockOrder/List", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu từ phản hồi API
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng StockOdersModel
                        _stockOdersData = JsonConvert.DeserializeObject<List<StockOdersModel>>(apiResponse);

                        // Gọi hàm ánh xạ giá trị enum thành chuỗi tương ứng
                        foreach (var item in _stockOdersData)
                        {
                            item.Coupon = ConvertCouponShowGrid(item.Coupon);
                            item.Status = ConvertStatusShowGrid(item.Status);
                        }

                        // Gán dữ liệu vào gridViewStockOders.DataSource
                        gridStockOders.DataSource = _stockOdersData;

                        // Code để ẩn một cột trong GridView
                        var totalCountColumn = gridViewStockOders.Columns["TotalCount"];
                        if (totalCountColumn != null)
                        {
                            totalCountColumn.Visible = false;
                        }

                        // Reload paging
                        if ((_stockOdersData != null && _stockOdersData.Any()))
                        {
                            totalCount = _stockOdersData[0].TotalCount;
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

        private string ConvertCouponShowGrid(string coupon)
        {
            switch (coupon)
            {
                case "1":
                    return RECEIPT;
                case "2":
                    return DELIVERY;
                case "3":
                    return STOCK_TRANSFER;
                default:
                    return string.Empty;
            }
        }

        private string ConvertStatusShowGrid(string status)
        {
            switch (status)
            {
                case "1":
                    return WAITING;
                case "2":
                    return WAREHOUSED;
                case "3":
                    return RELEASED;
                default:
                    return string.Empty;
            }
        }

        private void cbbAdd_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbAdd.SelectedIndex == 1)
            {
                openChildWindow(IMPORTSUPPLIER);
            }
            else if (cbbAdd.SelectedIndex == 2)
            {
                openChildWindow(IMPORTPROGRAM);
            }
            else if (cbbAdd.SelectedIndex == 3)
            {
                openChildWindow(IMPORTANOTHERWAREHOUSE);
            }
            else if (cbbAdd.SelectedIndex == 4)
            {
                openChildWindow(EXPORTCUSTOMERS);
            }
            else if (cbbAdd.SelectedIndex == 5)
            {
                openChildWindow(CANCELEXPORT);
            }
            else if (cbbAdd.SelectedIndex == 6)
            {
                openChildWindow(OTHEREXPORT);
            }
            else if (cbbAdd.SelectedIndex == 7)
            {
                openChildWindow(RETURNSUPPLIER);
            }
        }

        private void openChildWindow(string isType)
        {
            StockOrderDetailForm stockOrderDetailForm = new StockOrderDetailForm();
            stockOrderDetailForm.childWindowClosed += childWindowClosedHandler;
            stockOrderDetailForm.SetIsType(isType).Show();
        }

        private void childWindowClosedHandler(object sender, EventArgs e)
        {
            // Get data init for gridview
            searchData(false);

            // Init cbbAdd
            cbbAdd.SelectedIndex = 0;
            // Set default date
            cbbSearchType.SelectedIndex = -1;
            dpkSearchFromDate.DateTime = new DateTime(2000, 1, 1);
            dpkSearchToDate.DateTime = DateTime.Now;
        }

        private void gridViewStockOders_DoubleClick(object sender, EventArgs e)
        {
            var isClickHeader = gridViewStockOders.CalcHitInfo(gridViewStockOders.GridControl.PointToClient(Control.MousePosition));
            if (!isClickHeader.InColumn)
            {
                var index = gridViewStockOders.FocusedRowHandle;
                if (index != -1)
                {
                    // Lấy FocusedRowHandle để biết dòng đang được chọn
                    int focusedRowHandle = gridViewStockOders.FocusedRowHandle;

                    // Lấy giá trị ID từ cột ID của dòng đang được chọn
                    object idValue = gridViewStockOders.GetRowCellValue(focusedRowHandle, "Id");

                    // Ép kiểu giá trị ID theo kiểu int
                    int stockOdersId = Convert.ToInt32(idValue);

                    openApproveInventoryForm(stockOdersId);
                }
            }
        }

        private void openApproveInventoryForm(int stockOdersId)
        {
            ApproveInventoryForm approveInventory = new ApproveInventoryForm();
            approveInventory.approveInventoryFormClosed += approveInventoryFormClosedHandler;
            approveInventory.SetStockOdersId(stockOdersId).Show();
        }

        private void approveInventoryFormClosedHandler(object sender, EventArgs e)
        {
            // Get data init for gridview
            searchData(false);
        }
    }
}
