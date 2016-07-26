using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace Useful.Utilities
{


    public static class Network
    {
        public static string IpAddress(string computer)
        {
            if (!string.IsNullOrWhiteSpace(computer))
            {
                try
                {
                    IPAddress ip = Dns.GetHostAddresses(computer).FirstOrDefault(i => i.AddressFamily == AddressFamily.InterNetwork);
                    if (ip != null)
                        return ip.ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception("Invalid Computer Name", ex);
                }
            }
            return "127.0.0.1";
        }
        
    }
}
