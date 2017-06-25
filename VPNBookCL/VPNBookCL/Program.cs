using System;
using System.Net;

namespace VPNBookCL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(GetPass());
        }

        public static string GetPass()
        {
            string htmlCode;
            using (WebClient client = new WebClient())
            {
                htmlCode = client.DownloadString("https://www.vpnbook.com/#pptpvpn");
            }
            return getBetween(htmlCode, "Password: ", "</");

        }
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
    }
}
