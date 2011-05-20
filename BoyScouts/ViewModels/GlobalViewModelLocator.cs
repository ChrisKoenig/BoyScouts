/*
  In App.xaml:
  <Application.Resources>
      <vm:GlobalViewModelLocator xmlns:vm="clr-namespace:BoyScouts.ViewModels"
                                   x:Key="Locator" />
  </Application.Resources>

  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using System;
using System.IO;
using System.IO.IsolatedStorage;
using BoyScouts.Messages;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;

namespace BoyScouts.ViewModels
{
    public class GlobalViewModelLocator
    {
        #region Infrastructure

        public GlobalViewModelLocator()
        {
            CreateMainViewModel();
            CreateRankDetailsViewModel();
            CreateMeritBadgeDetailsViewModel();
        }

        public static void Cleanup()
        {
            ClearMeritBadgeFaqViewModel();
            ClearMeritBadgeDetailsViewModel();
            ClearRankDetailsViewModel();
            ClearMainViewModel();
        }

        #endregion Infrastructure

        #region MainViewModel

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

        #endregion MainViewModel

        #region RankDetailsViewModel

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

        #endregion RankDetailsViewModel

        #region MeritBadgeDetailsViewModel

        private static MeritBadgeDetailsViewModel _meritBadgeDetails;

        /// <summary>
        /// Gets the MeritBadgeDetailsViewModel property.
        /// </summary>
        public static MeritBadgeDetailsViewModel MeritBadgeDetailsViewModelStatic
        {
            get
            {
                if (_meritBadgeDetails == null)
                {
                    CreateMeritBadgeDetailsViewModel();
                }

                return _meritBadgeDetails;
            }
        }

        /// <summary>
        /// Gets the MeritBadgeDetailsViewModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MeritBadgeDetailsViewModel MeritBadgeDetailsViewModel
        {
            get
            {
                return MeritBadgeDetailsViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the MeritBadgeDetailsViewModel property.
        /// </summary>
        public static void ClearMeritBadgeDetailsViewModel()
        {
            _meritBadgeDetails.Cleanup();
            _meritBadgeDetails = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the MeritBadgeDetailsViewModel property.
        /// </summary>
        public static void CreateMeritBadgeDetailsViewModel()
        {
            if (_meritBadgeDetails == null)
            {
                _meritBadgeDetails = new MeritBadgeDetailsViewModel();
            }
        }

        #endregion MeritBadgeDetailsViewModel

        private static MeritBadgeFaqViewModel _meritBadgeFaqViewModel;

        /// <summary>
        /// Gets the MeritBadgeFaqViewModel property.
        /// </summary>
        public static MeritBadgeFaqViewModel MeritBadgeFaqViewModelStatic
        {
            get
            {
                if (_meritBadgeFaqViewModel == null)
                {
                    CreateMeritBadgeFaqViewModel();
                }

                return _meritBadgeFaqViewModel;
            }
        }

        /// <summary>
        /// Gets the MeritBadgeFaqViewModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MeritBadgeFaqViewModel MeritBadgeFaqViewModel
        {
            get
            {
                return MeritBadgeFaqViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the MeritBadgeFaqViewModel property.
        /// </summary>
        public static void ClearMeritBadgeFaqViewModel()
        {
            _meritBadgeFaqViewModel.Cleanup();
            _meritBadgeFaqViewModel = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the MeritBadgeFaqViewModel property.
        /// </summary>
        public static void CreateMeritBadgeFaqViewModel()
        {
            if (_meritBadgeFaqViewModel == null)
            {
                _meritBadgeFaqViewModel = new MeritBadgeFaqViewModel();
            }
        }

        #region Tombstoning Support

        public void SaveState()
        {
            SaveObject<MainViewModel>("MainViewModel", this.MainViewModel);
            SaveObject<RankDetailsViewModel>("RankDetailsViewModel", this.RankDetailsViewModel);
            SaveObject<MeritBadgeDetailsViewModel>("MeritBadgeDetailsViewModel", this.MeritBadgeDetailsViewModel);
        }

        private void SaveObject<T>(string Key, T ViewModel)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            using (var stream = new IsolatedStorageFileStream(Key + ".json", FileMode.Create, FileAccess.Write, store))
            using (StreamWriter sw = new StreamWriter(stream))
            using (JsonWriter writer = new JsonTextWriter(sw))
                serializer.Serialize(writer, ViewModel);
        }

        public void LoadState()
        {
            LoadObject<MainViewModel>("MainViewModel");
            LoadObject<RankDetailsViewModel>("RankDetailsViewModel");
            LoadObject<MeritBadgeDetailsViewModel>("MeritBadgeDetailsViewModel");
        }

        private T LoadObject<T>(string Key)
        {
            JsonSerializer serializer = new JsonSerializer();
            string value = "";
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            using (var stream = new IsolatedStorageFileStream(Key + ".json", FileMode.Open, FileAccess.Read, store))
            using (var reader = new StreamReader(stream))
                value = reader.ReadToEnd();

            return JsonConvert.DeserializeObject<T>(value);
        }

        #endregion Tombstoning Support
    }
}