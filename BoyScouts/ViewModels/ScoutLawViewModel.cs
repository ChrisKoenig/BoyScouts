using System.Collections.ObjectModel;
using System.Xml.Linq;
using BoyScouts.Models;
using GalaSoft.MvvmLight;

namespace BoyScouts.ViewModels
{
    public class ScoutLawViewModel : ViewModelBase
    {
        public ScoutLawViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real": Connect to service, etc...
                var doc = XDocument.Load("Data/ScoutLaw.xml");
                foreach (var item in doc.Element("ScoutLaw").Elements("Law"))
                {
                    var l = new Law()
                    {
                        Title = item.Element("Title").Value,
                        Description = item.Element("Description").Value,
                    };
                    this.Laws.Add(l);
                }
            }
        }

        private ObservableCollection<Law> _laws = new ObservableCollection<Law>();

        public ObservableCollection<Law> Laws
        {
            get
            {
                return _laws;
            }

            set
            {
                if (_laws == value)
                {
                    return;
                }

                _laws = value;
                RaisePropertyChanged(() => this.Laws);
            }
        }
    }
}