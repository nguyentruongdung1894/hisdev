namespace NencerHis.Modules.Inventories.StockOrder.InvoiceInforUserControl
{
    partial class ImportProgramUserControl
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
            emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            lblReceiver = new DevExpress.XtraLayout.LayoutControlItem();
            txtReceiver = new DevExpress.XtraEditors.TextEdit();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            cbbStock = new DevExpress.XtraEditors.ComboBoxEdit();
            cbbSupplier = new DevExpress.XtraEditors.ComboBoxEdit();
            txtBillsNumber = new DevExpress.XtraEditors.TextEdit();
            txtDeliver = new DevExpress.XtraEditors.TextEdit();
            dpkOrderDate = new DevExpress.XtraEditors.DateEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            lcgInvoiceInfor = new DevExpress.XtraLayout.LayoutControlGroup();
            lblStock = new DevExpress.XtraLayout.LayoutControlItem();
            lblSupplier = new DevExpress.XtraLayout.LayoutControlItem();
            lblBillsNumber = new DevExpress.XtraLayout.LayoutControlItem();
            lblDeliver = new DevExpress.XtraLayout.LayoutControlItem();
            lblOrderDate = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            textEdit1 = new DevExpress.XtraEditors.TextEdit();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblReceiver).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtReceiver.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cbbStock.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbbSupplier.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBillsNumber.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDeliver.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dpkOrderDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dpkOrderDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgInvoiceInfor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblSupplier).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblBillsNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblDeliver).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblOrderDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem4).BeginInit();
            SuspendLayout();
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.AllowHotTrack = false;
            emptySpaceItem2.Location = new Point(750, 24);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new Size(839, 24);
            emptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // lblReceiver
            // 
            lblReceiver.Control = txtReceiver;
            lblReceiver.Location = new Point(500, 24);
            lblReceiver.MaxSize = new Size(0, 24);
            lblReceiver.MinSize = new Size(151, 24);
            lblReceiver.Name = "lblReceiver";
            lblReceiver.Size = new Size(250, 24);
            lblReceiver.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lblReceiver.Text = "Người nhận";
            lblReceiver.TextSize = new Size(85, 13);
            // 
            // txtReceiver
            // 
            txtReceiver.Location = new Point(611, 59);
            txtReceiver.Name = "txtReceiver";
            txtReceiver.Size = new Size(149, 20);
            txtReceiver.StyleController = layoutControl1;
            txtReceiver.TabIndex = 6;
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(cbbStock);
            layoutControl1.Controls.Add(cbbSupplier);
            layoutControl1.Controls.Add(txtBillsNumber);
            layoutControl1.Controls.Add(txtDeliver);
            layoutControl1.Controls.Add(dpkOrderDate);
            layoutControl1.Controls.Add(txtReceiver);
            layoutControl1.Controls.Add(comboBoxEdit1);
            layoutControl1.Controls.Add(textEdit1);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(458, 327, 840, 544);
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(1613, 117);
            layoutControl1.TabIndex = 1;
            layoutControl1.Text = "layoutControl1";
            // 
            // cbbStock
            // 
            cbbStock.Location = new Point(111, 35);
            cbbStock.Name = "cbbStock";
            cbbStock.Properties.Appearance.BackColor = Color.FromArgb(255, 255, 192);
            cbbStock.Properties.Appearance.Options.UseBackColor = true;
            cbbStock.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbbStock.Size = new Size(149, 20);
            cbbStock.StyleController = layoutControl1;
            cbbStock.TabIndex = 0;
            // 
            // cbbSupplier
            // 
            cbbSupplier.Location = new Point(111, 59);
            cbbSupplier.Name = "cbbSupplier";
            cbbSupplier.Properties.Appearance.BackColor = Color.FromArgb(255, 255, 192);
            cbbSupplier.Properties.Appearance.Options.UseBackColor = true;
            cbbSupplier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbbSupplier.Size = new Size(149, 20);
            cbbSupplier.StyleController = layoutControl1;
            cbbSupplier.TabIndex = 4;
            // 
            // txtBillsNumber
            // 
            txtBillsNumber.Location = new Point(361, 35);
            txtBillsNumber.Name = "txtBillsNumber";
            txtBillsNumber.Properties.Appearance.BackColor = Color.FromArgb(255, 255, 192);
            txtBillsNumber.Properties.Appearance.Options.UseBackColor = true;
            txtBillsNumber.Size = new Size(149, 20);
            txtBillsNumber.StyleController = layoutControl1;
            txtBillsNumber.TabIndex = 2;
            // 
            // txtDeliver
            // 
            txtDeliver.Location = new Point(361, 59);
            txtDeliver.Name = "txtDeliver";
            txtDeliver.Size = new Size(149, 20);
            txtDeliver.StyleController = layoutControl1;
            txtDeliver.TabIndex = 5;
            // 
            // dpkOrderDate
            // 
            dpkOrderDate.EditValue = null;
            dpkOrderDate.Location = new Point(611, 35);
            dpkOrderDate.Name = "dpkOrderDate";
            dpkOrderDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dpkOrderDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dpkOrderDate.Size = new Size(149, 20);
            dpkOrderDate.StyleController = layoutControl1;
            dpkOrderDate.TabIndex = 3;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lcgInvoiceInfor });
            Root.Name = "Root";
            Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            Root.Size = new Size(1613, 117);
            Root.TextVisible = false;
            // 
            // lcgInvoiceInfor
            // 
            lcgInvoiceInfor.AppearanceGroup.Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            lcgInvoiceInfor.AppearanceGroup.Options.UseFont = true;
            lcgInvoiceInfor.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lblStock, lblSupplier, lblBillsNumber, lblDeliver, lblOrderDate, lblReceiver, emptySpaceItem1, emptySpaceItem2, layoutControlItem1, layoutControlItem2, emptySpaceItem3, emptySpaceItem4 });
            lcgInvoiceInfor.Location = new Point(0, 0);
            lcgInvoiceInfor.Name = "lcgInvoiceInfor";
            lcgInvoiceInfor.Size = new Size(1613, 117);
            lcgInvoiceInfor.Text = "THÔNG TIN HÓA ĐƠN";
            // 
            // lblStock
            // 
            lblStock.Control = cbbStock;
            lblStock.Location = new Point(0, 0);
            lblStock.MaxSize = new Size(250, 24);
            lblStock.MinSize = new Size(250, 24);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(250, 24);
            lblStock.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lblStock.Text = "Kho nhập";
            lblStock.TextSize = new Size(85, 13);
            // 
            // lblSupplier
            // 
            lblSupplier.Control = cbbSupplier;
            lblSupplier.Location = new Point(0, 24);
            lblSupplier.MaxSize = new Size(250, 24);
            lblSupplier.MinSize = new Size(250, 24);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(250, 24);
            lblSupplier.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lblSupplier.Text = "Tên nhà cung cấp";
            lblSupplier.TextSize = new Size(85, 13);
            // 
            // lblBillsNumber
            // 
            lblBillsNumber.Control = txtBillsNumber;
            lblBillsNumber.Location = new Point(250, 0);
            lblBillsNumber.MaxSize = new Size(250, 24);
            lblBillsNumber.MinSize = new Size(250, 24);
            lblBillsNumber.Name = "lblBillsNumber";
            lblBillsNumber.Size = new Size(250, 24);
            lblBillsNumber.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lblBillsNumber.Text = "Số hóa đơn";
            lblBillsNumber.TextSize = new Size(85, 13);
            // 
            // lblDeliver
            // 
            lblDeliver.Control = txtDeliver;
            lblDeliver.Location = new Point(250, 24);
            lblDeliver.MaxSize = new Size(250, 24);
            lblDeliver.MinSize = new Size(250, 24);
            lblDeliver.Name = "lblDeliver";
            lblDeliver.Size = new Size(250, 24);
            lblDeliver.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lblDeliver.Text = "Người giao";
            lblDeliver.TextSize = new Size(85, 13);
            // 
            // lblOrderDate
            // 
            lblOrderDate.Control = dpkOrderDate;
            lblOrderDate.Location = new Point(500, 0);
            lblOrderDate.MaxSize = new Size(250, 24);
            lblOrderDate.MinSize = new Size(250, 24);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.Size = new Size(250, 24);
            lblOrderDate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lblOrderDate.Text = "Ngày hóa đơn";
            lblOrderDate.TextSize = new Size(85, 13);
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new Point(750, 0);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(839, 24);
            emptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // comboBoxEdit1
            // 
            comboBoxEdit1.Location = new Point(111, 83);
            comboBoxEdit1.Name = "comboBoxEdit1";
            comboBoxEdit1.Properties.Appearance.BackColor = Color.FromArgb(255, 255, 192);
            comboBoxEdit1.Properties.Appearance.Options.UseBackColor = true;
            comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEdit1.Size = new Size(149, 20);
            comboBoxEdit1.StyleController = layoutControl1;
            comboBoxEdit1.TabIndex = 7;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = comboBoxEdit1;
            layoutControlItem1.Location = new Point(0, 48);
            layoutControlItem1.MaxSize = new Size(250, 24);
            layoutControlItem1.MinSize = new Size(250, 24);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(250, 24);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.Text = "Mã nguồn";
            layoutControlItem1.TextSize = new Size(85, 13);
            // 
            // textEdit1
            // 
            textEdit1.Location = new Point(361, 83);
            textEdit1.Name = "textEdit1";
            textEdit1.Size = new Size(149, 20);
            textEdit1.StyleController = layoutControl1;
            textEdit1.TabIndex = 8;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = textEdit1;
            layoutControlItem2.Location = new Point(250, 48);
            layoutControlItem2.MaxSize = new Size(250, 24);
            layoutControlItem2.MinSize = new Size(250, 24);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(250, 24);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.Text = "Tên nguồn";
            layoutControlItem2.TextSize = new Size(85, 13);
            // 
            // emptySpaceItem3
            // 
            emptySpaceItem3.AllowHotTrack = false;
            emptySpaceItem3.Location = new Point(500, 48);
            emptySpaceItem3.Name = "emptySpaceItem3";
            emptySpaceItem3.Size = new Size(250, 24);
            emptySpaceItem3.TextSize = new Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            emptySpaceItem4.AllowHotTrack = false;
            emptySpaceItem4.Location = new Point(750, 48);
            emptySpaceItem4.Name = "emptySpaceItem4";
            emptySpaceItem4.Size = new Size(839, 24);
            emptySpaceItem4.TextSize = new Size(0, 0);
            // 
            // ImportProgramUserControl
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "ImportProgramUserControl";
            Size = new Size(1613, 117);
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblReceiver).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtReceiver.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cbbStock.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbbSupplier.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBillsNumber.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDeliver.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dpkOrderDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dpkOrderDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgInvoiceInfor).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblSupplier).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblBillsNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblDeliver).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblOrderDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem lblReceiver;
        private DevExpress.XtraEditors.TextEdit txtReceiver;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cbbStock;
        private DevExpress.XtraEditors.ComboBoxEdit cbbSupplier;
        private DevExpress.XtraEditors.TextEdit txtBillsNumber;
        private DevExpress.XtraEditors.TextEdit txtDeliver;
        private DevExpress.XtraEditors.DateEdit dpkOrderDate;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup lcgInvoiceInfor;
        private DevExpress.XtraLayout.LayoutControlItem lblStock;
        private DevExpress.XtraLayout.LayoutControlItem lblSupplier;
        private DevExpress.XtraLayout.LayoutControlItem lblBillsNumber;
        private DevExpress.XtraLayout.LayoutControlItem lblDeliver;
        private DevExpress.XtraLayout.LayoutControlItem lblOrderDate;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
    }
}
