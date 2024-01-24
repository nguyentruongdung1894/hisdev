using DevExpress.XtraEditors;
using NencerHis.Modules.ExaminationManager.ExaminationListUser.Models;
using NencerHis.Modules.ExaminationManager.ExaminationUser;
using NencerHis.Modules.ExaminationManager.Handle;
using NencerHis.Modules.ExaminationManager.PatientInfo;
using NencerHis.Modules.ExaminationManager.Prescription;
using NencerHis.Modules.ExaminationManager.ServiceUser;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace NencerHis.Modules.ExaminationManager.ExaminationListUser.Forms
{
    public partial class ExaminationListUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        // API url
        public const string URL = "http://localhost:5294/";

        // List
        List<ExaminationPatientsModel> _examinationPatients = new List<ExaminationPatientsModel>();

        public ExaminationListUserControl()
        {
            InitializeComponent();
        }

        private void ctlKhamBenh_Load(object sender, EventArgs e)
        {
            // Thêm các tab
            addMultiTab();

            // Load data for nav left
            loadDataForNavLeft();
        }

        private void addMultiTab()
        {
            TabPageTTBenhNhan.Controls.Add(new PatientInfoUserControl() { Dock = DockStyle.Fill });
            TabPageKhamBenh.Controls.Add(new ExaminationUserControl() { Dock = DockStyle.Fill });
            TabPageDonThuoc.Controls.Add(new PrescriptionUserControl() { Dock = DockStyle.Fill });
            TabPageService.Controls.Add(new ServiceUserControl() { Dock = DockStyle.Fill });
            TabPageXuTri.Controls.Add(new HandleUserControl() { Dock = DockStyle.Fill });
        }

        private async Task loadDataForNavLeft()
        {
            ExaminationPatientsSearchModel searchModel = new ExaminationPatientsSearchModel();
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
                    HttpResponseMessage response = await client.PostAsync(URL + "api/Examination/GetList", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu từ phản hồi API
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Chuyển đổi dữ liệu JSON từ API thành danh sách đối tượng ExaminationPatientsModel
                        _examinationPatients = JsonConvert.DeserializeObject<List<ExaminationPatientsModel>>(apiResponse);

                        List<ExaminationPatientsModel> lstExaminationPatients = new List<ExaminationPatientsModel>();

                        foreach (var item in _examinationPatients)
                        {
                            ExaminationPatientsModel examinationPatients = new ExaminationPatientsModel();
                            examinationPatients = item;

                            switch (item.Status)
                            {
                                case "PENDING":
                                    examinationPatients.imageIcon = imageCollection1.Images[0];
                                    break;
                                case "PROCESSING":
                                    examinationPatients.imageIcon = imageCollection1.Images[1];
                                    break;
                                case "CANCELLED":
                                    examinationPatients.imageIcon = imageCollection1.Images[2];
                                    break;
                                case "FINISHED":
                                    examinationPatients.imageIcon = imageCollection1.Images[2];
                                    break;
                                default:
                                    examinationPatients.imageIcon = imageCollection1.Images[2];
                                    break;
                            }

                            lstExaminationPatients.Add(examinationPatients);
                        }

                        gcDSKH_TatCa.DataSource = lstExaminationPatients;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void gvDSKH_TatCa_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gvDSKH_TatCa_Click(object sender, EventArgs e)
        {

        }

        // Xử lý sự kiện ButtonClick
        private void gcDSKH_TatCa_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            // Kiểm tra nút được nhấn là Next hoặc Prev
            if (e.Button.ButtonType == NavigatorButtonType.Next)
            {
                // Xử lý sự kiện khi nhấn nút Next
                // Đặt mã xử lý của bạn ở đây
                MessageBox.Show("Next button clicked");
            }
            else if (e.Button.ButtonType == NavigatorButtonType.Prev)
            {
                // Xử lý sự kiện khi nhấn nút Prev
                // Đặt mã xử lý của bạn ở đây
                MessageBox.Show("Prev button clicked");
            }
        }
    }
}
