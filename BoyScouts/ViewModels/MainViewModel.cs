using GalaSoft.MvvmLight;

namespace BoyScouts.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
        }

        #region ContentsViewModel

        private ContentsViewModel _contents = new ContentsViewModel();

        public ContentsViewModel Contents
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

        #endregion ContentsViewModel

        #region ScoutLawViewModel

        private ScoutLawViewModel _scoutLaw = new ScoutLawViewModel();

        public ScoutLawViewModel ScoutLaw
        {
            get
            {
                return _scoutLaw;
            }

            set
            {
                if (_scoutLaw == value)
                {
                    return;
                }

                var oldValue = _scoutLaw;
                _scoutLaw = value;
                RaisePropertyChanged(() => this.ScoutLaw);
            }
        }

        #endregion ScoutLawViewModel
    }
}