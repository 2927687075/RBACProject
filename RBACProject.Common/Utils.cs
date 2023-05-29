using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RBACProject.Common
{
    public class Utils
    {
        /// <summary>
        /// 获取本机IPv4地址
        /// 
        ///     Dns.GetHostName()--获取本机域名
        ///     Dns.GetHostEntry(Dns.GetHostName()).AddressList --获取本机的IP地址（包括ipv4和ipv6）
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetIp()
        {
            string sAddressIP = string.Empty;

            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    sAddressIP = _IPAddress.ToString();
                    break;
                }

            }

            return sAddressIP;
        }

    }
}
