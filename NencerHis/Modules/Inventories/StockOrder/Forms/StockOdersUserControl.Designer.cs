namespace NencerHis.Modules.Inventories.StockOrder.Forms
{
    partial class StockOdersUserControl
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockOdersUserControl));
            layoutControlThemMoi = new DevExpress.XtraLayout.LayoutControl();
            btnSearch = new DevExpress.XtraEditors.SimpleButton();
            paginationControl = new Shared.UserControls.PaginationControl();
            separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            gridStockOders = new DevExpress.XtraGrid.GridControl();
            gridViewStockOders = new DevExpress.XtraGrid.Views.Grid.GridView();
            cbbSearchType = new DevExpress.XtraEditors.ComboBoxEdit();
            cbbAdd = new DevExpress.XtraEditors.ImageComboBoxEdit();
            imageCollection = new DevExpress.Utils.ImageCollection(components);
            dpkSearchFromDate = new DevExpress.XtraEditors.DateEdit();
            dpkSearchToDate = new DevExpress.XtraEditors.DateEdit();
            layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem77 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem78 = new DevExpress.XtraLayout.LayoutControlItem();
            lblSum = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            lblSearchType = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            imageComboBoxEdit = new DevExpress.XtraLayout.LayoutControlItem();
            lblSearchFromDate = new DevExpress.XtraLayout.LayoutControlItem();
            lblSearchToDate = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControlThemMoi).BeginInit();
            layoutControlThemMoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)separatorControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridStockOders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewStockOders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbbSearchType.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbbAdd.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dpkSearchFromDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dpkSearchFromDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dpkSearchToDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dpkSearchToDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem77).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem78).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblSum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblSearchType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageComboBoxEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblSearchFromDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblSearchToDate).BeginInit();
            SuspendLayout();
            // 
            // layoutControlThemMoi
            // 
            layoutControlThemMoi.Controls.Add(btnSearch);
            layoutControlThemMoi.Controls.Add(paginationControl);
            layoutControlThemMoi.Controls.Add(separatorControl1);
            layoutControlThemMoi.Controls.Add(gridStockOders);
            layoutControlThemMoi.Controls.Add(cbbSearchType);
            layoutControlThemMoi.Controls.Add(cbbAdd);
            layoutControlThemMoi.Controls.Add(dpkSearchFromDate);
            layoutControlThemMoi.Controls.Add(dpkSearchToDate);
            layoutControlThemMoi.Dock = DockStyle.Fill;
            layoutControlThemMoi.Location = new Point(0, 0);
            layoutControlThemMoi.Name = "layoutControlThemMoi";
            layoutControlThemMoi.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(519, 232, 650, 493);
            layoutControlThemMoi.Root = layoutControlGroup2;
            layoutControlThemMoi.Size = new Size(1635, 761);
            layoutControlThemMoi.TabIndex = 3;
            layoutControlThemMoi.Text = "layoutControl2";
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
            btnSearch.Location = new Point(1526, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(97, 22);
            btnSearch.StyleController = layoutControlThemMoi;
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.Click += btnSearch_Click;
            // 
            // paginationControl
            // 
            paginationControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            paginationControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            paginationControl.BackColor = Color.Transparent;
            paginationControl.ChangeNumberPage = (List<int>)resources.GetObject("paginationControl.ChangeNumberPage");
            paginationControl.CurrentPage = 1;
            paginationControl.Location = new Point(72, 718);
            paginationControl.Margin = new Padding(0, 0, 9, 0);
            paginationControl.MaxResultCount = 10;
            paginationControl.Name = "paginationControl";
            paginationControl.Size = new Size(1551, 31);
            paginationControl.TabIndex = 5;
            paginationControl.TotalCount = 0;
            // 
            // separatorControl1
            // 
            separatorControl1.AutoSizeMode = true;
            separatorControl1.Location = new Point(10, 36);
            separatorControl1.Margin = new Padding(0);
            separatorControl1.Name = "separatorControl1";
            separatorControl1.Padding = new Padding(0, 9, 0, 9);
            separatorControl1.Size = new Size(1615, 20);
            separatorControl1.TabIndex = 1;
            // 
            // gridStockOders
            // 
            gridStockOders.Location = new Point(12, 58);
            gridStockOders.MainView = gridViewStockOders;
            gridStockOders.Name = "gridStockOders";
            gridStockOders.Size = new Size(1611, 656);
            gridStockOders.TabIndex = 4;
            gridStockOders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewStockOders });
            // 
            // gridViewStockOders
            // 
            gridViewStockOders.GridControl = gridStockOders;
            gridViewStockOders.Name = "gridViewStockOders";
            gridViewStockOders.OptionsView.ShowGroupPanel = false;
            gridViewStockOders.DoubleClick += gridViewStockOders_DoubleClick;
            // 
            // cbbSearchType
            // 
            cbbSearchType.Location = new Point(952, 12);
            cbbSearchType.Name = "cbbSearchType";
            cbbSearchType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbbSearchType.Size = new Size(136, 20);
            cbbSearchType.StyleController = layoutControlThemMoi;
            cbbSearchType.TabIndex = 2;
            // 
            // cbbAdd
            // 
            cbbAdd.EditValue = "0";
            cbbAdd.Location = new Point(12, 12);
            cbbAdd.Name = "cbbAdd";
            cbbAdd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbbAdd.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] { new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Thêm", "0", 0), new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Nhập từ nhà cung cấp", (short)1, 1), new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Nhập từ nguồn chương trình", (short)2, 2), new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Nhập từ kho khác", (short)3, 3), new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Xuất khách lẻ", "4", 4), new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Xuất hủy", "5", 5), new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Xuất khác", "6", 6), new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Xuất trả nhà cung cấp", null, 7) });
            cbbAdd.Properties.SmallImages = imageCollection;
            cbbAdd.Size = new Size(76, 20);
            cbbAdd.StyleController = layoutControlThemMoi;
            cbbAdd.TabIndex = 0;
            cbbAdd.SelectedValueChanged += cbbAdd_SelectedValueChanged;
            // 
            // imageCollection
            // 
            imageCollection.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("imageCollection.ImageStream");
            imageCollection.Images.SetKeyName(0, "icons8-add-24.png");
            imageCollection.Images.SetKeyName(1, "icons8-close-garage-door-24.png");
            imageCollection.Images.SetKeyName(2, "icons8-handcart-24.png");
            imageCollection.Images.SetKeyName(3, "icons8-replace-24.png");
            imageCollection.Images.SetKeyName(4, "icons8-resume-50.png");
            imageCollection.Images.SetKeyName(5, "icons8-cancel-50.png");
            imageCollection.Images.SetKeyName(6, "icons8-other-50.png");
            imageCollection.Images.SetKeyName(7, "icons8-return-50.png");
            // 
            // dpkSearchFromDate
            // 
            dpkSearchFromDate.EditValue = null;
            dpkSearchFromDate.Location = new Point(1152, 12);
            dpkSearchFromDate.Name = "dpkSearchFromDate";
            dpkSearchFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dpkSearchFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dpkSearchFromDate.Size = new Size(136, 20);
            dpkSearchFromDate.StyleController = layoutControlThemMoi;
            dpkSearchFromDate.TabIndex = 6;
            // 
            // dpkSearchToDate
            // 
            dpkSearchToDate.EditValue = null;
            dpkSearchToDate.Location = new Point(1352, 12);
            dpkSearchToDate.Name = "dpkSearchToDate";
            dpkSearchToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dpkSearchToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dpkSearchToDate.Size = new Size(136, 20);
            dpkSearchToDate.StyleController = layoutControlThemMoi;
            dpkSearchToDate.TabIndex = 7;
            // 
            // layoutControlGroup2
            // 
            layoutControlGroup2.AppearanceGroup.Options.UseBorderColor = true;
            layoutControlGroup2.AppearanceItemCaption.BorderColor = Color.Black;
            layoutControlGroup2.AppearanceItemCaption.Options.UseBorderColor = true;
            layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem77, layoutControlItem78, lblSum, emptySpaceItem7, layoutControlItem1, lblSearchType, emptySpaceItem1, imageComboBoxEdit, lblSearchFromDate, lblSearchToDate });
            layoutControlGroup2.Name = "Root";
            layoutControlGroup2.Size = new Size(1635, 761);
            layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem77
            // 
            layoutControlItem77.Control = gridStockOders;
            layoutControlItem77.Location = new Point(0, 46);
            layoutControlItem77.Name = "layoutControlItem77";
            layoutControlItem77.Size = new Size(1615, 660);
            layoutControlItem77.TextSize = new Size(0, 0);
            layoutControlItem77.TextVisible = false;
            // 
            // layoutControlItem78
            // 
            layoutControlItem78.Control = separatorControl1;
            layoutControlItem78.Location = new Point(0, 26);
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
            lblSum.TextSize = new Size(48, 13);
            // 
            // emptySpaceItem7
            // 
            emptySpaceItem7.AllowHotTrack = false;
            emptySpaceItem7.Location = new Point(80, 0);
            emptySpaceItem7.Name = "emptySpaceItem7";
            emptySpaceItem7.Size = new Size(800, 26);
            emptySpaceItem7.TextSize = new Size(0, 0);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = btnSearch;
            layoutControlItem1.Location = new Point(1514, 0);
            layoutControlItem1.MaxSize = new Size(101, 26);
            layoutControlItem1.MinSize = new Size(101, 26);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(101, 26);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.TextSize = new Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // lblSearchType
            // 
            lblSearchType.Control = cbbSearchType;
            lblSearchType.Location = new Point(880, 0);
            lblSearchType.MaxSize = new Size(200, 24);
            lblSearchType.MinSize = new Size(200, 24);
            lblSearchType.Name = "lblSearchType";
            lblSearchType.Size = new Size(200, 26);
            lblSearchType.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lblSearchType.Text = "Loại phiếu";
            lblSearchType.TextSize = new Size(48, 13);
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new Point(1480, 0);
            emptySpaceItem1.MaxSize = new Size(34, 26);
            emptySpaceItem1.MinSize = new Size(34, 26);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(34, 26);
            emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            emptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // imageComboBoxEdit
            // 
            imageComboBoxEdit.Control = cbbAdd;
            imageComboBoxEdit.Location = new Point(0, 0);
            imageComboBoxEdit.MaxSize = new Size(80, 24);
            imageComboBoxEdit.MinSize = new Size(80, 24);
            imageComboBoxEdit.Name = "imageComboBoxEdit";
            imageComboBoxEdit.Size = new Size(80, 26);
            imageComboBoxEdit.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            imageComboBoxEdit.Text = "Thêm mới";
            imageComboBoxEdit.TextSize = new Size(0, 0);
            imageComboBoxEdit.TextVisible = false;
            // 
            // lblSearchFromDate
            // 
            lblSearchFromDate.Control = dpkSearchFromDate;
            lblSearchFromDate.Location = new Point(1080, 0);
            lblSearchFromDate.MaxSize = new Size(200, 24);
            lblSearchFromDate.MinSize = new Size(200, 24);
            lblSearchFromDate.Name = "lblSearchFromDate";
            lblSearchFromDate.Size = new Size(200, 26);
            lblSearchFromDate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lblSearchFromDate.Text = "Từ ngày";
            lblSearchFromDate.TextSize = new Size(48, 13);
            // 
            // lblSearchToDate
            // 
            lblSearchToDate.Control = dpkSearchToDate;
            lblSearchToDate.Location = new Point(1280, 0);
            lblSearchToDate.MaxSize = new Size(200, 24);
            lblSearchToDate.MinSize = new Size(200, 24);
            lblSearchToDate.Name = "lblSearchToDate";
            lblSearchToDate.Size = new Size(200, 26);
            lblSearchToDate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lblSearchToDate.Text = "Đến ngày";
            lblSearchToDate.TextSize = new Size(48, 13);
            // 
            // StockOdersUserControl
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutControlThemMoi);
            Name = "StockOdersUserControl";
            Size = new Size(1635, 761);
            Load += StockOdersUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)layoutControlThemMoi).EndInit();
            layoutControlThemMoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)separatorControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridStockOders).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewStockOders).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbbSearchType.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbbAdd.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection).EndInit();
            ((System.ComponentModel.ISupportInitialize)dpkSearchFromDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dpkSearchFromDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dpkSearchToDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dpkSearchToDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem77).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem78).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblSum).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblSearchType).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageComboBoxEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblSearchFromDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblSearchToDate).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl layoutControlThemMoi;
        private Shared.UserControls.PaginationControl paginationControl;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraGrid.GridControl gridStockOders;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewStockOders;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem77;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem78;
        private DevExpress.XtraLayout.LayoutControlItem lblSum;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ComboBoxEdit cbbSearchType;
        private DevExpress.XtraLayout.LayoutControlItem lblSearchType;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbbAdd;
        private DevExpress.XtraLayout.LayoutControlItem imageComboBoxEdit;
        private DevExpress.XtraEditors.DateEdit dpkSearchFromDate;
        private DevExpress.XtraEditors.DateEdit dpkSearchToDate;
        private DevExpress.XtraLayout.LayoutControlItem lblSearchFromDate;
        private DevExpress.XtraLayout.LayoutControlItem lblSearchToDate;
    }
}
