namespace NencerHis.Modules.Inventories.Package.Forms
{
    partial class PackageUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackageUserControl));
            layoutControlThemMoi = new DevExpress.XtraLayout.LayoutControl();
            btnAdd = new DevExpress.XtraEditors.SimpleButton();
            paginationControl = new Shared.UserControls.PaginationControl();
            separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            gridProductBids = new DevExpress.XtraGrid.GridControl();
            gridViewProductBids = new DevExpress.XtraGrid.Views.Grid.GridView();
            btnSearch = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            txtCode = new DevExpress.XtraEditors.TextEdit();
            txtName = new DevExpress.XtraEditors.TextEdit();
            cbbSupplier = new DevExpress.XtraEditors.ComboBoxEdit();
            txtCreator = new DevExpress.XtraEditors.TextEdit();
            layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            lblCode = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem77 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem78 = new DevExpress.XtraLayout.LayoutControlItem();
            lblSum = new DevExpress.XtraLayout.LayoutControlItem();
            lblName = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            lblSupplier = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            lblCreator = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem70 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem76 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)layoutControlThemMoi).BeginInit();
            layoutControlThemMoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)separatorControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridProductBids).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewProductBids).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbbSupplier.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCreator.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem77).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem78).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblSum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblSupplier).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblCreator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem70).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem76).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).BeginInit();
            SuspendLayout();
            // 
            // layoutControlThemMoi
            // 
            layoutControlThemMoi.Controls.Add(btnAdd);
            layoutControlThemMoi.Controls.Add(paginationControl);
            layoutControlThemMoi.Controls.Add(separatorControl1);
            layoutControlThemMoi.Controls.Add(gridProductBids);
            layoutControlThemMoi.Controls.Add(btnSearch);
            layoutControlThemMoi.Controls.Add(btnCancel);
            layoutControlThemMoi.Controls.Add(txtCode);
            layoutControlThemMoi.Controls.Add(txtName);
            layoutControlThemMoi.Controls.Add(cbbSupplier);
            layoutControlThemMoi.Controls.Add(txtCreator);
            layoutControlThemMoi.Dock = DockStyle.Fill;
            layoutControlThemMoi.Location = new Point(0, 0);
            layoutControlThemMoi.Name = "layoutControlThemMoi";
            layoutControlThemMoi.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(660, 373, 855, 514);
            layoutControlThemMoi.Root = layoutControlGroup2;
            layoutControlThemMoi.Size = new Size(1635, 761);
            layoutControlThemMoi.TabIndex = 3;
            layoutControlThemMoi.Text = "layoutControl2";
            // 
            // btnAdd
            // 
            btnAdd.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            btnAdd.Appearance.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.Appearance.Options.UseBackColor = true;
            btnAdd.Appearance.Options.UseFont = true;
            btnAdd.ImageOptions.Image = (Image)resources.GetObject("btnAdd.ImageOptions.Image");
            btnAdd.Location = new Point(12, 82);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(116, 31);
            btnAdd.StyleController = layoutControlThemMoi;
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Thêm mới (F2)";
            btnAdd.Click += btnAdd_Click;
            // 
            // paginationControl
            // 
            paginationControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            paginationControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            paginationControl.BackColor = Color.Transparent;
            paginationControl.ChangeNumberPage = (List<int>)resources.GetObject("paginationControl.ChangeNumberPage");
            paginationControl.CurrentPage = 1;
            paginationControl.Location = new Point(89, 718);
            paginationControl.Margin = new Padding(0, 0, 9, 0);
            paginationControl.MaxResultCount = 10;
            paginationControl.Name = "paginationControl";
            paginationControl.Size = new Size(1534, 31);
            paginationControl.TabIndex = 9;
            paginationControl.TotalCount = 0;
            // 
            // separatorControl1
            // 
            separatorControl1.AutoSizeMode = true;
            separatorControl1.Location = new Point(10, 60);
            separatorControl1.Margin = new Padding(0);
            separatorControl1.Name = "separatorControl1";
            separatorControl1.Size = new Size(1615, 20);
            separatorControl1.TabIndex = 1;
            // 
            // gridProductBids
            // 
            gridProductBids.Location = new Point(12, 117);
            gridProductBids.MainView = gridViewProductBids;
            gridProductBids.Name = "gridProductBids";
            gridProductBids.Size = new Size(1611, 597);
            gridProductBids.TabIndex = 8;
            gridProductBids.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewProductBids });
            // 
            // gridViewProductBids
            // 
            gridViewProductBids.GridControl = gridProductBids;
            gridViewProductBids.Name = "gridViewProductBids";
            gridViewProductBids.OptionsView.ShowGroupPanel = false;
            // 
            // btnSearch
            // 
            btnSearch.Appearance.BackColor = Color.FromArgb(255, 192, 128);
            btnSearch.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearch.Appearance.ForeColor = Color.White;
            btnSearch.Appearance.Options.UseBackColor = true;
            btnSearch.Appearance.Options.UseFont = true;
            btnSearch.Appearance.Options.UseForeColor = true;
            btnSearch.ImageOptions.Image = (Image)resources.GetObject("btnSearch.ImageOptions.Image");
            btnSearch.Location = new Point(1407, 36);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(101, 22);
            btnSearch.StyleController = layoutControlThemMoi;
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.Click += btnSearch_Click;
            // 
            // btnCancel
            // 
            btnCancel.Appearance.BackColor = Color.FromArgb(255, 128, 128);
            btnCancel.Appearance.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Appearance.ForeColor = Color.Black;
            btnCancel.Appearance.Options.UseBackColor = true;
            btnCancel.Appearance.Options.UseFont = true;
            btnCancel.Appearance.Options.UseForeColor = true;
            btnCancel.ImageOptions.Image = (Image)resources.GetObject("btnCancel.ImageOptions.Image");
            btnCancel.Location = new Point(1512, 36);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(101, 22);
            btnCancel.StyleController = layoutControlThemMoi;
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Hủy bỏ (F4)";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(89, 12);
            txtCode.Name = "txtCode";
            txtCode.Properties.Appearance.BackColor = Color.FromArgb(255, 255, 192);
            txtCode.Properties.Appearance.Options.UseBackColor = true;
            txtCode.Size = new Size(169, 20);
            txtCode.StyleController = layoutControlThemMoi;
            txtCode.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(339, 12);
            txtName.Name = "txtName";
            txtName.Size = new Size(169, 20);
            txtName.StyleController = layoutControlThemMoi;
            txtName.TabIndex = 2;
            // 
            // cbbSupplier
            // 
            cbbSupplier.Location = new Point(89, 36);
            cbbSupplier.Name = "cbbSupplier";
            cbbSupplier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbbSupplier.Size = new Size(169, 20);
            cbbSupplier.StyleController = layoutControlThemMoi;
            cbbSupplier.TabIndex = 3;
            // 
            // txtCreator
            // 
            txtCreator.Location = new Point(339, 36);
            txtCreator.Name = "txtCreator";
            txtCreator.Size = new Size(169, 20);
            txtCreator.StyleController = layoutControlThemMoi;
            txtCreator.TabIndex = 4;
            // 
            // layoutControlGroup2
            // 
            layoutControlGroup2.AppearanceGroup.Options.UseBorderColor = true;
            layoutControlGroup2.AppearanceItemCaption.BorderColor = Color.Black;
            layoutControlGroup2.AppearanceItemCaption.Options.UseBorderColor = true;
            layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lblCode, layoutControlItem77, layoutControlItem78, lblSum, lblName, emptySpaceItem9, lblSupplier, emptySpaceItem4, lblCreator, layoutControlItem70, layoutControlItem76, emptySpaceItem1, emptySpaceItem2, layoutControlItem1 });
            layoutControlGroup2.Name = "Root";
            layoutControlGroup2.Size = new Size(1635, 761);
            layoutControlGroup2.TextVisible = false;
            // 
            // lblCode
            // 
            lblCode.Control = txtCode;
            lblCode.Location = new Point(0, 0);
            lblCode.MaxSize = new Size(250, 24);
            lblCode.MinSize = new Size(250, 24);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(250, 24);
            lblCode.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lblCode.Text = "Mã gói thầu";
            lblCode.TextSize = new Size(65, 13);
            // 
            // layoutControlItem77
            // 
            layoutControlItem77.Control = gridProductBids;
            layoutControlItem77.Location = new Point(0, 105);
            layoutControlItem77.Name = "layoutControlItem77";
            layoutControlItem77.Size = new Size(1615, 601);
            layoutControlItem77.TextSize = new Size(0, 0);
            layoutControlItem77.TextVisible = false;
            // 
            // layoutControlItem78
            // 
            layoutControlItem78.Control = separatorControl1;
            layoutControlItem78.Location = new Point(0, 50);
            layoutControlItem78.MaxSize = new Size(0, 20);
            layoutControlItem78.MinSize = new Size(100, 20);
            layoutControlItem78.Name = "layoutControlItem78";
            layoutControlItem78.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            layoutControlItem78.Size = new Size(1615, 20);
            layoutControlItem78.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem78.TextSize = new Size(0, 0);
            layoutControlItem78.TextVisible = false;
            // 
            // lblSum
            // 
            lblSum.Control = paginationControl;
            lblSum.Location = new Point(0, 706);
            lblSum.Name = "lblSum";
            lblSum.Size = new Size(1615, 35);
            lblSum.Text = " ";
            lblSum.TextSize = new Size(65, 13);
            // 
            // lblName
            // 
            lblName.Control = txtName;
            lblName.Location = new Point(250, 0);
            lblName.MaxSize = new Size(250, 24);
            lblName.MinSize = new Size(250, 24);
            lblName.Name = "lblName";
            lblName.Size = new Size(250, 24);
            lblName.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lblName.Text = "Tên gói thầu";
            lblName.TextSize = new Size(65, 13);
            // 
            // emptySpaceItem9
            // 
            emptySpaceItem9.AllowHotTrack = false;
            emptySpaceItem9.Location = new Point(500, 0);
            emptySpaceItem9.Name = "emptySpaceItem9";
            emptySpaceItem9.Size = new Size(1115, 24);
            emptySpaceItem9.TextSize = new Size(0, 0);
            // 
            // lblSupplier
            // 
            lblSupplier.Control = cbbSupplier;
            lblSupplier.Location = new Point(0, 24);
            lblSupplier.MaxSize = new Size(250, 24);
            lblSupplier.MinSize = new Size(250, 24);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(250, 26);
            lblSupplier.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lblSupplier.Text = "Nhà cung cấp";
            lblSupplier.TextSize = new Size(65, 13);
            // 
            // emptySpaceItem4
            // 
            emptySpaceItem4.AllowHotTrack = false;
            emptySpaceItem4.Location = new Point(500, 24);
            emptySpaceItem4.Name = "emptySpaceItem4";
            emptySpaceItem4.Size = new Size(895, 26);
            emptySpaceItem4.TextSize = new Size(0, 0);
            // 
            // lblCreator
            // 
            lblCreator.Control = txtCreator;
            lblCreator.Location = new Point(250, 24);
            lblCreator.MaxSize = new Size(250, 24);
            lblCreator.MinSize = new Size(250, 24);
            lblCreator.Name = "lblCreator";
            lblCreator.Size = new Size(250, 26);
            lblCreator.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lblCreator.Text = "Người tạo";
            lblCreator.TextSize = new Size(65, 13);
            // 
            // layoutControlItem70
            // 
            layoutControlItem70.Control = btnCancel;
            layoutControlItem70.Location = new Point(1500, 24);
            layoutControlItem70.MaxSize = new Size(105, 26);
            layoutControlItem70.MinSize = new Size(105, 26);
            layoutControlItem70.Name = "layoutControlItem70";
            layoutControlItem70.Size = new Size(105, 26);
            layoutControlItem70.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem70.TextSize = new Size(0, 0);
            layoutControlItem70.TextVisible = false;
            // 
            // layoutControlItem76
            // 
            layoutControlItem76.Control = btnSearch;
            layoutControlItem76.Location = new Point(1395, 24);
            layoutControlItem76.MaxSize = new Size(105, 26);
            layoutControlItem76.MinSize = new Size(105, 26);
            layoutControlItem76.Name = "layoutControlItem76";
            layoutControlItem76.Size = new Size(105, 26);
            layoutControlItem76.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem76.TextSize = new Size(0, 0);
            layoutControlItem76.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new Point(1605, 24);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(10, 26);
            emptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = btnAdd;
            layoutControlItem1.Location = new Point(0, 70);
            layoutControlItem1.MaxSize = new Size(120, 35);
            layoutControlItem1.MinSize = new Size(120, 35);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(120, 35);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.TextSize = new Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.AllowHotTrack = false;
            emptySpaceItem2.Location = new Point(120, 70);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new Size(1495, 35);
            emptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // PackageUserControl
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutControlThemMoi);
            Name = "PackageUserControl";
            Size = new Size(1635, 761);
            Load += PackageUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)layoutControlThemMoi).EndInit();
            layoutControlThemMoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)separatorControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridProductBids).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewProductBids).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbbSupplier.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCreator.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem77).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem78).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblSum).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblName).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem9).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblSupplier).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblCreator).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem70).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem76).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl layoutControlThemMoi;
        private Shared.UserControls.PaginationControl paginationControl;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraGrid.GridControl gridProductBids;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProductBids;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
        private DevExpress.XtraLayout.LayoutControlItem lblCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem70;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem76;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem77;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem78;
        private DevExpress.XtraLayout.LayoutControlItem lblSum;
        private DevExpress.XtraLayout.LayoutControlItem lblName;
        private DevExpress.XtraEditors.ComboBoxEdit cbbSupplier;
        private DevExpress.XtraLayout.LayoutControlItem lblSupplier;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraEditors.TextEdit txtCreator;
        private DevExpress.XtraLayout.LayoutControlItem lblCreator;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}
