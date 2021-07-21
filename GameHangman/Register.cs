using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GameHangman.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameHangman
{
    [Activity(Label = "Register")]
    public class Register : Activity
    {
        Android.Widget.EditText txtUserName;
        Android.Widget.EditText txtpwd;
        Android.Widget.Button btnLogin;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
           SetContentView(Resource.Layout.Register_design);

            txtUserName = FindViewById<EditText>(Resource.Id.edtUser);

            txtpwd = FindViewById<EditText>(Resource.Id.edtpssword);


            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            //   btn.Click += Btntest_Clicked;
            btnLogin.Click += new EventHandler(BtnRegisterCheck_Clicked);

            ConnectionClass.Instnce.createTble();

            // Create your application here
        }

        private void BtnRegisterCheck_Clicked(object sender, EventArgs e)
        {
            UserClass register = new UserClass();
            register.Email = txtUserName.Text;
            register.Password = txtpwd.Text.ToString();
            int c = ConnectionClass.Instnce.Userinsrt(register);
            if (c == 1)
            {
                Toast.MakeText(Application.Context, "Users is Registered  ", ToastLength.Short).Show();
                txtUserName.Text = "";
                txtpwd.Text = "";
            }

        }
    }
}