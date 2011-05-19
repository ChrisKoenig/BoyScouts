/*
  In App.xaml:
  <Application.Resources>
      <vm:GlobalViewModelLocator xmlns:vm="clr-namespace:BoyScouts.ViewModels"
                                   x:Key="Locator" />
  </Application.Resources>

  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using BoyScouts.Messages;
using GalaSoft.MvvmLight.Messaging;

namespace BoyScouts.ViewModels
{
    public class GlobalViewModelLocator
    {
        public GlobalViewModelLocator()
        {
            Messenger.Default.Register<RankDetailsPageFromMessage>(this, (m) => RankDetailsViewModel.Cleanup());
            CreateMainViewModel();
            CreateRankDetailsViewModel();
        }

        private static MainViewModel _main;

        /// <summary>
        /// Gets the MainViewModel property.
        /// </summary>
        public static MainViewModel MainViewModelStatic
        {
            get
            {
                if (_main == null)
                {
                    CreateMainViewModel();
                }

                return _main;
            }
        }

        /// <summary>
        /// Gets the MainViewModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel MainViewModel
        {
            get
            {
                return MainViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the MainViewModel property.
        /// </summary>
        public static void ClearMainViewModel()
        {
            _main.Cleanup();
            _main = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the MainViewModel property.
        /// </summary>
        public static void CreateMainViewModel()
        {
            if (_main == null)
            {
                _main = new MainViewModel();
            }
        }

        private static RankDetailsViewModel _rankDetails;

        /// <summary>
        /// Gets the RankDetailsViewModel property.
        /// </summary>
        public static RankDetailsViewModel RankDetailsViewModelStatic
        {
            get
            {
                if (_rankDetails == null)
                {
                    CreateRankDetailsViewModel();
                }

                return _rankDetails;
            }
        }

        /// <summary>
        /// Gets the RankDetailsViewModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public RankDetailsViewModel RankDetailsViewModel
        {
            get
            {
                return RankDetailsViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the RankDetailsViewModel property.
        /// </summary>
        public static void ClearRankDetailsViewModel()
        {
            _rankDetails.Cleanup();
            _rankDetails = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the RankDetailsViewModel property.
        /// </summary>
        public static void CreateRankDetailsViewModel()
        {
            if (_rankDetails == null)
            {
                _rankDetails = new RankDetailsViewModel();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            ClearRankDetailsViewModel();
            ClearMainViewModel();
        }
    }
}