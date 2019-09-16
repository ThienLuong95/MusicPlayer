using System;

using GalaSoft.MvvmLight.Ioc;

using MusicPlayer.Services;
using MusicPlayer.Views;

namespace MusicPlayer.ViewModels
{
    [Windows.UI.Xaml.Data.Bindable]
    public class ViewModelLocator
    {
        private static ViewModelLocator _current;

        public static ViewModelLocator Current => _current ?? (_current = new ViewModelLocator());

        private ViewModelLocator()
        {
            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();
            Register<MainViewModel, MainPage>();
            Register<MediaPlayerViewModel, MediaPlayerPage>();
            Register<ChartViewModel, ChartPage>();
            Register<ImageGalleryViewModel, ImageGalleryPage>();
            Register<ImageGalleryDetailViewModel, ImageGalleryDetailPage>();
            Register<SettingsViewModel, SettingsPage>();
            Register<SchemeActivationSampleViewModel, SchemeActivationSamplePage>();
            Register<LogInViewModel, LogInPage>();
        }

        public LogInViewModel LogInViewModel => SimpleIoc.Default.GetInstance<LogInViewModel>();

        public SchemeActivationSampleViewModel SchemeActivationSampleViewModel => SimpleIoc.Default.GetInstance<SchemeActivationSampleViewModel>();

        public SettingsViewModel SettingsViewModel => SimpleIoc.Default.GetInstance<SettingsViewModel>();

        public ImageGalleryDetailViewModel ImageGalleryDetailViewModel => SimpleIoc.Default.GetInstance<ImageGalleryDetailViewModel>();

        public ImageGalleryViewModel ImageGalleryViewModel => SimpleIoc.Default.GetInstance<ImageGalleryViewModel>();

        public ChartViewModel ChartViewModel => SimpleIoc.Default.GetInstance<ChartViewModel>();

        // A Guid is generated as a unique key for each instance as reusing the same VM instance in multiple MediaPlayerElement instances can cause playback errors
        public MediaPlayerViewModel MediaPlayerViewModel => SimpleIoc.Default.GetInstance<MediaPlayerViewModel>(Guid.NewGuid().ToString());

        public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();

        public ShellViewModel ShellViewModel => SimpleIoc.Default.GetInstance<ShellViewModel>();

        public NavigationServiceEx NavigationService => SimpleIoc.Default.GetInstance<NavigationServiceEx>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
