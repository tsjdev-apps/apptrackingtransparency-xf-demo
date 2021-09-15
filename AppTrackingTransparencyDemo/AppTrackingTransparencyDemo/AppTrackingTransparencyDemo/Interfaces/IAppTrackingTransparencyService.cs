using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AppTrackingTransparencyDemo.Interfaces
{
    public interface IAppTrackingTransparencyService
    {
        Task<PermissionStatus> CheckStatusAsync();

        void Request(Action<PermissionStatus> completionAction);
    }
}
