using AppTrackingTransparency;
using AppTrackingTransparencyDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using static Xamarin.Essentials.Permissions;

namespace AppTrackingTransparencyDemo.iOS.Services
{
    public class AppTrackingTransparencyService : BasePlatformPermission,
            IAppTrackingTransparencyService
    {
        protected override Func<IEnumerable<string>> RequiredInfoPlistKeys
            => () => new string[] { "NSUserTrackingUsageDescription" };

        public void Request(Action<PermissionStatus> completionAction)
        {
            ATTrackingManager.RequestTrackingAuthorization(
                (result) => completionAction(ConvertStatus(result)));
        }

        public override Task<PermissionStatus> CheckStatusAsync()
        {
            return Task.FromResult(
                ConvertStatus(ATTrackingManager.TrackingAuthorizationStatus));
        }

        private PermissionStatus ConvertStatus(
            ATTrackingManagerAuthorizationStatus status)
        {
            switch (status)
            {
                case ATTrackingManagerAuthorizationStatus.NotDetermined:
                    return PermissionStatus.Disabled;
                case ATTrackingManagerAuthorizationStatus.Restricted:
                    return PermissionStatus.Restricted;
                case ATTrackingManagerAuthorizationStatus.Denied:
                    return PermissionStatus.Denied;
                case ATTrackingManagerAuthorizationStatus.Authorized:
                    return PermissionStatus.Granted;
                default:
                    return PermissionStatus.Unknown;
            }
        }
    }
}