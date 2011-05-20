using System;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using BoyScouts.Messages;
using BoyScouts.Models;
using GalaSoft.MvvmLight;

namespace BoyScouts.ViewModels
{
    public class ScoutRanksViewModel : ViewModelBase
    {
        public ScoutRanksViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real": Connect to service, etc...
                var doc = XDocument.Load("Data/ScoutRanks.xml");
                foreach (var item in doc.Element("ScoutRanks").Elements("Rank"))
                {
                    var r = new Rank()
                    {
                        Name = item.Element("Name").Value,
                        Requirements = item.Element("Requirements").Value,
                        ImageUrl = item.Element("ImageUrl").Value,
                        Description = item.Element("Description").Value,
                        SequenceNumber = Int32.Parse(item.Element("SequenceNumber").Value),
                    };
                    this.Ranks.Add(r);
                }
            }
        }

        #region Ranks

        private ObservableCollection<Rank> _ranks = new ObservableCollection<Rank>();

        public ObservableCollection<Rank> Ranks
        {
            get
            {
                return _ranks;
            }

            set
            {
                if (_ranks == value)
                {
                    return;
                }

                _ranks = value;
                RaisePropertyChanged(() => this.Ranks);
            }
        }

        #endregion Ranks

        #region SelectedRank

        private Rank _selectedRank = null;

        public Rank SelectedRank
        {
            get
            {
                return _selectedRank;
            }

            set
            {
                if (_selectedRank == value)
                {
                    return;
                }

                _selectedRank = value;
                MessengerInstance.Send<RankSelectedMessage>(new RankSelectedMessage(value));
                RaisePropertyChanged(() => this.SelectedRank);
            }
        }

        #endregion SelectedRank
    }
}