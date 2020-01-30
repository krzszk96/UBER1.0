using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net;

namespace UBER1._0
{
    [Activity(Label = "Account1")]
    public class Account1 : Activity
    {
        int AccMoney = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.account);
            var client = new WebClient();
            var text = client.DownloadString("https://jsonplaceholder.typicode.com/users/1");

            Users users = JsonConvert.DeserializeObject<Users>(text);


            TextView Log = FindViewById<TextView>(Resource.Id.UserName);
            TextView Mail = FindViewById<TextView>(Resource.Id.EmailValue);

            Log.Text = users.username;
            Mail.Text = users.email;

            Button btnCharge = FindViewById<Button>(Resource.Id.button1);

            TextView aStat = FindViewById<TextView>(Resource.Id.FinalAccValue); ///view after charge
            EditText cAcc = FindViewById<EditText>(Resource.Id.HowMuchCharge); ///view how much charge

            btnCharge.Click += (e, o) =>
            {
                AccMoney += Int32.Parse(cAcc.Text);
                aStat.Text = AccMoney.ToString();
            };

            //btnCharge.Click += SendData;
           
        }
        //public void SendData(object sender,EventArgs e)
        //{
        //    Intent _intent = new Intent(this, typeof(Order));
        //    _intent.PutExtra("text", AccMoney);
        //}
    }
}