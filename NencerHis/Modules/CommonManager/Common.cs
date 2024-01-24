using Tulpep.NotificationWindow;

namespace NencerHis.Modules.CommonManager
{
    public static class Common
    {
        public static void AddTab(DevExpress.XtraTab.XtraTabControl xtraTabControl, string x_strTabName, UserControl x_objUserControl)
        {
            DevExpress.XtraTab.XtraTabPage objNewTab = new DevExpress.XtraTab.XtraTabPage();
            objNewTab.Name = x_strTabName;
            objNewTab.Text = x_strTabName;
            objNewTab.Controls.Add(x_objUserControl);
            x_objUserControl.Dock = DockStyle.Fill;
            xtraTabControl.TabPages.Add(objNewTab);
            xtraTabControl.SelectedTabPage = objNewTab;
        }

        public static void ShowMessageSuccess(string message)
        {
            PopupNotifier popup = new PopupNotifier();

            // Thiết lập khoảng cách
            popup.TitlePadding = new Padding(5, 5, 0, 0);
            popup.ImagePadding = new Padding(5, 5, 0, 0);
            popup.ContentPadding = new Padding(5, 0, 0, 0);

            // Thiết lập hình ảnh và màu sắc cho header
            popup.Image = Properties.Resources.check_24x24;
            popup.HeaderColor = Color.FromArgb(0, 186, 0);
            popup.TitleText = "Thành công!";
            popup.TitleColor = Color.FromArgb(0, 186, 0);
            popup.TitleFont = new Font("Segoe UI", 14, FontStyle.Bold);

            // Thiết lập nội dung
            popup.ContentText = message;
            popup.ContentColor = Color.FromArgb(0, 186, 0);
            popup.ContentFont = new Font("Segoe UI", 10);

            // Thiết lập độ rộng của PopupNotifier
            popup.Size = new Size(popup.Size.Width, 400);
            popup.Size = new Size(popup.Size.Height, 80);

            // Bỏ border
            popup.BorderColor = Color.Transparent;

            // Thiết lập thời gian hiển thị và độ trong suốt
            popup.Delay = 3000;
            popup.AnimationDuration = 500;

            // Hiển thị PopupNotifier
            popup.Popup();
        }

        public static void ShowMessageWarning(string message)
        {
            PopupNotifier popup = new PopupNotifier();

            // Thiết lập khoảng cách
            popup.TitlePadding = new Padding(5, 5, 0, 0);
            popup.ImagePadding = new Padding(5, 5, 0, 0);
            popup.ContentPadding = new Padding(5, 0, 0, 0);

            // Thiết lập hình ảnh và màu sắc cho header
            popup.Image = Properties.Resources.alert_24x24;
            popup.HeaderColor = Color.FromArgb(255, 0, 0);
            popup.TitleText = "Cảnh báo!";
            popup.TitleColor = Color.FromArgb(255, 0, 0);
            popup.TitleFont = new Font("Segoe UI", 14, FontStyle.Bold);

            // Thiết lập nội dung
            popup.ContentText = message;
            popup.ContentColor = Color.FromArgb(255, 0, 0);
            popup.ContentFont = new Font("Segoe UI", 10);

            // Thiết lập độ rộng của PopupNotifier
            popup.Size = new Size(popup.Size.Width, 400);
            popup.Size = new Size(popup.Size.Height, 80);

            // Bỏ border
            popup.BorderColor = Color.Transparent;

            // Thiết lập thời gian hiển thị và độ trong suốt
            popup.Delay = 3000;
            popup.AnimationDuration = 500;

            // Hiển thị PopupNotifier
            popup.Popup();
        }
    }
}
