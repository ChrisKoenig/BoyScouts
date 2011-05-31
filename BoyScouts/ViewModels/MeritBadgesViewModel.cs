using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows;
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
                // Code runs "for real": Connect to service, etc...
                ThreadPool.QueueUserWorkItem((cb) =>
                {
                    var doc = XDocument.Load("Data/MeritBadges.xml", LoadOptions.PreserveWhitespace);
                    foreach (var item in doc.Element("MeritBadges").Elements("MeritBadge"))
                    {
                        var mb = new MeritBadge()
                        {
                            Name = item.Element("Title").Value,
                            ImageUrl = item.Element("ImageUrl").Value,
                            Description = item.Element("Description").Value,
                            IsEagleRequired = bool.Parse(item.Element("IsEagleRequired").Value),
                            WorksheetUrl = item.Element("WorksheetUrl").Value,
                        };
                        this.MeritBadges.Add(mb);
                    }
                    SetMeritBadgesByFirstLetter();
                });
            }
        }

        private void SetMeritBadgesByFirstLetter()
        {
            if (ShowEagleOnly)
            {
                MeritBadgesByFirstLetter = from badge in MeritBadges
                                           where badge.IsEagleRequired == true
                                           group badge by badge.Key into b
                                           orderby b.Key
                                           select new Group<MeritBadge>(b.Key, b);
            }
            else
            {
                MeritBadgesByFirstLetter = from badge in MeritBadges
                                           group badge by badge.Key into b
                                           orderby b.Key
                                           select new Group<MeritBadge>(b.Key, b);
            }
        }

        #region ShowEagleOnly property

        private bool _showEagleOnly = false;

        public bool ShowEagleOnly
        {
            get
            {
                return _showEagleOnly;
            }

            set
            {
                if (_showEagleOnly == value)
                {
                    return;
                }

                _showEagleOnly = value;
                RaisePropertyChanged(() => this.ShowEagleOnly);
                SetMeritBadgesByFirstLetter();
            }
        }

        #endregion ShowEagleOnly property

        #region MeritBadgesByFirstLetter

        [JsonIgnore]
        private IEnumerable<Group<MeritBadge>> _mbbfl = null;

        [JsonIgnore]
        public IEnumerable<Group<MeritBadge>> MeritBadgesByFirstLetter
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