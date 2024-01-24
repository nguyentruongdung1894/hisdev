namespace NencerHis.Shared.UserControls
{
    partial class RowItem
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
            panelBottomLine = new Panel();
            labelInfo = new Label();
            panel2 = new Panel();
            panelLine = new Panel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottomLine
            // 
            panelBottomLine.BackColor = SystemColors.ActiveBorder;
            panelBottomLine.BorderStyle = BorderStyle.Fixed3D;
            panelBottomLine.Dock = DockStyle.Bottom;
            panelBottomLine.Location = new Point(0, 43);
            panelBottomLine.Name = "panelBottomLine";
            panelBottomLine.Size = new Size(322, 2);
            panelBottomLine.TabIndex = 0;
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelInfo.Location = new Point(51, 13);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(77, 17);
            labelInfo.TabIndex = 1;
            labelInfo.Text = "Xét nghiệm";
            // 
            // panel2
            // 
            panel2.BackgroundImage = Properties.Resources.add_16x16;
            panel2.BackgroundImageLayout = ImageLayout.Center;
            panel2.Controls.Add(panelLine);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(45, 43);
            panel2.TabIndex = 2;
            // 
            // panelLine
            // 
            panelLine.BackColor = SystemColors.ControlLight;
            panelLine.Dock = DockStyle.Right;
            panelLine.Location = new Point(43, 0);
            panelLine.Name = "panelLine";
            panelLine.Size = new Size(2, 43);
            panelLine.TabIndex = 0;
            // 
            // RowItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(labelInfo);
            Controls.Add(panelBottomLine);
            Name = "RowItem";
            Size = new Size(322, 45);
            MouseClick += RowItem_MouseClick;
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelBottomLine;
        private Label labelInfo;
        private Panel panel2;
        private Panel panelLine;
    }
}
