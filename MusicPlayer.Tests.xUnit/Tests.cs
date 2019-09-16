using System;

using MusicPlayer.ViewModels;

using Xunit;

namespace MusicPlayer.Tests.XUnit
{
    // TODO WTS: Add appropriate tests
    public class Tests
    {
        [Fact]
        public void TestMethod1()
        {
        }

        // TODO WTS: Add tests for functionality you add to ChartViewModel.
        [Fact]
        public void TestChartViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new ChartViewModel();
            Assert.NotNull(vm);
        }

        // TODO WTS: Add tests for functionality you add to ImageGalleryViewModel.
        [Fact]
        public void TestImageGalleryViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new ImageGalleryViewModel();
            Assert.NotNull(vm);
        }

        // TODO WTS: Add tests for functionality you add to MainViewModel.
        [Fact]
        public void TestMainViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new MainViewModel();
            Assert.NotNull(vm);
        }

        // TODO WTS: Add tests for functionality you add to MediaPlayerViewModel.
        [Fact]
        public void TestMediaPlayerViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new MediaPlayerViewModel();
            Assert.NotNull(vm);
        }

        // TODO WTS: Add tests for functionality you add to SettingsViewModel.
        [Fact]
        public void TestSettingsViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new SettingsViewModel();
            Assert.NotNull(vm);
        }
    }
}
