using DevExpress.XtraWaitForm;

namespace NencerHis.Modules.CommonManager
{
    public partial class frmStartApp : WaitForm
    {
        public frmStartApp()
        {
            InitializeComponent();
            this.progressPanel.AutoHeight = true;
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