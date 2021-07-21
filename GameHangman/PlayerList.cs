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
    [Activity(Label = "PlayerList")]
    public class PlayerList : Activity
    {
        ListView lst;
        Android.Widget.Button btnBck;
        int idx = -1;
        ArrayAdapter usr;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.allPlayer);

           Model.ConnectionClass.Instnce.createTble();


            lst = FindViewById<ListView>(Resource.Id.lstPlayer);

            List<String> dt = Model.ConnectionClass.Instnce.getUsersList().Select(c => c.Email).ToList();

            usr = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, dt);

            lst.Adapter = usr;
            
            // Create your application here


            btnBck = FindViewById<Button>(Resource.Id.btnBck);
            btnBck.Click += new EventHandler(BtnBck_Clicked);

            // Create your application here
        }

        private void BtnBck_Clicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            
            StartActivity(intent);
        }
    }
}