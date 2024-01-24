using NencerHis.Extensions;

namespace NencerHis.Shared.UserControls
{
    partial class PaginationControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaginationControl));
            cbNumberResultView = new ComboBox();
            flowLayoutPanel = new FlowLayoutPanel();
            txtPage = new TextBox();
            btnFirst = new DevExpress.XtraEditors.SimpleButton();
            btnPre = new DevExpress.XtraEditors.SimpleButton();
            btnPage1 = new DevExpress.XtraEditors.SimpleButton();
            btnPage2 = new DevExpress.XtraEditors.SimpleButton();
            btnPage3 = new DevExpress.XtraEditors.SimpleButton();
            btnNext = new DevExpress.XtraEditors.SimpleButton();
            btnLast = new DevExpress.XtraEditors.SimpleButton();
            flowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // cbNumberResultView
            // 
            cbNumberResultView.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbNumberResultView.BackColor = SystemColors.Control;
            cbNumberResultView.Cursor = Cursors.Hand;
            cbNumberResultView.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNumberResultView.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbNumberResultView.FormattingEnabled = true;
            cbNumberResultView.Location = new Point(248, 2);
            cbNumberResultView.Margin = new Padding(5, 2, 0, 2);
            cbNumberResultView.Name = "cbNumberResultView";
            cbNumberResultView.Size = new Size(50, 22);
            cbNumberResultView.TabIndex = 0;
            cbNumberResultView.SelectedValueChanged += cbNumberResultView_SelectedValueChanged;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel.Controls.Add(txtPage);
            flowLayoutPanel.Controls.Add(btnFirst);
            flowLayoutPanel.Controls.Add(btnPre);
            flowLayoutPanel.Controls.Add(btnPage1);
            flowLayoutPanel.Controls.Add(btnPage2);
            flowLayoutPanel.Controls.Add(btnPage3);
            flowLayoutPanel.Controls.Add(btnNext);
            flowLayoutPanel.Controls.Add(btnLast);
            flowLayoutPanel.Controls.Add(cbNumberResultView);
            flowLayoutPanel.Location = new Point(0, 0);
            flowLayoutPanel.Margin = new Padding(0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.RightToLeft = RightToLeft.No;
            flowLayoutPanel.Size = new Size(298, 26);
            flowLayoutPanel.TabIndex = 8;
            flowLayoutPanel.WrapContents = false;
            // 
            // txtPage
            // 
            txtPage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPage.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtPage.Location = new Point(0, 2);
            txtPage.Margin = new Padding(0, 2, 5, 2);
            txtPage.Name = "txtPage";
            txtPage.PlaceholderText = LocalExt.Text("Page");
            txtPage.Size = new Size(50, 22);
            txtPage.TabIndex = 8;
            txtPage.KeyUp += txtPage_KeyUp;
            // 
            // btnFirst
            // 
            btnFirst.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFirst.Appearance.Options.UseFont = true;
            btnFirst.AutoSize = true;
            btnFirst.ImageOptions.Image = (Image)resources.GetObject("btnFirst.ImageOptions.Image");
            btnFirst.Location = new Point(57, 2);
            btnFirst.Margin = new Padding(2);
            btnFirst.Name = "btnFirst";
            btnFirst.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            btnFirst.Size = new Size(22, 22);
            btnFirst.TabIndex = 9;
            btnFirst.Click += bntFirst_Click;
            // 
            // btnPre
            // 
            btnPre.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPre.AutoSize = true;
            btnPre.ImageOptions.Image = (Image)resources.GetObject("btnPre.ImageOptions.Image");
            btnPre.Location = new Point(83, 2);
            btnPre.Margin = new Padding(2);
            btnPre.Name = "btnPre";
            btnPre.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            btnPre.Size = new Size(22, 22);
            btnPre.TabIndex = 10;
            btnPre.Click += btnPre_Click;
            // 
            // btnPage1
            // 
            btnPage1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPage1.AutoSize = true;
            btnPage1.Location = new Point(109, 2);
            btnPage1.Margin = new Padding(2);
            btnPage1.Name = "btnPage1";
            btnPage1.Padding = new Padding(5, 0, 5, 0);
            btnPage1.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            btnPage1.Size = new Size(24, 22);
            btnPage1.TabIndex = 11;
            btnPage1.Text = "1";
            btnPage1.Click += btnPage_Click;
            // 
            // btnPage2
            // 
            btnPage2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPage2.AutoSize = true;
            btnPage2.Location = new Point(137, 2);
            btnPage2.Margin = new Padding(2);
            btnPage2.Name = "btnPage2";
            btnPage2.Padding = new Padding(5, 0, 5, 0);
            btnPage2.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            btnPage2.Size = new Size(24, 22);
            btnPage2.TabIndex = 12;
            btnPage2.Text = "2";
            btnPage2.Click += btnPage_Click;
            // 
            // btnPage3
            // 
            btnPage3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPage3.AutoSize = true;
            btnPage3.Location = new Point(165, 2);
            btnPage3.Margin = new Padding(2);
            btnPage3.Name = "btnPage3";
            btnPage3.Padding = new Padding(5, 0, 5, 0);
            btnPage3.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            btnPage3.Size = new Size(24, 22);
            btnPage3.TabIndex = 13;
            btnPage3.Text = "3";
            btnPage3.Click += btnPage_Click;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.None;
            btnNext.AutoSize = true;
            btnNext.ImageOptions.Image = (Image)resources.GetObject("btnNext.ImageOptions.Image");
            btnNext.Location = new Point(193, 2);
            btnNext.Margin = new Padding(2);
            btnNext.Name = "btnNext";
            btnNext.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            btnNext.Size = new Size(22, 22);
            btnNext.TabIndex = 14;
            btnNext.Click += btnNext_Click;
            // 
            // btnLast
            // 
            btnLast.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLast.AutoSize = true;
            btnLast.ImageOptions.Image = (Image)resources.GetObject("btnLast.ImageOptions.Image");
            btnLast.Location = new Point(219, 2);
            btnLast.Margin = new Padding(2);
            btnLast.Name = "btnLast";
            btnLast.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            btnLast.Size = new Size(22, 22);
            btnLast.TabIndex = 15;
            btnLast.Click += btnLast_Click;
            // 
            // PaginationControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(flowLayoutPanel);
            Margin = new Padding(0);
            Name = "PaginationControl";
            Size = new Size(298, 26);
            flowLayoutPanel.ResumeLayout(false);
            flowLayoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigUILocalization()
        {
            txtPage.PlaceholderText = LocalExt.Text("Page");
        }

        #endregion

        public ComboBox cbNumberResultView;
        private FlowLayoutPanel flowLayoutPanel;
        private TextBox txtPage;
        private DevExpress.XtraEditors.SimpleButton btnFirst;
        private DevExpress.XtraEditors.SimpleButton btnPre;
        private DevExpress.XtraEditors.SimpleButton btnPage1;
        private DevExpress.XtraEditors.SimpleButton btnPage2;
        private DevExpress.XtraEditors.SimpleButton btnPage3;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnLast;
    }
}
