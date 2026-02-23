using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DetectZCamTest
{

    public class MDNSNative
    {
        [DllImport("DetectZCam.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int mdns_discover_ips(IntPtr outIps, int maxIps);

        [DllImport("DetectZCam.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mdns_free_ips(IntPtr outIps, int count);

        public static List<string> DiscoverIPs()
        {
            const int maxIps = 10;
            IntPtr outIps = Marshal.AllocHGlobal(maxIps * IntPtr.Size);
            try
            {
                int count = mdns_discover_ips(outIps, maxIps);
                List<string> ips = new List<string>();
                for (int i = 0; i < count; i++)
                {
                    IntPtr ipPtr = Marshal.ReadIntPtr(outIps, i * IntPtr.Size);
                    string ip = Marshal.PtrToStringAnsi(ipPtr);
                    Console.WriteLine(ip);
                    ips.Add(ip);
                }
                mdns_free_ips(outIps, count);
                return ips;
            }
            finally
            {
                Marshal.FreeHGlobal(outIps);
            }
        }
    }
}
