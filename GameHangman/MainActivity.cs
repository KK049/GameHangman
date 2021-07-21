using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace GameHangman
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Android.Widget.Button btn_Register,btn_Login,btn_Exit;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btn_Login = FindViewById<Button>(Resource.Id.btnLogin);

            btn_Register = FindViewById<Button>(Resource.Id.btnRegister);


            btn_Exit = FindViewById<Button>(Resource.Id.btnExit);
            btn_Exit.Click += new EventHandler(Btn__Exit_Clicked);

            btn_Register.Click += new EventHandler(Btn__Register_Clicked);
            btn_Login.Click += new EventHandler(Btn__Login_Clicked);

        }

        private void Btn__Exit_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }

        private void Btn__Login_Clicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Login));
            StartActivity(intent);
        }

        private void Btn__Register_Clicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Register));
            StartActivity(intent);

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}