using NencerHis.Helpers;

namespace Nencer.Extensions
{
    public static class ExceptionHandler
    {
        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            LogHelper.Exception(e.Exception.Message, e.Exception);
            MessageBox.Show(e.Exception.Message, "Thread Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogHelper.Exception(((Exception) e.ExceptionObject).Message, (Exception) e.ExceptionObject);
            MessageBox.Show(((Exception)e.ExceptionObject).Message, "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
