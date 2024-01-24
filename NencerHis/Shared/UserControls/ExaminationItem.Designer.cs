namespace NencerHis.Shared.UserControls
{
    partial class ExaminationItem
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
            panelIconStatus = new Panel();
            labelName = new Label();
            panelMain = new Panel();
            labelAddress = new Label();
            labelPatientNumber = new Label();
            panelDate = new Panel();
            labelDate = new Label();
            panelMain.SuspendLayout();
            panelDate.SuspendLayout();
            SuspendLayout();
            // 
            // panelIconStatus
            // 
            panelIconStatus.BackColor = Color.Transparent;
            panelIconStatus.BackgroundImage = Properties.Resources.check_24x24;
            panelIconStatus.BackgroundImageLayout = ImageLayout.Center;
            panelIconStatus.Dock = DockStyle.Left;
            panelIconStatus.Location = new Point(0, 0);
            panelIconStatus.Margin = new Padding(0);
            panelIconStatus.Name = "panelIconStatus";
            panelIconStatus.Size = new Size(50, 60);
            panelIconStatus.TabIndex = 0;
            // 
            // labelName
            // 
            labelName.AutoEllipsis = true;
            labelName.BackColor = Color.Transparent;
            labelName.Dock = DockStyle.Top;
            labelName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelName.Location = new Point(0, 0);
            labelName.Margin = new Padding(0);
            labelName.Name = "labelName";
            labelName.Padding = new Padding(0, 0, 5, 0);
            labelName.Size = new Size(240, 22);
            labelName.TabIndex = 1;
            labelName.Text = "Nguyễn Ngọc Trúc Anh - 1990";
            // 
            // panelMain
            // 
            panelMain.Controls.Add(labelAddress);
            panelMain.Controls.Add(labelPatientNumber);
            panelMain.Controls.Add(labelName);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(50, 0);
            panelMain.Margin = new Padding(0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(240, 60);
            panelMain.TabIndex = 3;
            // 
            // labelAddress
            // 
            labelAddress.AutoEllipsis = true;
            labelAddress.BackColor = Color.Transparent;
            labelAddress.Dock = DockStyle.Top;
            labelAddress.Location = new Point(0, 40);
            labelAddress.Margin = new Padding(0);
            labelAddress.Name = "labelAddress";
            labelAddress.Padding = new Padding(0, 0, 5, 0);
            labelAddress.Size = new Size(240, 18);
            labelAddress.TabIndex = 2;
            labelAddress.Text = "Thị xá phúc long -Vĩnh Long - Vĩnh Bảo - Hải Phòng";
            // 
            // labelPatientNumber
            // 
            labelPatientNumber.AutoEllipsis = true;
            labelPatientNumber.BackColor = Color.Transparent;
            labelPatientNumber.Dock = DockStyle.Top;
            labelPatientNumber.ForeColor = Color.Red;
            labelPatientNumber.Location = new Point(0, 22);
            labelPatientNumber.Margin = new Padding(0, 2, 0, 0);
            labelPatientNumber.Name = "labelPatientNumber";
            labelPatientNumber.Padding = new Padding(0, 0, 5, 0);
            labelPatientNumber.Size = new Size(240, 18);
            labelPatientNumber.TabIndex = 3;
            labelPatientNumber.Text = "2003000888 - Viện phí - KB";
            // 
            // panelDate
            // 
            panelDate.Controls.Add(labelDate);
            panelDate.Dock = DockStyle.Right;
            panelDate.Location = new Point(290, 0);
            panelDate.Name = "panelDate";
            panelDate.Size = new Size(50, 60);
            panelDate.TabIndex = 4;
            // 
            // labelDate
            // 
            labelDate.BackColor = Color.Transparent;
            labelDate.Dock = DockStyle.Fill;
            labelDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelDate.Location = new Point(0, 0);
            labelDate.Margin = new Padding(0);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(50, 60);
            labelDate.TabIndex = 0;
            labelDate.Text = "2 ngày trước";
            labelDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ExaminationItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(panelMain);
            Controls.Add(panelDate);
            Controls.Add(panelIconStatus);
            Margin = new Padding(0);
            Name = "ExaminationItem";
            Size = new Size(340, 60);
            panelMain.ResumeLayout(false);
            panelDate.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelIconStatus;
        private Label labelName;
        private Panel panelMain;
        private Label labelPatientNumber;
        private Panel panelDate;
        private Label labelDate;
        private Label labelAddress;
    }
}
