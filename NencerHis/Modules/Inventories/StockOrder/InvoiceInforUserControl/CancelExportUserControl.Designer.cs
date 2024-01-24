namespace NencerHis.Modules.Inventories.StockOrder.InvoiceInforUserControl
{
    partial class CancelExportUserControl
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
            lcgInvoiceInfor = new DevExpress.XtraLayout.LayoutControlGroup();
            lblStockOutput = new DevExpress.XtraLayout.LayoutControlItem();
            cbbStockOutput = new DevExpress.XtraEditors.ComboBoxEdit();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            mmDescription = new DevExpress.XtraEditors.MemoEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            lblDescription = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)lcgInvoiceInfor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblStockOutput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbbStockOutput.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mmDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).BeginInit();
            SuspendLayout();
            // 
            // lcgInvoiceInfor
            // 
            lcgInvoiceInfor.AppearanceGroup.Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            lcgInvoiceInfor.AppearanceGroup.Options.UseFont = true;
            lcgInvoiceInfor.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lblStockOutput, lblDescription, emptySpaceItem2 });
            lcgInvoiceInfor.Location = new Point(0, 0);
            lcgInvoiceInfor.Name = "lcgInvoiceInfor";
            lcgInvoiceInfor.Size = new Size(1596, 69);
            lcgInvoiceInfor.Text = "THÔNG TIN HÓA ĐƠN";
            // 
            // lblStockOutput
            // 
            lblStockOutput.Control = cbbStockOutput;
            lblStockOutput.Location = new Point(0, 0);
            lblStockOutput.MaxSize = new Size(250, 24);
            lblStockOutput.MinSize = new Size(250, 24);
            lblStockOutput.Name = "lblStockOutput";
            lblStockOutput.Size = new Size(250, 24);
            lblStockOutput.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lblStockOutput.Text = "Kho xuất";
            lblStockOutput.TextSize = new Size(43, 13);
            // 
            // cbbStockOutput
            // 
            cbbStockOutput.Location = new Point(69, 35);
            cbbStockOutput.Name = "cbbStockOutput";
            cbbStockOutput.Properties.Appearance.BackColor = Color.FromArgb(255, 255, 192);
            cbbStockOutput.Properties.Appearance.Options.UseBackColor = true;
            cbbStockOutput.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbbStockOutput.Size = new Size(191, 20);
            cbbStockOutput.StyleController = layoutControl1;
            cbbStockOutput.TabIndex = 2;
            cbbStockOutput.SelectedValueChanged += cbbStockOutput_SelectedValueChanged;
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(cbbStockOutput);
            layoutControl1.Controls.Add(mmDescription);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(448, 273, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(1613, 65);
            layoutControl1.TabIndex = 1;
            layoutControl1.Text = "layoutControl1";
            // 
            // mmDescription
            // 
            mmDescription.Location = new Point(319, 35);
            mmDescription.Name = "mmDescription";
            mmDescription.Size = new Size(191, 20);
            mmDescription.StyleController = layoutControl1;
            mmDescription.TabIndex = 3;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lcgInvoiceInfor });
            Root.Name = "Root";
            Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            Root.Size = new Size(1596, 69);
            Root.TextVisible = false;
            // 
            // lblDescription
            // 
            lblDescription.Control = mmDescription;
            lblDescription.Location = new Point(250, 0);
            lblDescription.MaxSize = new Size(250, 0);
            lblDescription.MinSize = new Size(250, 20);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(250, 24);
            lblDescription.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lblDescription.Text = "Ghi chú";
            lblDescription.TextSize = new Size(43, 13);
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.AllowHotTrack = false;
            emptySpaceItem2.Location = new Point(500, 0);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new Size(1072, 24);
            emptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // CancelExportUserControl
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "CancelExportUserControl";
            Size = new Size(1613, 65);
            Load += CancelExportUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)lcgInvoiceInfor).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblStockOutput).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbbStockOutput.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mmDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlGroup lcgInvoiceInfor;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cbbStockOutput;
        private DevExpress.XtraEditors.MemoEdit mmDescription;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem lblStockOutput;
        private DevExpress.XtraLayout.LayoutControlItem lblDescription;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}
