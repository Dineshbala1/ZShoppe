using System.Linq;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Views;

namespace ZShoppe.Client.Droid
{
    [Activity(Label = "ZShoppe", Icon = "@mipmap/ic_launcher", Theme = "@style/SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait, NoHistory = true)]
    class SplashActivity : AppCompatActivity
    {
        readonly string[] PermissionsRequired =
        {
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.Internet
        };

        const int RequestExternalStorageId = 1024;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        protected override async void OnResume()
        {
            base.OnResume();
            await NavigateToMainActivity();
            //requestExternalStoragePermission();
        }

        public override async void OnRequestPermissionsResult(int requestCode, string[] permissions,
            Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            if (requestCode == RequestExternalStorageId)
            {
                if (grantResults.Any(row => row == Permission.Denied))
                {
                    RequestPermissions(PermissionsRequired, RequestExternalStorageId);
                }
                else
                {
                    await NavigateToMainActivity();
                }
            }
        }

        private async void requestExternalStoragePermission()
        {
            const string permission = Manifest.Permission.WriteExternalStorage;
            if (CheckSelfPermission(permission) == (int) Permission.Granted)
            {
                await NavigateToMainActivity();
                return;
            }

            RequestPermissions(PermissionsRequired, RequestExternalStorageId);
        }

        private async Task NavigateToMainActivity()
        {
            await Task.Run(() => { StartActivity(new Intent(this, typeof(MainActivity))); });
        }
    }
}