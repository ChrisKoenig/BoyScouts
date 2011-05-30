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
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (LayoutRoot.SelectedIndex != 0)
            {
                var targetItem = LayoutRoot.Items[0] as PanoramaItem;
                LayoutRoot.DefaultItem = targetItem;
                e.Cancel = true;
            }
            else
            {
                base.OnBackKeyPress(e);
            }
        }

        private void ContentButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string tag = button.Tag.ToString();
            int pageIndex = Int32.Parse(tag);
            var targetItem = LayoutRoot.Items[pageIndex] as PanoramaItem;
            LayoutRoot.DefaultItem = targetItem;
        }
    }
}