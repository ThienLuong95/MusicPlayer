using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using MusicPlayer.Core.Helpers;
using MusicPlayer.Core.Services;
using MusicPlayer.Helpers;
using MusicPlayer.Services;

using Windows.ApplicationModel;
using Windows.Globalization;
using Windows.UI.Xaml;

namespace MusicPlayer.ViewModels
{
    // TODO WTS: Add other settings as necessary. For help see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/pages/settings.md
    public class SettingsViewModel : ViewModelBase
    {
        private UserDataService UserDataService => Singleton<UserDataService>.Instance;

        private IdentityService IdentityService => Singleton<IdentityService>.Instance;

        private ElementTheme _elementTheme = ThemeSelectorService.Theme;

        public List<Language> Langs => LanguageSeletorService.languages;
        private Language _lang;
        public Language Lang
        {
            get { return _lang; }
            set
            {
                Set(ref _lang, value);
                LanguageSeletorService.language = value;
                LanguageSeletorService.flowDirection = LanguageSeletorService.GetFlowDirection();
            }
        }

        public async void ChangeLang()
        {
            await LanguageSeletorService.SetRequestedLangAsync();
        }
        public ElementTheme ElementTheme
        {
            get { return _elementTheme; }

            set { Set(ref _elementTheme, value); }
        }

        private string _versionDescription;

        public string VersionDescription
        {
            get { return _versionDescription; }

            set { Set(ref _versionDescription, value); }
        }

        private ICommand _switchThemeCommand;

        public ICommand SwitchThemeCommand
        {
            get
            {
                if (_switchThemeCommand == null)
                {
                    _switchThemeCommand = new RelayCommand<ElementTheme>(
                        async (param) =>
                        {
                            ElementTheme = param;
                            await ThemeSelectorService.SetThemeAsync(param);
                        });
                }

                return _switchThemeCommand;
            }
        }

        private UserViewModel _user;

        private ICommand _logoutCommand;

        public ICommand LogoutCommand => _logoutCommand ?? (_logoutCommand = new RelayCommand(OnLogout));

        public UserViewModel User
        {
            get { return _user; }
            set { Set(ref _user, value); }
        }

        public SettingsViewModel()
        {
            LanguageSeletorService.InitializeAsync();
        }

        public async Task InitializeAsync()
        {
            VersionDescription = GetVersionDescription();
            IdentityService.LoggedOut += OnLoggedOut;
            UserDataService.UserDataUpdated += OnUserDataUpdated;
            User = await UserDataService.GetUserAsync();
        }

        private string GetVersionDescription()
        {
            var appName = "AppDisplayName".GetLocalized();
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;

            return $"{appName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }

        public void UnregisterEvents()
        {
            IdentityService.LoggedOut -= OnLoggedOut;
            UserDataService.UserDataUpdated -= OnUserDataUpdated;
        }

        private void OnUserDataUpdated(object sender, UserViewModel userData)
        {
            User = userData;
        }

        private async void OnLogout()
        {
            await IdentityService.LogoutAsync();
        }

        private void OnLoggedOut(object sender, EventArgs e)
        {
            UnregisterEvents();
        }
    }
}
