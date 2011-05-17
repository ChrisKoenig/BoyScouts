using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using BoyScouts.Models;
using GalaSoft.MvvmLight;

namespace BoyScouts.ViewModels
{
    public class ContentsViewModel : ViewModelBase
    {
        public ContentsViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real": Connect to service, etc...
                var doc = XDocument.Load("Data/Contents.xml");
                foreach (var item in doc.Element("Contents").Elements("Page"))
                {
                    var c = new Content()
                    {
                        Title = item.Attribute("Title").Value,
                        PageIndex = Int32.Parse(item.Attribute("PageIndex").Value),
                        ImagePath = item.Attribute("ImagePath").Value,
                    };
                    this.Contents.Add(c);
                }
            }
        }

        private ObservableCollection<Content> _contents = new ObservableCollection<Content>();

        public ObservableCollection<Content> Contents
        {
            get
            {
                return _contents;
            }

            set
            {
                if (_contents == value)
                {
                    return;
                }

                var oldValue = _contents;
                _contents = value;
                RaisePropertyChanged(() => this.Contents);
            }
        }
    }
}