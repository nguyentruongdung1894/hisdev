using log4net;
using System.IO;

namespace NencerHis.Helpers
{
    public class LogHelper
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LogHelper));
        static LogHelper()
        {
            var path = Directory.GetCurrentDirectory() + "\\log4net.config";
            var fileInfo = new FileInfo(path);
            log4net.Config.XmlConfigurator.Configure(fileInfo);
        }

        public static void Debug(string message)
        {
            if (log.IsDebugEnabled)
            {
                log.Debug(message);
            }
        }

        public static void Info(string message)
        {
            if (log.IsInfoEnabled)
            {
                log.Info(message);
            }
        }

        public static void Warning(string message)
        {
            log.Warn(message);
        }

        public static void Error(string message)
        {
            log.Error(message);
        }

        public static void Exception(string message, Exception ex)
        {
            log.Error(message, ex);
        }
    }
}
