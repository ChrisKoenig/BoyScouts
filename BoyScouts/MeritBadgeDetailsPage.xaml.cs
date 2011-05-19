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
using Microsoft.Phone.Controls;

namespace BoyScouts
{
    public partial class MeritBadgeDetailsPage : PhoneApplicationPage
    {
        public MeritBadgeDetailsPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MeritBadgeDetailsPage_Loaded);
        }

        private void MeritBadgeDetailsPage_Loaded(object sender, RoutedEventArgs e)
        {
            ResetOrientation();
        }

        private void ResetOrientation()
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

        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            ResetOrientation();
        }
    }
}