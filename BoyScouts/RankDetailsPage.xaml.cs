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
            string url = RequirementsButton.Tag.ToString();
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