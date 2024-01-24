using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NencerHis.Shared.UserControls
{
    public partial class RowItem : UserControl
    {
        public delegate void SelectItemEventHandler(object sender, EventArgs e);
        public event SelectItemEventHandler? SelectItem;
        private bool _isSelected = false;

        public RowItem()
        {
            InitializeComponent();
            InitEventForAllControls(this.Controls);
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                //set giá trị cho _isSelected vs thay màu nền tương ứng
                _isSelected = value;
                if (value == false)
                {
                    NonActive();
                }
                else
                {
                    Active();
                }
            }
        }

        private void Active()
        {
            BackColor = Color.AntiqueWhite;
        }

        private void NonActive()
        {
            BackColor = Color.White;
        }

        public void LoadData(string info)
        {
            labelInfo.Text = info;
        }

        public void InitEventForAllControls(ControlCollection controls)
        {
            foreach (Control item in controls)
            {
                item.Click += Item_Click;

                if (item.Controls.Count > 0)
                {
                    InitEventForAllControls(item.Controls);
                }
            }
        }

        public void Item_Click(object? sender, EventArgs e)
        {
            SelectItem?.Invoke(this, e);
            IsSelected = true;
        }

        private void RowItem_MouseClick(object sender, MouseEventArgs e)
        {
            SelectItem?.Invoke(this, e);
            IsSelected = true;
        }
    }
}
