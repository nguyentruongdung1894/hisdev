namespace NencerHis.Modules.Inventories.StockOrder.InvoiceInforUserControl
{
    partial class ReturnSupplierUserControl
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
            cbbSupplier = new DevExpress.XtraEditors.ComboBoxEdit();
            txtReceiver = new DevExpress.XtraEditors.TextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            lblDescription = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            lblSupplier = new DevExpress.XtraLayout.LayoutControlItem();
            lblReceiver = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)lcgInvoiceInfor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblStockOutput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbbStockOutput.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mmDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbbSupplier.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtReceiver.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblSupplier).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblReceiver).BeginInit();
            SuspendLayout();
            // 
            // lcgInvoiceInfor
            // 
            lcgInvoiceInfor.AppearanceGroup.Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            lcgInvoiceInfor.AppearanceGroup.Options.UseFont = true;
            lcgInvoiceInfor.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lblStockOutput, lblDescription, emptySpaceItem2, lblSupplier, lblReceiver });
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
            lblStockOutput.TextSize = new Size(65, 13);
            // 
            // cbbStockOutput
            // 
            cbbStockOutput.Location = new Point(91, 35);
            cbbStockOutput.Name = "cbbStockOutput";
            cbbStockOutput.Properties.Appearance.BackColor = Color.FromArgb(255, 255, 192);
            cbbStockOutput.Properties.Appearance.Options.UseBackColor = true;
            cbbStockOutput.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbbStockOutput.Size = new Size(169, 20);
            cbbStockOutput.StyleController = layoutControl1;
            cbbStockOutput.TabIndex = 0;
            cbbStockOutput.SelectedValueChanged += cbbStockOutput_SelectedValueChanged;
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(cbbStockOutput);
            layoutControl1.Controls.Add(mmDescription);
            layoutControl1.Controls.Add(cbbSupplier);
            layoutControl1.Controls.Add(txtReceiver);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(448, 273, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(1613, 65);
            layoutControl1.TabIndex = 2;
            layoutControl1.Text = "layoutControl1";
            // 
            // mmDescription
            // 
            mmDescription.Location = new Point(841, 35);
            mmDescription.Name = "mmDescription";
            mmDescription.Size = new Size(169, 20);
            mmDescription.StyleController = layoutControl1;
            mmDescription.TabIndex = 4;
            // 
            // cbbSupplier
            // 
            cbbSupplier.Location = new Point(341, 35);
            cbbSupplier.Name = "cbbSupplier";
            cbbSupplier.Properties.Appearance.BackColor = Color.FromArgb(255, 255, 192);
            cbbSupplier.Properties.Appearance.Options.UseBackColor = true;
            cbbSupplier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbbSupplier.Size = new Size(169, 20);
            cbbSupplier.StyleController = layoutControl1;
            cbbSupplier.TabIndex = 2;
            cbbSupplier.SelectedValueChanged += cbbSupplier_SelectedValueChanged;
            // 
            // txtReceiver
            // 
            txtReceiver.Location = new Point(591, 35);
            txtReceiver.Name = "txtReceiver";
            txtReceiver.Properties.Appearance.BackColor = Color.FromArgb(255, 255, 192);
            txtReceiver.Properties.Appearance.Options.UseBackColor = true;
            txtReceiver.Size = new Size(169, 20);
            txtReceiver.StyleController = layoutControl1;
            txtReceiver.TabIndex = 3;
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
            lblDescription.Location = new Point(750, 0);
            lblDescription.MaxSize = new Size(250, 0);
            lblDescription.MinSize = new Size(250, 20);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(250, 24);
            lblDescription.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lblDescription.Text = "Ghi chú";
            lblDescription.TextSize = new Size(65, 13);
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.AllowHotTrack = false;
            emptySpaceItem2.Location = new Point(1000, 0);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new Size(572, 24);
            emptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // lblSupplier
            // 
            lblSupplier.Control = cbbSupplier;
            lblSupplier.Location = new Point(250, 0);
            lblSupplier.MaxSize = new Size(250, 24);
            lblSupplier.MinSize = new Size(250, 24);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(250, 24);
            lblSupplier.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lblSupplier.Text = "Nhà cung cấp";
            lblSupplier.TextSize = new Size(65, 13);
            // 
            // lblReceiver
            // 
            lblReceiver.Control = txtReceiver;
            lblReceiver.Location = new Point(500, 0);
            lblReceiver.MaxSize = new Size(250, 24);
            lblReceiver.MinSize = new Size(250, 24);
            lblReceiver.Name = "lblReceiver";
            lblReceiver.Size = new Size(250, 24);
            lblReceiver.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lblReceiver.Text = "Người nhận";
            lblReceiver.TextSize = new Size(65, 13);
            // 
            // ReturnSupplierUserControl
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "ReturnSupplierUserControl";
            Size = new Size(1613, 65);
            Load += ReturnSupplierUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)lcgInvoiceInfor).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblStockOutput).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbbStockOutput.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mmDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbbSupplier.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtReceiver.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblSupplier).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblReceiver).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlGroup lcgInvoiceInfor;
        private DevExpress.XtraLayout.LayoutControlItem lblStockOutput;
        private DevExpress.XtraEditors.ComboBoxEdit cbbStockOutput;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.MemoEdit mmDescription;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem lblDescription;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.ComboBoxEdit cbbSupplier;
        private DevExpress.XtraEditors.TextEdit txtReceiver;
        private DevExpress.XtraLayout.LayoutControlItem lblSupplier;
        private DevExpress.XtraLayout.LayoutControlItem lblReceiver;
    }
}
