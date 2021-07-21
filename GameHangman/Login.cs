using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameHangman
{
    [Activity(Label = "Login")]
    public class Login : Activity
    {
        Android.Widget.EditText txtUserName;
        Android.Widget.EditText txtpwd;
        Android.Widget.Button btnLogin,btnview_Player;
        
        List<String> dtUser;

        List<String> dtPwd;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login_Design);

            txtUserName = FindViewById<EditText>(Resource.Id.edtLoginUser);

            txtpwd = FindViewById<EditText>(Resource.Id.edtLoginpssword);


            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            //   btn.Click += Btntest_Clicked;
            btnLogin.Click += new EventHandler(BtnLoginCheck_Clicked);

            btnview_Player = FindViewById<Button>(Resource.Id.btnViewPlayer);
            //   btn.Click += Btntest_Clicked;
            btnview_Player.Click += new EventHandler(BtnView_Player_Clicked);



            Model.ConnectionClass.Instnce.createTble();

            dtUser = Model.ConnectionClass.Instnce.getUsersList().Select(c => c.Email).ToList();
            dtPwd = Model.ConnectionClass.Instnce.getUsersList().Select(c => c.Password).ToList();





            // Create your application here
        }

        private void BtnView_Player_Clicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(PlayerList));
            
            StartActivity(intent);
        }

        private void BtnLoginCheck_Clicked(object sender, EventArgs e)
        {
            String usr = txtUserName.Text.ToString();
            String pwd = txtpwd.Text.ToString();

           

            int ct = 0;

          
            for (int x = 0; x < dtUser.Count; x++)
            {
                String h = dtUser[x].ToString();
                String i = dtPwd[x].ToString();

                //  Toast.MakeText(Application.Context, "Check User Name  and  Password", ToastLength.Short).Show();

                if (usr.Equals(h) && pwd.Equals(i))
                {
                    Intent intent = new Intent(this, typeof(GamePlay));
                    intent.PutExtra("Name", usr);
                    StartActivity(intent);
                    ct++;
                    break;

                }

            }
            //btn.Text = "In====" + usr;

            if (ct == 0)
            {
                Toast.MakeText(Application.Context, "Check User Name  and  Password", ToastLength.Short).Show();
            }




        }
    }
}