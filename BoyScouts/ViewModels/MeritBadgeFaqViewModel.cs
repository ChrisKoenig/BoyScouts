using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using BoyScouts.Model;
using GalaSoft.MvvmLight;

namespace BoyScouts.ViewModels
{
    public class MeritBadgeFaqViewModel : ViewModelBase
    {
        public MeritBadgeFaqViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real": Connect to service, etc...
                var doc = XDocument.Load("Data/MeritBadgeFAQ.xml");
                foreach (var item in doc.Element("MeritBadgeFaq").Elements("Faq"))
                {
                    var f = new FAQ()
                    {
                        Question = item.Element("Question").Value,
                        Answers = new System.Collections.Generic.List<Answer>(),
                    };
                    foreach (var answer in item.Element("Answers").Elements("Answer"))
                    {
                        var citation = answer.Element("Citation");
                        var a = new Answer()
                        {
                            Description = answer.Element("Description").Value,
                            Citation = new Citation()
                            {
                                Text = citation.Attribute("Text").Value,
                                Link = citation.Attribute("Link").Value,
                            },
                        };
                        f.Answers.Add(a);
                    }
                    this.FAQList.Add(f);
                }
            }
        }

        private ObservableCollection<FAQ> _faqList = new ObservableCollection<FAQ>();

        public ObservableCollection<FAQ> FAQList
        {
            get
            {
                return _faqList;
            }

            set
            {
                if (_faqList == value)
                {
                    return;
                }

                var oldValue = _faqList;
                _faqList = value;
                RaisePropertyChanged(() => this.FAQList);
            }
        }
    }
}