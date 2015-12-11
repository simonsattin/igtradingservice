using dto.endpoint.workingorders.create.v2;
using IGPublicPcl;
using IGTrading.Data.SqlServer;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IGTradingService
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);

        static void Main(string[] args)
        {
            Process p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3

            var streamer = new Streamer();
            streamer.Run();
        }
    }
}
