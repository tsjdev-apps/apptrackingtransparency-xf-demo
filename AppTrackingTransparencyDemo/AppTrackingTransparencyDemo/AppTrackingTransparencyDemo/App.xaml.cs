using AppTrackingTransparencyDemo.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppTrackingTransparencyDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override async void OnStart()
        {
            if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                var appTrackingTransparencyService = DependencyService.Get<IAppTrackingTransparencyService>();
                var status = await appTrackingTransparencyService.CheckStatusAsync();

                if (status != PermissionStatus.Granted)
                    await appTrackingTransparencyService.RequestAsync(s => HandleTracking(s));
                else
                    HandleTracking(status);
            }
        }

        private void HandleTracking(PermissionStatus status)
        {
            if (status != PermissionStatus.Granted)
                return;

            // enable tracking
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
