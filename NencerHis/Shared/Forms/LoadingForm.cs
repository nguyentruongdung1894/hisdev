using DevExpress.XtraWaitForm;
using NencerHis.Extensions;

namespace NencerHis.Modules.ReportManager.Forms
{
    public partial class LoadingForm : WaitForm
    {
        public LoadingForm()
        {
            InitializeComponent();
            this.progressPanel.AutoHeight = true;

            SetCaption(LocalExt.Text("PlsWait"));
            SetDescription(LocalExt.Text("Loading"));
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }
    }
}