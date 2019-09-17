using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Globalization;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace MusicPlayer.Services
{
    public static class LanguageSeletorService
    {
        public static Language language;
        public static FlowDirection flowDirection = FlowDirection.LeftToRight;
        public static readonly List<Language> languages = new List<Language>()
        {
            new Language("en-us"),
            new Language("ar-SA"),
        };
        public static void InitializeAsync()
        {
            language = languages[0];
            flowDirection = GetFlowDirection();
        }

        //public static async Task SetThemeAsync(ElementTheme theme)
        //{
        //    Theme = theme;

        //    await SetRequestedThemeAsync();
        //    await SaveThemeInSettingsAsync(Theme);
        //}

        public static async Task SetRequestedLangAsync()
        {
            ApplicationLanguages.PrimaryLanguageOverride = language.LanguageTag;
            foreach (var view in CoreApplication.Views)
            {
                await view.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    if (Window.Current.Content is FrameworkElement frameworkElement)
                    {
                        frameworkElement.Language = language.LanguageTag;
                        frameworkElement.FlowDirection = flowDirection;
                        frameworkElement.UpdateLayout();
                    }
                });
            }
            
        }
        public static FlowDirection GetFlowDirection()
        {

            if (language.LayoutDirection == LanguageLayoutDirection.Rtl
               || language.LayoutDirection == LanguageLayoutDirection.TtbRtl)
            {
               return FlowDirection.RightToLeft;
            }
            return FlowDirection.LeftToRight;
        }

        //private static async Task<ElementTheme> LoadThemeFromSettingsAsync()
        //{
        //    ElementTheme cacheTheme = ElementTheme.Default;
        //    string themeName = await ApplicationData.Current.LocalSettings.ReadAsync<string>(SettingsKey);

        //    if (!string.IsNullOrEmpty(themeName))
        //    {
        //        Enum.TryParse(themeName, out cacheTheme);
        //    }

        //    return cacheTheme;
        //}

        //private static async Task SaveThemeInSettingsAsync(ElementTheme theme)
        //{
        //    await ApplicationData.Current.LocalSettings.SaveAsync(SettingsKey, theme.ToString());
        //}
    }
}
