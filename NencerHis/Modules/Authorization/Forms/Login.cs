using NencerHis.Extensions;
using NencerHis.Helpers;
using Newtonsoft.Json.Linq;
using System.Drawing.Drawing2D;
using System.Net.Http;

namespace NencerHis.Modules.Authorization.Forms
{
    public partial class Login : Form
    {
        // API url
        public const string URL = "http://localhost:5294/";

        public Login()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi");
            InitializeComponent();
            SetFormGradientBackground();

            // Đăng ký sự kiện Resize để gọi lại sự kiện Paint khi form được co giãn
            this.Resize += (sender, e) => { this.Invalidate(); };

            // Kiểm tra xem có lưu pass không
            ShowRememberLogin();

            this.KeyPreview = true; // Đặt KeyPreview thành true để bắt sự kiện KeyPress của form
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Chỉnh màu background form
        /// </summary>
        private void SetFormGradientBackground()
        {
            this.Paint += (sender, e) =>
            {
                if (this.ClientRectangle.Width > 0 && this.ClientRectangle.Height > 0)
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        this.ClientRectangle,
                        Color.FromArgb(2, 0, 36),
                        Color.FromArgb(241, 241, 241),
                        LinearGradientMode.Horizontal))
                    {
                        ColorBlend colorBlend = new ColorBlend();
                        colorBlend.Positions = new[] { 0, 0.0f, 1 };
                        colorBlend.Colors = new[] { Color.FromArgb(241, 241, 241), Color.FromArgb(241, 241, 241), Color.FromArgb(164, 219, 245) };
                        brush.InterpolationColors = colorBlend;

                        e.Graphics.FillRectangle(brush, this.ClientRectangle);
                    }
                }
            };
        }

        private void ShowRememberLogin()
        {
            // Kiểm tra xem có thông tin đăng nhập đã được lưu không
            var savedCredentials = AppSettingManager.GetSavedCredentials();
            if (!string.IsNullOrEmpty(savedCredentials.Username) && !string.IsNullOrEmpty(savedCredentials.Password))
            {
                txtUserName.Texts = savedCredentials.Username;
                txtPassword.Texts = savedCredentials.Password;
                ckRememberMe.Checked = true;

                // Truy cập thuộc tính user
                txtUserName.IsPlaceholder = false;
                txtPassword.IsPlaceholder = false;
                txtPassword.PasswordChar = true;
                txtUserName.ForeColor = Color.FromArgb(64, 64, 64);
                txtPassword.ForeColor = Color.FromArgb(64, 64, 64);
            }
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Thực hiện đăng nhập ở đây
                ActionLoginAsync();
                e.Handled = true; // Ngăn chặn âm thanh mặc định của hệ thống khi nhấn Enter
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ActionLoginAsync();
        }

        private async void ActionLoginAsync()
        {
            try
            {
                if (loadingManager.IsSplashFormVisible)
                {
                    return;
                }
                loadingManager.ShowWaitForm();
                loadingManager.SetWaitFormCaption(LocalExt.Text("Logging"));
                loadingManager.SetWaitFormDescription(LocalExt.Text("PlsWait"));
                var userName = txtUserName.Texts.Trim().ToEmptyWhenNull();
                var password = txtPassword.Texts.Trim().ToEmptyWhenNull();

                if (string.IsNullOrEmpty(userName))
                {
                    loadingManager.CloseWaitForm();
                    txtUserName.Focus();
                    var messageValidate = Properties.NencerResource.FieldRequired;
                    MessageBox.Show(string.Format(messageValidate, LocalExt.Text("Username").ToLower()), Properties.NencerResource.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    loadingManager.CloseWaitForm();
                    txtPassword.Focus();
                    var messageValidate = Properties.NencerResource.FieldRequired;
                    MessageBox.Show(string.Format(messageValidate, LocalExt.Text("Password").ToLower()), Properties.NencerResource.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Call api check info login
                bool isLogin = await login(userName, password);

                if (isLogin)
                {
                    Hide();
                    var main = new Main();

                    loadingManager.CloseWaitForm();
                    main.Show();

                    // Lưu pass
                    RememberLogin();
                }
                else
                {
                    loadingManager.CloseWaitForm();
                    MessageBox.Show(Properties.NencerResource.UserNameOrPasswordWrong, Properties.NencerResource.Alert, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                loadingManager.CloseWaitForm();
                MessageBox.Show(Properties.NencerResource.UserNameOrPasswordWrong, Properties.NencerResource.Alert, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> login(string username, string password)
        {
            // Khởi tạo HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Tạo URL với thông tin đăng nhập là query parameters
                    string loginURL = $"{URL}api/User/Login?username={username}&password={password}";

                    // Gửi yêu cầu HTTP POST tới API
                    HttpResponseMessage response = await client.PostAsync(loginURL, null);

                    if (response.IsSuccessStatusCode)
                    {
                        // Deserialize chuỗi JSON thành một đối tượng JObject
                        JObject responseObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                        if ((int)responseObject["responseCode"] == 200)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }

        private void RememberLogin()
        {
            if (ckRememberMe.Checked)
            {
                // Nếu người dùng chọn "Remember Me", lưu thông tin đăng nhập
                AppSettingManager.SaveCredentials(txtUserName.Texts, txtPassword.Texts);
            }
            else
            {
                // Nếu không, xóa thông tin đăng nhập đã lưu
                AppSettingManager.SaveCredentials("", "");
            }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                var userName = txtUserName.Texts.ToLower().Trim();
                var password = txtPassword.Texts.Trim();
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Đăng ký không thành công!");
            }
        }

        // Phương thức này sẽ được gọi khi người dùng cố gắng đóng form
        private void Login_FormClosing(object? sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
