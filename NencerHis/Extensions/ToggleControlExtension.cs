namespace NencerHis.Extensions
{
    public class ToggleControlExtension
    {
        private System.Windows.Forms.Timer _collapseTimer = new System.Windows.Forms.Timer();
        private int _targetHeight;
        private int _stepSize = 5;
        private bool isExpanding = false;
        private Control _control;

        public ToggleControlExtension(Control control, int targetHeight, int stepSize = 5, int ticks = 5) 
        {
            // Thiết lập timer
            _collapseTimer.Interval = ticks; // Thời gian giữa mỗi Tick (ms)
            _collapseTimer.Tick += CollapseTimer_Tick;
            _control = control;
            _stepSize = stepSize;
            _targetHeight = targetHeight;
        }

        private void CollapseTimer_Tick(object? sender, EventArgs e)
        {
            if (!isExpanding)
            {
                // Thu gọn panel
                if (_control.Height > 0)
                {
                    _control.Height -= _stepSize;
                }
                else
                {
                    _collapseTimer.Stop();
                    _control.Visible = false;
                }
            }
            else
            {
                // Mở rộng panel
                _control.Visible = true;
                if (_control.Height + _stepSize >= _targetHeight)
                {
                    _control.Height = _targetHeight;
                    _collapseTimer.Stop();
                }
                else
                {
                    _control.Height += _stepSize;
                }
            }
        }

        public void ShowPanel()
        {
            if (!_control.Visible || !isExpanding)
            {
                if (!_control.Visible)
                {
                    _control.Height = 0;
                }

                _collapseTimer.Stop();
                isExpanding = true;
                _collapseTimer.Start();
            }
        }

        public void HidePanel()
        {
            if ((_control.Visible && isExpanding) || isExpanding)
            {
                _collapseTimer.Stop();
                isExpanding = false;
                _collapseTimer.Start();
            }
        }

        public void TogglePanelCollapse()
        {
            _collapseTimer.Stop();
            if (_control.Visible)
            {
                // Đang hiển thị -> chuyển sang thu gọn
                isExpanding = false;
            }
            else
            {
                // Đang ẩn -> chuyển sang mở rộng
                _control.Height = 0;
                isExpanding = true;
            }
            _collapseTimer.Start();
        }
    }
}
