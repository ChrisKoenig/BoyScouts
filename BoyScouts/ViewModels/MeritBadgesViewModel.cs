using System.Collections.ObjectModel;
using BoyScouts.Messages;
using BoyScouts.Models;
using GalaSoft.MvvmLight;

namespace BoyScouts.ViewModels
{
    public class MeritBadgesViewModel : ViewModelBase
    {
        public MeritBadgesViewModel()
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

        #region MeritBadges property

        private ObservableCollection<MeritBadge> _meritBadges = new ObservableCollection<MeritBadge>();

        public ObservableCollection<MeritBadge> MeritBadges
        {
            get
            {
                return _meritBadges;
            }

            set
            {
                if (_meritBadges == value)
                {
                    return;
                }

                var oldValue = _meritBadges;
                _meritBadges = value;
                RaisePropertyChanged(() => this.MeritBadges);
            }
        }

        #endregion MeritBadges property

        #region SelectedMeritBadge

        private MeritBadge _selectedMeritBadge = null;

        public MeritBadge SelectedMeritBadge
        {
            get
            {
                return _selectedMeritBadge;
            }

            set
            {
                if (_selectedMeritBadge == value)
                {
                    return;
                }

                var oldValue = _selectedMeritBadge;
                _selectedMeritBadge = value;
                RaisePropertyChanged(() => this.SelectedMeritBadge);
                MessengerInstance.Send<MeritBadgeSelectedMessage>(new MeritBadgeSelectedMessage(value));
            }
        }

        #endregion SelectedMeritBadge
    }
}