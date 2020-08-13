using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Foundation;
using Prism;
using Prism.Ioc;
using UIKit;

namespace XamarinSummitAgendamento.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            CultureInfo brasilCulture = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = brasilCulture;


            Rg.Plugins.Popup.Popup.Init();

            global::Xamarin.Forms.Forms.Init();
            Xamarin.FormsGoogleMaps.Init("AIzaSyAyLcWqCC-B30whne7pKobNM8MrW_dUyKU");
            XF.Material.iOS.Material.Init();

            Plugin.LocalNotification.NotificationCenter.AskPermission();

            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(app, options); 
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {


        public iOSInitializer()
        {
 
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
