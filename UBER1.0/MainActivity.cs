using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace UBER1._0
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class Activity1 : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            

            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_main);

            var client = new WebClient();
            var text = client.DownloadString("https://jsonplaceholder.typicode.com/users/1");

            Users users = JsonConvert.DeserializeObject<Users>(text);


            //check if login session correct

            EditText eLog = FindViewById<EditText>(Resource.Id.editLogin);
            EditText eMail = FindViewById<EditText>(Resource.Id.editEmail);
            Button logBtn = FindViewById<Button>(Resource.Id.btnLogin);

            var test = users.username;

            logBtn.Click += (e, o) =>
            {   
                string loginName = eLog.Text;
                string loginEmail = eMail.Text;
                if (loginName.Equals(users.username)&&loginEmail.Equals(users.email))
                {
                    Toast.MakeText(Application.Context, "Login Successfull!", ToastLength.Short).Show();
                    Intent intent = new Intent(this, typeof(Menu));
                    this.StartActivity(intent);
                }
                else
                {
                    Toast.MakeText(Application.Context, "Login or e-mail not correct!", ToastLength.Short).Show();
                }
            };
        }
    }
}