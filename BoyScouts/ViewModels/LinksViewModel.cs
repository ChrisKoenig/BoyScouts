using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;
using BoyScouts.Models;
using GalaSoft.MvvmLight;

namespace BoyScouts.ViewModels
{
    public class LinksViewModel : ViewModelBase
    {
        public LinksViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real": Connect to service, etc...
                var doc = XDocument.Load("Data/Links.xml");
                foreach (var item in doc.Element("Links").Elements("Link"))
                {
                    var c = new Link()
                    {
                        Title = item.Attribute("Title").Value,
                        Url = item.Attribute("Url").Value,
                    };
                    this.Links.Add(c);
                }
            }
        }

        private ObservableCollection<Link> _links = new ObservableCollection<Link>();

        public ObservableCollection<Link> Links
        {
            get
            {
                return _links;
            }

            set
            {
                if (_links == value)
                {
                    return;
                }

                _links = value;
                RaisePropertyChanged(() => this.Links);
            }
        }
    }
}