using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace BoyScouts
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void ContentButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string tag = button.Tag.ToString();
            int pageIndex = Int32.Parse(tag);
            var targetItem = LayoutRoot.Items[pageIndex] as PanoramaItem;
            LayoutRoot.DefaultItem = targetItem;
        }

        private void HandbookButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void VisualSearchButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ShowHandbook(string url)
        {
            if (url.Length > 0)
            {
                WebBrowserTask task = new WebBrowserTask();
                task.URL = url;
                task.Show();
            }
        }
    }
}