using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace AttendanceIOS.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        App formsApp;
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            global::ZXing.Net.Mobile.Forms.iOS.Platform.Init();

            formsApp = new App();
            LoadApplication(formsApp);

            
            return base.FinishedLaunching(app, options);

        }
    }
}
