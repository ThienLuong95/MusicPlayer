using System;

using MusicPlayer.ViewModels;

using Windows.UI.Xaml.Controls;

namespace MusicPlayer.Views
{
    public sealed partial class LogInPage : Page
    {
        private LogInViewModel ViewModel
        {
            get { return ViewModelLocator.Current.LogInViewModel; }
        }

        public LogInPage()
        {
            InitializeComponent();
        }
    }
}
