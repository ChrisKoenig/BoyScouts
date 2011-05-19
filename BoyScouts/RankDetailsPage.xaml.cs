using System;
using System.Windows;
using System.Windows.Controls;
using BoyScouts.Messages;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace BoyScouts
{
    public partial class RankDetailsPage : PhoneApplicationPage
    {
        public RankDetailsPage()
        {
            InitializeComponent();
        }

        private void RequirementsButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
                return;

            string url = button.Tag.ToString();
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                var task = new WebBrowserTask { URL = url };
                task.Show();
            }
        }

        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            if (Orientation == PageOrientation.Landscape ||
                Orientation == PageOrientation.LandscapeLeft ||
                Orientation == PageOrientation.LandscapeRight)
            {
                //TODO: Replace with a storyboard
                LandscapeLayout.Visibility = Visibility.Visible;
                PortraitLayout.Visibility = Visibility.Collapsed;
            }
            else
            {
                //TODO: Replace with a storyboard
                PortraitLayout.Visibility = Visibility.Visible;
                LandscapeLayout.Visibility = Visibility.Collapsed;
            }
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            Messenger.Default.Send<RankDetailsPageFromMessage>(new RankDetailsPageFromMessage());
            base.OnNavigatedFrom(e);
        }
    }
}