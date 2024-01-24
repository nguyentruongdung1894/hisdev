using System.Reflection;
using System.Resources;

namespace NencerHis.Extensions
{
    public static class LocalExt
    {
        private static ResourceManager rm = new ResourceManager("NencerHis.Properties.NencerResource", Assembly.GetExecutingAssembly());
        public static string Text(string? key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return "";
            }
            return rm.GetString(key) ?? key;
        }
    }
}
