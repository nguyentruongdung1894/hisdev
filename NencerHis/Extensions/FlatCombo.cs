using System.ComponentModel;

namespace NencerHis.Extensions
{
    public class FlatCombo : ComboBox
    {
        private const int WM_PAINT = 0xF;
        private int buttonWidth = SystemInformation.HorizontalScrollBarArrowWidth;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT)
            {
                using (var g = Graphics.FromHwnd(Handle))
                {
                    using (var p = new Pen(this.BorderColor, 1))
                    {
                        g.DrawRectangle(p, 1, 1, Width - buttonWidth - 3, Height - 3);
                    }
                }
            }
        }

        public FlatCombo()
        {
            BorderColor = Color.DimGray;
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "DimGray")]
        public Color BorderColor { get; set; }
    }
}