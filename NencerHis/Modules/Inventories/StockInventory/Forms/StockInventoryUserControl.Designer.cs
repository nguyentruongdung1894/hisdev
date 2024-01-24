namespace NencerHis.Modules.Inventories.StockInventory.Forms
{
    partial class StockInventoryUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockInventoryUserControl));
            layoutControlThemMoi = new DevExpress.XtraLayout.LayoutControl();
            paginationControl = new Shared.UserControls.PaginationControl();
            separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            gridInventories = new DevExpress.XtraGrid.GridControl();
            gridViewInventories = new DevExpress.XtraGrid.Views.Grid.GridView();
            btnSearch = new DevExpress.XtraEditors.SimpleButton();
            cbbStock = new DevExpress.XtraEditors.ComboBoxEdit();
            layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem71 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem12 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem76 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem23 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem77 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem78 = new DevExpress.XtraLayout.LayoutControlItem();
            lblSum = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControlThemMoi).BeginInit();
            layoutControlThemMoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)separatorControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridInventories).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewInventories).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbbStock.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem71).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem76).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem23).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem77).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem78).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblSum).BeginInit();
            SuspendLayout();
            // 
            // layoutControlThemMoi
            // 
            layoutControlThemMoi.Controls.Add(paginationControl);
            layoutControlThemMoi.Controls.Add(separatorControl1);
            layoutControlThemMoi.Controls.Add(gridInventories);
            layoutControlThemMoi.Controls.Add(btnSearch);
            layoutControlThemMoi.Controls.Add(cbbStock);
            layoutControlThemMoi.Dock = DockStyle.Fill;
            layoutControlThemMoi.Location = new Point(0, 0);
            layoutControlThemMoi.Name = "layoutControlThemMoi";
            layoutControlThemMoi.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(519, 232, 650, 493);
            layoutControlThemMoi.Root = layoutControlGroup2;
            layoutControlThemMoi.Size = new Size(1635, 761);
            layoutControlThemMoi.TabIndex = 3;
            layoutControlThemMoi.Text = "layoutControl2";
            // 
            // paginationControl
            // 
            paginationControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            paginationControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            paginationControl.BackColor = Color.Transparent;
            paginationControl.ChangeNumberPage = (List<int>)resources.GetObject("paginationControl.ChangeNumberPage");
            paginationControl.CurrentPage = 1;
            paginationControl.Location = new Point(27, 717);
            paginationControl.Margin = new Padding(0, 0, 9, 0);
            paginationControl.MaxResultCount = 10;
            paginationControl.Name = "paginationControl";
            paginationControl.Size = new Size(1596, 32);
            paginationControl.TabIndex = 11;
            paginationControl.TotalCount = 0;
            // 
            // separatorControl1
            // 
            separatorControl1.AutoSizeMode = true;
            separatorControl1.Location = new Point(10, 10);
            separatorControl1.Margin = new Padding(0);
            separatorControl1.Name = "separatorControl1";
            separatorControl1.Size = new Size(1615, 20);
            separatorControl1.TabIndex = 1;
            // 
            // gridInventories
            // 
            gridInventories.Location = new Point(12, 58);
            gridInventories.MainView = gridViewInventories;
            gridInventories.Name = "gridInventories";
            gridInventories.Size = new Size(1611, 655);
            gridInventories.TabIndex = 10;
            gridInventories.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewInventories });
            // 
            // gridViewInventories
            // 
            gridViewInventories.GridControl = gridInventories;
            gridViewInventories.Name = "gridViewInventories";
            gridViewInventories.OptionsView.ShowGroupPanel = false;
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
            btnSearch.Location = new Point(136, 32);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(97, 22);
            btnSearch.StyleController = layoutControlThemMoi;
            btnSearch.TabIndex = 9;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.Click += btnSearch_Click;
            // 
            // cbbStock
            // 
            cbbStock.EditValue = "Tên kho";
            cbbStock.Location = new Point(12, 32);
            cbbStock.Name = "cbbStock";
            cbbStock.Properties.Appearance.ForeColor = Color.Gray;
            cbbStock.Properties.Appearance.Options.UseForeColor = true;
            cbbStock.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbbStock.Size = new Size(86, 20);
            cbbStock.StyleController = layoutControlThemMoi;
            cbbStock.TabIndex = 8;
            // 
            // layoutControlGroup2
            // 
            layoutControlGroup2.AppearanceGroup.Options.UseBorderColor = true;
            layoutControlGroup2.AppearanceItemCaption.BorderColor = Color.Black;
            layoutControlGroup2.AppearanceItemCaption.Options.UseBorderColor = true;
            layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem71, emptySpaceItem12, layoutControlItem76, emptySpaceItem23, layoutControlItem77, layoutControlItem78, lblSum });
            layoutControlGroup2.Name = "Root";
            layoutControlGroup2.Size = new Size(1635, 761);
            layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem71
            // 
            layoutControlItem71.Control = cbbStock;
            layoutControlItem71.Location = new Point(0, 20);
            layoutControlItem71.MinSize = new Size(50, 25);
            layoutControlItem71.Name = "layoutControlItem71";
            layoutControlItem71.Size = new Size(90, 26);
            layoutControlItem71.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem71.TextSize = new Size(0, 0);
            layoutControlItem71.TextVisible = false;
            // 
            // emptySpaceItem12
            // 
            emptySpaceItem12.AllowHotTrack = false;
            emptySpaceItem12.AppearanceItemCaption.BorderColor = Color.Black;
            emptySpaceItem12.AppearanceItemCaption.Options.UseBorderColor = true;
            emptySpaceItem12.Location = new Point(225, 20);
            emptySpaceItem12.Name = "emptySpaceItem12";
            emptySpaceItem12.Size = new Size(1390, 26);
            emptySpaceItem12.TextSize = new Size(0, 0);
            // 
            // layoutControlItem76
            // 
            layoutControlItem76.Control = btnSearch;
            layoutControlItem76.Location = new Point(124, 20);
            layoutControlItem76.MaxSize = new Size(101, 26);
            layoutControlItem76.MinSize = new Size(101, 26);
            layoutControlItem76.Name = "layoutControlItem76";
            layoutControlItem76.Size = new Size(101, 26);
            layoutControlItem76.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem76.TextSize = new Size(0, 0);
            layoutControlItem76.TextVisible = false;
            // 
            // emptySpaceItem23
            // 
            emptySpaceItem23.AllowHotTrack = false;
            emptySpaceItem23.Location = new Point(90, 20);
            emptySpaceItem23.MaxSize = new Size(34, 26);
            emptySpaceItem23.MinSize = new Size(34, 26);
            emptySpaceItem23.Name = "emptySpaceItem23";
            emptySpaceItem23.Size = new Size(34, 26);
            emptySpaceItem23.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            emptySpaceItem23.TextSize = new Size(0, 0);
            // 
            // layoutControlItem77
            // 
            layoutControlItem77.Control = gridInventories;
            layoutControlItem77.Location = new Point(0, 46);
            layoutControlItem77.Name = "layoutControlItem77";
            layoutControlItem77.Size = new Size(1615, 659);
            layoutControlItem77.TextSize = new Size(0, 0);
            layoutControlItem77.TextVisible = false;
            // 
            // layoutControlItem78
            // 
            layoutControlItem78.Control = separatorControl1;
            layoutControlItem78.Location = new Point(0, 0);
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
            lblSum.Location = new Point(0, 705);
            lblSum.Name = "lblSum";
            lblSum.Size = new Size(1615, 36);
            lblSum.Text = " ";
            lblSum.TextSize = new Size(3, 13);
            // 
            // StockInventoryUserControl
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutControlThemMoi);
            Name = "StockInventoryUserControl";
            Size = new Size(1635, 761);
            Load += StockInventoryUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)layoutControlThemMoi).EndInit();
            layoutControlThemMoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)separatorControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridInventories).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewInventories).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbbStock.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem71).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem12).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem76).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem23).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem77).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem78).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblSum).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControlThemMoi;
        private Shared.UserControls.PaginationControl paginationControl;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraGrid.GridControl gridInventories;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewInventories;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem71;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem76;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem23;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem77;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem78;
        private DevExpress.XtraLayout.LayoutControlItem lblSum;
        private DevExpress.XtraEditors.ComboBoxEdit cbbStock;
    }
}
