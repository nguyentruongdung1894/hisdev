namespace NencerHis.Shared.UserControls
{
    public partial class PaginationControl : UserControl
    {
        public delegate void PageChangedEventHandler(object sender, EventArgs e);
        public event PageChangedEventHandler PageChanged;

        private List<int> listNumberOfResultView = new List<int>
        {
            10, 25, 50, 100
        };

        public int MaxResultCount { get; set; } = 10;
        public int TotalCount { get; set; } = 0;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get => Math.Max(1, (int)Math.Ceiling((decimal)TotalCount / MaxResultCount)); }
        public int SkipCount { get => (CurrentPage - 1) * MaxResultCount; }

        public List<int> ChangeNumberPage
        {
            get { return listNumberOfResultView; }
            set
            {
                listNumberOfResultView = value;
                cbNumberResultView.DataSource = listNumberOfResultView;
                // Thực hiện thêm bất kỳ logic bổ sung nào ở đây nếu cần
            }
        }

        public PaginationControl()
        {
            InitializeComponent();
            ConfigUILocalization();
            cbNumberResultView.DataSource = listNumberOfResultView;
        }

        public void RefreshPaging(int totalCount)
        {
            TotalCount = totalCount;

            // Active | Disable button First, Pre khi đang ở trang 1
            if (CurrentPage == 1)
            {
                btnFirst.Enabled = false;
                btnPre.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnPre.Enabled = true;
            }

            // Active | Disable button Last, Next khi đang ở trang cuối
            if (CurrentPage == TotalPages)
            {
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnNext.Enabled = true;
            }


            // Show | Hide số lượng button dựa vào số trang
            if (TotalPages == 1)
            {
                btnPage1.Visible = true;
                btnPage2.Visible = false;
                btnPage3.Visible = false;
                btnPage1.Text = "1";
            }
            else if (TotalPages == 2)
            {
                btnPage1.Visible = true;
                btnPage2.Visible = true;
                btnPage3.Visible = false;
                btnPage1.Text = "1";
                btnPage2.Text = "2";
            }
            else if (TotalPages > 2)
            {
                btnPage1.Visible = true;
                btnPage2.Visible = true;
                btnPage3.Visible = true;

                if (CurrentPage < TotalPages && CurrentPage > 1)
                {
                    btnPage1.Text = (CurrentPage - 1).ToString();
                    btnPage2.Text = CurrentPage.ToString();
                    btnPage3.Text = (CurrentPage + 1).ToString();
                }
                else
                {
                    if (CurrentPage == 1)
                    {
                        btnPage1.Text = CurrentPage.ToString();
                        btnPage2.Text = (CurrentPage + 1).ToString();
                        btnPage3.Text = (CurrentPage + 2).ToString();
                    }
                    else
                    {
                        btnPage1.Text = (CurrentPage - 2).ToString();
                        btnPage2.Text = (CurrentPage - 1).ToString();
                        btnPage3.Text = CurrentPage.ToString();
                    }
                }
            }

            // Set style button active
            if (CurrentPage.ToString() == btnPage1.Text)
            {
                btnPage1.Appearance.BackColor = Color.OldLace;
                btnPage2.Appearance.BackColor = Color.White;
                btnPage3.Appearance.BackColor = Color.White;

                btnPage1.Appearance.Font = new Font(btnPage1.Font, FontStyle.Bold);
                btnPage2.Appearance.Font = new Font(btnPage2.Font, FontStyle.Regular);
                btnPage3.Appearance.Font = new Font(btnPage3.Font, FontStyle.Regular);
            }
            else if (CurrentPage.ToString() == btnPage2.Text)
            {
                btnPage1.Appearance.BackColor = Color.White;
                btnPage2.Appearance.BackColor = Color.OldLace;
                btnPage3.Appearance.BackColor = Color.White;

                btnPage1.Appearance.Font = new Font(btnPage1.Font, FontStyle.Regular);
                btnPage2.Appearance.Font = new Font(btnPage2.Font, FontStyle.Bold);
                btnPage3.Appearance.Font = new Font(btnPage3.Font, FontStyle.Regular);
            }
            else if (CurrentPage.ToString() == btnPage3.Text)
            {
                btnPage1.Appearance.BackColor = Color.White;
                btnPage2.Appearance.BackColor = Color.White;
                btnPage3.Appearance.BackColor = Color.OldLace;

                btnPage1.Appearance.Font = new Font(btnPage1.Font, FontStyle.Regular);
                btnPage2.Appearance.Font = new Font(btnPage2.Font, FontStyle.Regular);
                btnPage3.Appearance.Font = new Font(btnPage3.Font, FontStyle.Bold);
            }
        }

        public void HideNextToPage()
        {
            txtPage.Visible = false;
        }

        public void ShowNextToPage()
        {
            txtPage.Visible = true;
        }

        private void cbNumberResultView_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem != null)
            {
                MaxResultCount = (int)cb.SelectedValue;
                CurrentPage = 1;
                PageChanged?.Invoke(this, e);
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
            }
            PageChanged?.Invoke(this, e);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
            }
            PageChanged?.Invoke(this, e);
        }

        private void bntFirst_Click(object sender, EventArgs e)
        {
            CurrentPage = 1;
            PageChanged?.Invoke(this, e);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            CurrentPage = TotalPages;
            PageChanged?.Invoke(this, e);
        }

        private void btnPage_Click(object sender, EventArgs e)
        {
            var btn = sender as DevExpress.XtraEditors.SimpleButton;
            if (btn != null && int.TryParse(btn.Text, out int page))
            {
                CurrentPage = page;
                PageChanged?.Invoke(this, e);
            }
        }

        private void txtPage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && int.TryParse(txtPage.Text, out int page))
            {
                if (page > 0 && page <= TotalPages)
                {
                    CurrentPage = page;
                    PageChanged?.Invoke(this, e);
                }
            }
            else if (e.KeyCode == Keys.Enter && string.IsNullOrEmpty(txtPage.Text.Trim()))
            {
                CurrentPage = 1;
                PageChanged?.Invoke(this, e);
            }
        }

        public void SetCurrentPage(int currentPage)
        {
            CurrentPage = currentPage;
        }
    }
}
