using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Tasks;

namespace BoyScouts.Helpers
{
    public static class WebBrowserHelper
    {
        public static void LaunchWebBrowserTask(string url)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                var task = new WebBrowserTask { URL = url };
                task.Show();
            }
        }
    }
}