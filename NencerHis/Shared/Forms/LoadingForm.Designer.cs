namespace NencerHis.Modules.ReportManager.Forms
{
    partial class LoadingForm
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
            progressPanel = new DevExpress.XtraWaitForm.ProgressPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // progressPanel
            // 
            progressPanel.Appearance.BackColor = Color.Transparent;
            progressPanel.Appearance.Options.UseBackColor = true;
            progressPanel.AppearanceCaption.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            progressPanel.AppearanceCaption.Options.UseFont = true;
            progressPanel.AppearanceDescription.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            progressPanel.AppearanceDescription.Options.UseFont = true;
            progressPanel.Dock = DockStyle.Fill;
            progressPanel.ImageHorzOffset = 20;
            progressPanel.Location = new Point(0, 17);
            progressPanel.Margin = new Padding(0, 3, 0, 3);
            progressPanel.Name = "progressPanel";
            progressPanel.Size = new Size(246, 39);
            progressPanel.TabIndex = 0;
            progressPanel.Text = "progressPanel1";
            progressPanel.UseWaitCursor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(progressPanel, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(0, 14, 0, 14);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(246, 73);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // LoadingForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(246, 73);
            Controls.Add(tableLayoutPanel1);
            DoubleBuffered = true;
            Name = "LoadingForm";
            Opacity = 0.95D;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel progressPanel;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
