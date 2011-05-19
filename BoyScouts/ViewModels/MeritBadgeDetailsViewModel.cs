using System.Windows.Media;
using BoyScouts.Messages;
using BoyScouts.Models;
using GalaSoft.MvvmLight;

namespace BoyScouts.ViewModels
{
    public class MeritBadgeDetailsViewModel : ViewModelBase
    {
        public MeritBadgeDetailsViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real": Connect to service, etc...
            }
        }

        public SolidColorBrush MeritBadgeBorderColor
        {
            get
            {
                if (MeritBadgeObject == null)
                    return null;
                return MeritBadgeObject.IsEagleRequired
                    ? (SolidColorBrush)App.Current.Resources["BoyScoutRed"]
                    : (SolidColorBrush)App.Current.Resources["BoyScoutBlue"];
            }
        }

        #region MeritBadgeObject

        private MeritBadge _meritBadgeObject = null;

        public MeritBadge MeritBadgeObject
        {
            get
            {
                return _meritBadgeObject;
            }

            set
            {
                if (_meritBadgeObject == value)
                {
                    return;
                }

                _meritBadgeObject = value;
                RaisePropertyChanged(() => this.MeritBadgeObject);
            }
        }

        #endregion MeritBadgeObject
    }
}