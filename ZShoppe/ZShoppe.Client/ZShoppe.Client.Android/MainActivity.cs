using Android.App;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Util;
using FFImageLoading.Forms.Platform;
using Prism;
using Prism.Ioc;
using Serilog;
using Syncfusion.Licensing;
using ZShoppe.Client.Common.Presentation;
using ZShoppe.Client.Droid.Helpers;
using Log = Serilog.Log;

namespace ZShoppe.Client.Droid
{
    [Activity(Label = "ZShoppe", Icon = "@mipmap/ic_launcher", Theme = "@style/GreenTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait )]
    public partial class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override async void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Log.Logger.Debug("Logger is loaded");

            SyncfusionLicenseProvider.RegisterLicense("OTU2OEAzMTM2MmUzMjJlMzBldVRMVGk0UktaNzE2Z0dLdEorTTArYmpGKytyQlRrVlpqcG9OemRKWTRBPQ==");

            CachedImageRenderer.Init(true);
           // AnimationViewRenderer.Init();
            global::Xamarin.Forms.Forms.Init(this, bundle);
            
            Syncfusion.XForms.Android.PopupLayout.SfPopupLayoutRenderer.Init();
            //Get the height and width
            DisplayMetrics displayMetrics = new DisplayMetrics();
            WindowManager.DefaultDisplay.GetRealMetrics(displayMetrics);
            BindingProxy.AppHeight = displayMetrics.HeightPixels;
            BindingProxy.AppWidth = displayMetrics.WidthPixels;

            await LogHelpers.InitDefaultLogger();

            LoadApplication(new Bootstrapper(new AndroidInitializer()));
        }

        protected override void OnResume()
        {
            base.OnResume();
            var colors = new int[] { Android.Graphics.Color.ParseColor("#56ab2f"), Android.Graphics.Color.ParseColor("#a8e063") };
            var drawable = new GradientDrawable(GradientDrawable.Orientation.RightLeft, colors);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (toolbar != null) toolbar.SetBackgroundDrawable(drawable);
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            container.RegisterInstance(typeof(ILogger), Log.Logger);
        }
    }
}

