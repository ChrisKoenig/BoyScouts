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

        public ContentsViewModel ContentsViewModel
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
                RaisePropertyChanged(() => this.ContentsViewModel);
            }
        }

        #endregion ContentsViewModel

        #region ScoutLawViewModel

        private ScoutLawViewModel _scoutLaw = new ScoutLawViewModel();

        public ScoutLawViewModel ScoutLawViewModel
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
                RaisePropertyChanged(() => this.ScoutLawViewModel);
            }
        }

        #endregion ScoutLawViewModel

        #region MeritBadgesViewModel

        private MeritBadgesViewModel _meritBadges = new MeritBadgesViewModel();

        public MeritBadgesViewModel MeritBadgesViewModel
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
                RaisePropertyChanged(() => this.MeritBadgesViewModel);
            }
        }

        #endregion MeritBadgesViewModel

        #region ScoutRanksViewModel

        private ScoutRanksViewModel _scoutRanksViewModel = new ScoutRanksViewModel();

        public ScoutRanksViewModel ScoutRanksViewModel
        {
            get
            {
                return _scoutRanksViewModel;
            }

            set
            {
                if (_scoutRanksViewModel == value)
                {
                    return;
                }

                var oldValue = _scoutRanksViewModel;
                _scoutRanksViewModel = value;
                RaisePropertyChanged(() => this.ScoutRanksViewModel);
            }
        }

        #endregion ScoutRanksViewModel

        #region LinksViewModel

        private LinksViewModel _linksViewModel = new LinksViewModel();

        public LinksViewModel LinksViewModel
        {
            get
            {
                return _linksViewModel;
            }

            set
            {
                if (_linksViewModel == value)
                {
                    return;
                }

                var oldValue = _linksViewModel;
                _linksViewModel = value;
                RaisePropertyChanged(() => this.LinksViewModel);
            }
        }

        #endregion LinksViewModel
    }
}