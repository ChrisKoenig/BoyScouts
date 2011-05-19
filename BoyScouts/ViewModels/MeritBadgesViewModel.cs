using System.Collections.ObjectModel;
using System.Threading;
using System.Xml.Linq;
using BoyScouts.Messages;
using BoyScouts.Models;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

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
                ThreadPool.QueueUserWorkItem((cb) =>
                {
                    // Code runs "for real": Connect to service, etc...
                    var doc = XDocument.Load("Data/MeritBadges.xml", LoadOptions.PreserveWhitespace);
                    foreach (var item in doc.Element("MeritBadges").Elements("MeritBadge"))
                    {
                        var mb = new MeritBadge()
                        {
                            Name = item.Element("Title").Value,
                            ImageUrl = item.Element("ImageUrl").Value,
                            IsEagleRequired = bool.Parse(item.Element("IsEagleRequired").Value),
                            HandbookUrl = item.Element("HandbookUrl").Value,
                        };
                        this.MeritBadges.Add(mb);
                    }
                    this.MeritBadgesByFirstLetter = new MeritBadgesByFirstLetter(this.MeritBadges);
                });
            }
        }

        #region MeritBadgesByFirstLetter

        private MeritBadgesByFirstLetter _mbbfl = null;

        [JsonIgnore]
        public MeritBadgesByFirstLetter MeritBadgesByFirstLetter
        {
            get
            {
                return _mbbfl;
            }

            set
            {
                if (_mbbfl == value)
                {
                    return;
                }

                _mbbfl = value;
                RaisePropertyChanged(() => this.MeritBadgesByFirstLetter);
            }
        }

        #endregion MeritBadgesByFirstLetter

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

                _selectedMeritBadge = value;
                RaisePropertyChanged(() => this.SelectedMeritBadge);
                MessengerInstance.Send<MeritBadgeSelectedMessage>(new MeritBadgeSelectedMessage(value));
            }
        }

        #endregion SelectedMeritBadge
    }
}