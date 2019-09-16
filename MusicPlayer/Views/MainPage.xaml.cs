using System;

using MusicPlayer.ViewModels;

using Windows.UI.Xaml.Controls;

namespace MusicPlayer.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel
        {
            get { return ViewModelLocator.Current.MainViewModel; }
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
