namespace NencerHis.Modules.Inventories.StockOrder.Forms
{
    partial class ApproveInventoryForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApproveInventoryForm));
            layoutControlThemMoi = new DevExpress.XtraLayout.LayoutControl();
            separatorControl2 = new DevExpress.XtraEditors.SeparatorControl();
            btnAdd = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            paginationControl = new Shared.UserControls.PaginationControl();
            gridApproveInventory = new DevExpress.XtraGrid.GridControl();
            gridViewApproveInventory = new DevExpress.XtraGrid.Views.Grid.GridView();
            layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem77 = new DevExpress.XtraLayout.LayoutControlItem();
            lblSum = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem36 = new DevExpress.XtraLayout.LayoutControlItem();
            imageCollection = new DevExpress.Utils.ImageCollection(components);
            ((System.ComponentModel.ISupportInitialize)layoutControlThemMoi).BeginInit();
            layoutControlThemMoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)separatorControl2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridApproveInventory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewApproveInventory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem77).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblSum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem26).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem35).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem36).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection).BeginInit();
            SuspendLayout();
            // 
            // layoutControlThemMoi
            // 
            layoutControlThemMoi.Controls.Add(separatorControl2);
            layoutControlThemMoi.Controls.Add(btnAdd);
            layoutControlThemMoi.Controls.Add(btnCancel);
            layoutControlThemMoi.Controls.Add(paginationControl);
            layoutControlThemMoi.Controls.Add(gridApproveInventory);
            layoutControlThemMoi.Dock = DockStyle.Fill;
            layoutControlThemMoi.Location = new Point(0, 0);
            layoutControlThemMoi.Name = "layoutControlThemMoi";
            layoutControlThemMoi.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(311, 401, 934, 493);
            layoutControlThemMoi.Root = layoutControlGroup2;
            layoutControlThemMoi.Size = new Size(1633, 729);
            layoutControlThemMoi.TabIndex = 5;
            layoutControlThemMoi.Text = "layoutControl2";
            // 
            // separatorControl2
            // 
            separatorControl2.AutoSizeMode = true;
            separatorControl2.Location = new Point(12, 671);
            separatorControl2.Margin = new Padding(0);
            separatorControl2.Name = "separatorControl2";
            separatorControl2.Padding = new Padding(0, 9, 0, 9);
            separatorControl2.Size = new Size(1609, 20);
            separatorControl2.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            btnAdd.Appearance.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.Appearance.Options.UseBackColor = true;
            btnAdd.Appearance.Options.UseFont = true;
            btnAdd.ImageOptions.Image = (Image)resources.GetObject("btnAdd.ImageOptions.Image");
            btnAdd.Location = new Point(1385, 695);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(116, 22);
            btnAdd.StyleController = layoutControlThemMoi;
            btnAdd.TabIndex = 30;
            btnAdd.Text = "Nhập kho (F2)";
            btnAdd.Click += btnAdd_Click;
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
            btnCancel.Location = new Point(1505, 695);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(116, 22);
            btnCancel.StyleController = layoutControlThemMoi;
            btnCancel.TabIndex = 32;
            btnCancel.Text = "Hủy bỏ (F4)";
            btnCancel.Click += btnCancel_Click;
            // 
            // paginationControl
            // 
            paginationControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            paginationControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            paginationControl.BackColor = Color.Transparent;
            paginationControl.ChangeNumberPage = (List<int>)resources.GetObject("paginationControl.ChangeNumberPage");
            paginationControl.CurrentPage = 1;
            paginationControl.Location = new Point(27, 640);
            paginationControl.Margin = new Padding(0, 0, 9, 0);
            paginationControl.MaxResultCount = 10;
            paginationControl.Name = "paginationControl";
            paginationControl.Size = new Size(1594, 27);
            paginationControl.TabIndex = 29;
            paginationControl.TotalCount = 0;
            // 
            // gridApproveInventory
            // 
            gridApproveInventory.Location = new Point(12, 12);
            gridApproveInventory.MainView = gridViewApproveInventory;
            gridApproveInventory.Name = "gridApproveInventory";
            gridApproveInventory.Size = new Size(1609, 624);
            gridApproveInventory.TabIndex = 28;
            gridApproveInventory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewApproveInventory });
            // 
            // gridViewApproveInventory
            // 
            gridViewApproveInventory.GridControl = gridApproveInventory;
            gridViewApproveInventory.Name = "gridViewApproveInventory";
            gridViewApproveInventory.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlGroup2
            // 
            layoutControlGroup2.AppearanceGroup.Options.UseBorderColor = true;
            layoutControlGroup2.AppearanceItemCaption.BorderColor = Color.Black;
            layoutControlGroup2.AppearanceItemCaption.Options.UseBorderColor = true;
            layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem77, lblSum, emptySpaceItem10, layoutControlItem26, layoutControlItem35, layoutControlItem36 });
            layoutControlGroup2.Name = "Root";
            layoutControlGroup2.Size = new Size(1633, 729);
            layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem77
            // 
            layoutControlItem77.Control = gridApproveInventory;
            layoutControlItem77.Location = new Point(0, 0);
            layoutControlItem77.Name = "layoutControlItem77";
            layoutControlItem77.Size = new Size(1613, 628);
            layoutControlItem77.TextSize = new Size(0, 0);
            layoutControlItem77.TextVisible = false;
            // 
            // lblSum
            // 
            lblSum.Control = paginationControl;
            lblSum.Location = new Point(0, 628);
            lblSum.Name = "lblSum";
            lblSum.Size = new Size(1613, 31);
            lblSum.Text = " ";
            lblSum.TextSize = new Size(3, 13);
            // 
            // emptySpaceItem10
            // 
            emptySpaceItem10.AllowHotTrack = false;
            emptySpaceItem10.Location = new Point(0, 683);
            emptySpaceItem10.Name = "emptySpaceItem10";
            emptySpaceItem10.Size = new Size(1373, 26);
            emptySpaceItem10.TextSize = new Size(0, 0);
            // 
            // layoutControlItem26
            // 
            layoutControlItem26.Control = btnCancel;
            layoutControlItem26.Location = new Point(1493, 683);
            layoutControlItem26.MaxSize = new Size(120, 26);
            layoutControlItem26.MinSize = new Size(120, 26);
            layoutControlItem26.Name = "layoutControlItem26";
            layoutControlItem26.Size = new Size(120, 26);
            layoutControlItem26.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem26.TextSize = new Size(0, 0);
            layoutControlItem26.TextVisible = false;
            // 
            // layoutControlItem35
            // 
            layoutControlItem35.Control = btnAdd;
            layoutControlItem35.Location = new Point(1373, 683);
            layoutControlItem35.MaxSize = new Size(120, 26);
            layoutControlItem35.MinSize = new Size(120, 26);
            layoutControlItem35.Name = "layoutControlItem35";
            layoutControlItem35.Size = new Size(120, 26);
            layoutControlItem35.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem35.TextSize = new Size(0, 0);
            layoutControlItem35.TextVisible = false;
            // 
            // layoutControlItem36
            // 
            layoutControlItem36.Control = separatorControl2;
            layoutControlItem36.Location = new Point(0, 659);
            layoutControlItem36.Name = "layoutControlItem36";
            layoutControlItem36.Size = new Size(1613, 24);
            layoutControlItem36.TextSize = new Size(0, 0);
            layoutControlItem36.TextVisible = false;
            // 
            // imageCollection
            // 
            imageCollection.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("imageCollection.ImageStream");
            imageCollection.Images.SetKeyName(0, "icons8-add-24.png");
            imageCollection.Images.SetKeyName(1, "icons8-close-garage-door-24.png");
            imageCollection.Images.SetKeyName(2, "icons8-handcart-24.png");
            imageCollection.Images.SetKeyName(3, "icons8-replace-24.png");
            // 
            // ApproveInventoryForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1633, 729);
            Controls.Add(layoutControlThemMoi);
            Name = "ApproveInventoryForm";
            Text = "ApproveInventoryForm";
            Load += ApproveInventoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)layoutControlThemMoi).EndInit();
            layoutControlThemMoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)separatorControl2).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridApproveInventory).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewApproveInventory).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem77).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblSum).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem10).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem26).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem35).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem36).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl layoutControlThemMoi;
        private DevExpress.XtraEditors.SeparatorControl separatorControl2;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private Shared.UserControls.PaginationControl paginationControl;
        private DevExpress.XtraGrid.GridControl gridApproveInventory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewApproveInventory;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem77;
        private DevExpress.XtraLayout.LayoutControlItem lblSum;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem35;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem36;
        private DevExpress.Utils.ImageCollection imageCollection;
    }
}