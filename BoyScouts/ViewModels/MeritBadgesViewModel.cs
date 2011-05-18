using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
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
            }
        }

        //public IEnumerable<GroupingLayer<string, MeritBadge>> MeritBadgeData
        //{
        //    get
        //    {
        //        var selected = this.MeritBadges
        //            .GroupBy(mb => mb.Key)
        //            .Select(mb => new GroupingLayer<string, MeritBadge>(mb));
        //        return selected;
        //    }
        //}

        #region MeritBadgesByFirstLetter

        private MeritBadgesByFirstLetter _mbbfl = null;

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

                var oldValue = _mbbfl;
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

    public class GroupingLayer<TKey, TElement> : IGrouping<TKey, TElement>
    {
        private readonly IGrouping<TKey, TElement> grouping;

        public GroupingLayer(IGrouping<TKey, TElement> unit)
        {
            grouping = unit;
        }

        public TKey Key
        {
            get { return grouping.Key; }
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            return grouping.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return grouping.GetEnumerator();
        }
    }
}