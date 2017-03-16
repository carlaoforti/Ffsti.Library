using System.Runtime.InteropServices;
using System.Security;

namespace Ffsti.Library.Base.Helpers
{
    /// <summary>
    /// Methods to handle not and internet
    /// </summary>
    public class NetHelper
    {
        /// <summary>
        /// Verifies internet connection
        /// </summary>
        public static bool IsConnected()
        {
            int flags;
            
            return SafeNativeMethods.InternetGetConnectedState(out flags, 0);
        }
    }

    [SuppressUnmanagedCodeSecurity]
    internal static class SafeNativeMethods
    {
        [DllImport("wininet.dll", SetLastError = true)]
        internal static extern bool InternetGetConnectedState(out int lpdwFlags, int dwReserved);
    }
}
