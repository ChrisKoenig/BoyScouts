using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

        private void VisualSearchButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}