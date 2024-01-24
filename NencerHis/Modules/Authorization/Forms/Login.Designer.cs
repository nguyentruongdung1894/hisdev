namespace NencerHis.Modules.Authorization.Forms
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            menuStrip = new MenuStrip();
            homeToolStripMenuItem = new ToolStripMenuItem();
            RegisterToolStripMenuItem = new ToolStripMenuItem();
            càiĐặtToolStripMenuItem = new ToolStripMenuItem();
            cấuHìnhDatabseToolStripMenuItem = new ToolStripMenuItem();
            cấuHìnhMáyInToolStripMenuItem = new ToolStripMenuItem();
            máyXétNghiệmToolStripMenuItem = new ToolStripMenuItem();
            hỗTrợToolStripMenuItem = new ToolStripMenuItem();
            bảnQuyềnToolStripMenuItem = new ToolStripMenuItem();
            hỗTrợToolStripMenuItem1 = new ToolStripMenuItem();
            cậpNhậtPhiênBảnToolStripMenuItem = new ToolStripMenuItem();
            lbTitle = new Label();
            lbSubTitle = new Label();
            lineUser = new DevExpress.XtraEditors.SeparatorControl();
            lineUser2 = new DevExpress.XtraEditors.SeparatorControl();
            pbLogo = new PictureBox();
            lbFooter = new Label();
            btnLogin = new CustomToolbox.CustomButton();
            txtPassword = new CustomToolbox.CustomControls.CustomTextBox();
            ckRememberMe = new CheckBox();
            txtUserName = new CustomToolbox.CustomControls.CustomTextBox();
            loadingManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(ReportManager.Forms.LoadingForm), false, false);
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lineUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lineUser2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, càiĐặtToolStripMenuItem, hỗTrợToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(640, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { RegisterToolStripMenuItem });
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new Size(71, 20);
            homeToolStripMenuItem.Text = "Trang chủ";
            // 
            // RegisterToolStripMenuItem
            // 
            RegisterToolStripMenuItem.Name = "RegisterToolStripMenuItem";
            RegisterToolStripMenuItem.Size = new Size(67, 22);
            RegisterToolStripMenuItem.Text = "Đăng ký";
            RegisterToolStripMenuItem.Click += btnRegister_Click;
            // 
            // càiĐặtToolStripMenuItem
            // 
            càiĐặtToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cấuHìnhDatabseToolStripMenuItem, cấuHìnhMáyInToolStripMenuItem, máyXétNghiệmToolStripMenuItem });
            càiĐặtToolStripMenuItem.Name = "càiĐặtToolStripMenuItem";
            càiĐặtToolStripMenuItem.Size = new Size(56, 20);
            càiĐặtToolStripMenuItem.Text = "Cài đặt";
            // 
            // cấuHìnhDatabseToolStripMenuItem
            // 
            cấuHìnhDatabseToolStripMenuItem.Name = "cấuHìnhDatabseToolStripMenuItem";
            cấuHìnhDatabseToolStripMenuItem.Size = new Size(160, 22);
            cấuHìnhDatabseToolStripMenuItem.Text = "Cơ sở dữ liệu";
            // 
            // cấuHìnhMáyInToolStripMenuItem
            // 
            cấuHìnhMáyInToolStripMenuItem.Name = "cấuHìnhMáyInToolStripMenuItem";
            cấuHìnhMáyInToolStripMenuItem.Size = new Size(160, 22);
            cấuHìnhMáyInToolStripMenuItem.Text = "Máy in";
            // 
            // máyXétNghiệmToolStripMenuItem
            // 
            máyXétNghiệmToolStripMenuItem.Name = "máyXétNghiệmToolStripMenuItem";
            máyXétNghiệmToolStripMenuItem.Size = new Size(160, 22);
            máyXétNghiệmToolStripMenuItem.Text = "Máy xét nghiệm";
            // 
            // hỗTrợToolStripMenuItem
            // 
            hỗTrợToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { bảnQuyềnToolStripMenuItem, hỗTrợToolStripMenuItem1, cậpNhậtPhiênBảnToolStripMenuItem });
            hỗTrợToolStripMenuItem.Name = "hỗTrợToolStripMenuItem";
            hỗTrợToolStripMenuItem.Size = new Size(53, 20);
            hỗTrợToolStripMenuItem.Text = "Hỗ trợ";
            // 
            // bảnQuyềnToolStripMenuItem
            // 
            bảnQuyềnToolStripMenuItem.Name = "bảnQuyềnToolStripMenuItem";
            bảnQuyềnToolStripMenuItem.Size = new Size(178, 22);
            bảnQuyềnToolStripMenuItem.Text = "Bản quyền";
            // 
            // hỗTrợToolStripMenuItem1
            // 
            hỗTrợToolStripMenuItem1.Name = "hỗTrợToolStripMenuItem1";
            hỗTrợToolStripMenuItem1.Size = new Size(178, 22);
            hỗTrợToolStripMenuItem1.Text = "Hỗ trợ";
            // 
            // cậpNhậtPhiênBảnToolStripMenuItem
            // 
            cậpNhậtPhiênBảnToolStripMenuItem.Name = "cậpNhậtPhiênBảnToolStripMenuItem";
            cậpNhậtPhiênBảnToolStripMenuItem.Size = new Size(178, 22);
            cậpNhậtPhiênBảnToolStripMenuItem.Text = "Cập nhật phiên bản";
            // 
            // lbTitle
            // 
            lbTitle.Anchor = AnchorStyles.None;
            lbTitle.BackColor = Color.Transparent;
            lbTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbTitle.ForeColor = Color.FromArgb(24, 144, 255);
            lbTitle.ImeMode = ImeMode.NoControl;
            lbTitle.Location = new Point(220, 120);
            lbTitle.Margin = new Padding(0);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(200, 25);
            lbTitle.TabIndex = 22;
            lbTitle.Text = "Đăng nhập hệ thống";
            lbTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbSubTitle
            // 
            lbSubTitle.Anchor = AnchorStyles.None;
            lbSubTitle.BackColor = Color.Transparent;
            lbSubTitle.ForeColor = Color.FromArgb(131, 131, 131);
            lbSubTitle.ImeMode = ImeMode.NoControl;
            lbSubTitle.Location = new Point(240, 100);
            lbSubTitle.Name = "lbSubTitle";
            lbSubTitle.Size = new Size(160, 15);
            lbSubTitle.TabIndex = 24;
            lbSubTitle.Text = "Hệ thống HIS Nencer";
            lbSubTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lineUser
            // 
            lineUser.Anchor = AnchorStyles.None;
            lineUser.BackColor = Color.Transparent;
            lineUser.LineColor = Color.FromArgb(24, 144, 255);
            lineUser.LineThickness = 2;
            lineUser.Location = new Point(240, 152);
            lineUser.Margin = new Padding(0);
            lineUser.Name = "lineUser";
            lineUser.Padding = new Padding(0);
            lineUser.Size = new Size(160, 10);
            lineUser.TabIndex = 21;
            // 
            // lineUser2
            // 
            lineUser2.Anchor = AnchorStyles.None;
            lineUser2.BackColor = Color.Transparent;
            lineUser2.LineColor = Color.White;
            lineUser2.LineThickness = 1;
            lineUser2.Location = new Point(150, 150);
            lineUser2.Margin = new Padding(0);
            lineUser2.Name = "lineUser2";
            lineUser2.Padding = new Padding(0);
            lineUser2.Size = new Size(340, 10);
            lineUser2.TabIndex = 20;
            // 
            // pbLogo
            // 
            pbLogo.Anchor = AnchorStyles.None;
            pbLogo.BackColor = Color.Transparent;
            pbLogo.BackgroundImage = Properties.Resources.nencer_logo;
            pbLogo.BackgroundImageLayout = ImageLayout.Stretch;
            pbLogo.ImeMode = ImeMode.NoControl;
            pbLogo.Location = new Point(240, 50);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(160, 40);
            pbLogo.TabIndex = 23;
            pbLogo.TabStop = false;
            // 
            // lbFooter
            // 
            lbFooter.BackColor = Color.Transparent;
            lbFooter.Dock = DockStyle.Bottom;
            lbFooter.ForeColor = Color.FromArgb(131, 131, 131);
            lbFooter.ImeMode = ImeMode.NoControl;
            lbFooter.Location = new Point(0, 360);
            lbFooter.Name = "lbFooter";
            lbFooter.Size = new Size(640, 21);
            lbFooter.TabIndex = 25;
            lbFooter.Text = "© HIS Nencer";
            lbFooter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.BackColor = Color.DodgerBlue;
            btnLogin.BackgroundColor = Color.DodgerBlue;
            btnLogin.BorderColor = Color.DodgerBlue;
            btnLogin.BorderRadius = 5;
            btnLogin.BorderSize = 0;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.White;
            btnLogin.ImeMode = ImeMode.NoControl;
            btnLogin.Location = new Point(150, 300);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(340, 30);
            btnLogin.TabIndex = 18;
            btnLogin.Text = "Đăng nhập";
            btnLogin.TextColor = Color.White;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.BackColor = SystemColors.Window;
            txtPassword.BorderColor = Color.FromArgb(224, 224, 224);
            txtPassword.BorderFocusColor = Color.HotPink;
            txtPassword.BorderRadius = 5;
            txtPassword.BorderSize = 1;
            txtPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.ForeColor = Color.FromArgb(64, 64, 64);
            txtPassword.IsPlaceholder = true;
            txtPassword.Location = new Point(150, 230);
            txtPassword.Margin = new Padding(4);
            txtPassword.Multiline = false;
            txtPassword.Name = "txtPassword";
            txtPassword.Padding = new Padding(10, 7, 10, 7);
            txtPassword.PasswordChar = true;
            txtPassword.PlaceholderColor = Color.DarkGray;
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(340, 32);
            txtPassword.TabIndex = 17;
            txtPassword.Texts = "";
            txtPassword.UnderlinedStyle = false;
            txtPassword.KeyPress += Login_KeyPress;
            // 
            // ckRememberMe
            // 
            ckRememberMe.Anchor = AnchorStyles.None;
            ckRememberMe.AutoSize = true;
            ckRememberMe.BackColor = Color.Transparent;
            ckRememberMe.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ckRememberMe.ForeColor = Color.FromArgb(60, 51, 51);
            ckRememberMe.ImeMode = ImeMode.NoControl;
            ckRememberMe.Location = new Point(150, 270);
            ckRememberMe.Name = "ckRememberMe";
            ckRememberMe.Size = new Size(70, 19);
            ckRememberMe.TabIndex = 19;
            ckRememberMe.Text = "Ghi nhớ";
            ckRememberMe.UseVisualStyleBackColor = false;
            // 
            // txtUserName
            // 
            txtUserName.Anchor = AnchorStyles.None;
            txtUserName.BackColor = SystemColors.Window;
            txtUserName.BorderColor = Color.FromArgb(224, 224, 224);
            txtUserName.BorderFocusColor = Color.HotPink;
            txtUserName.BorderRadius = 5;
            txtUserName.BorderSize = 1;
            txtUserName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtUserName.ForeColor = Color.FromArgb(64, 64, 64);
            txtUserName.IsPlaceholder = true;
            txtUserName.Location = new Point(150, 180);
            txtUserName.Margin = new Padding(4);
            txtUserName.Multiline = false;
            txtUserName.Name = "txtUserName";
            txtUserName.Padding = new Padding(10, 7, 10, 7);
            txtUserName.PasswordChar = false;
            txtUserName.PlaceholderColor = Color.DarkGray;
            txtUserName.PlaceholderText = "Username";
            txtUserName.Size = new Size(340, 32);
            txtUserName.TabIndex = 16;
            txtUserName.Texts = "";
            txtUserName.UnderlinedStyle = false;
            txtUserName.KeyPress += Login_KeyPress;
            // 
            // loadingManager
            // 
            loadingManager.ClosingDelay = 500;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(640, 381);
            Controls.Add(lbTitle);
            Controls.Add(lbSubTitle);
            Controls.Add(lineUser);
            Controls.Add(lineUser2);
            Controls.Add(pbLogo);
            Controls.Add(lbFooter);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(ckRememberMe);
            Controls.Add(txtUserName);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(656, 420);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - Nencer HMS";
            FormClosing += Login_FormClosing;
            Load += Login_Load;
            KeyPress += Login_KeyPress;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lineUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)lineUser2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem homeToolStripMenuItem;
        private ToolStripMenuItem RegisterToolStripMenuItem;
        private ToolStripMenuItem càiĐặtToolStripMenuItem;
        private ToolStripMenuItem cấuHìnhDatabseToolStripMenuItem;
        private ToolStripMenuItem cấuHìnhMáyInToolStripMenuItem;
        private ToolStripMenuItem máyXétNghiệmToolStripMenuItem;
        private ToolStripMenuItem hỗTrợToolStripMenuItem;
        private ToolStripMenuItem bảnQuyềnToolStripMenuItem;
        private ToolStripMenuItem hỗTrợToolStripMenuItem1;
        private ToolStripMenuItem cậpNhậtPhiênBảnToolStripMenuItem;
        private Label lbTitle;
        private Label lbSubTitle;
        private DevExpress.XtraEditors.SeparatorControl lineUser;
        private DevExpress.XtraEditors.SeparatorControl lineUser2;
        private PictureBox pbLogo;
        private Label lbFooter;
        private CustomToolbox.CustomButton btnLogin;
        private CustomToolbox.CustomControls.CustomTextBox txtPassword;
        private CheckBox ckRememberMe;
        private CustomToolbox.CustomControls.CustomTextBox txtUserName;
        private DevExpress.XtraSplashScreen.SplashScreenManager loadingManager;
    }
}