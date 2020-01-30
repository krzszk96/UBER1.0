using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace UBER1._0
{
    [Activity(Label = "Menu")]
    public class Menu : Activity
    {
        Button btnA, btnO, btnS;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.menu);
            btnA = FindViewById<Button>(Resource.Id.btnAcc);
            btnO = FindViewById<Button>(Resource.Id.btnOrd);
            btnS = FindViewById<Button>(Resource.Id.btnSet);
            btnA.Click += BtnA_Click;
            btnO.Click += BtnO_Click;
            btnS.Click += BtnS_Click;

        }

        private void BtnS_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Settings));
            this.StartActivity(intent);
        }

        private void BtnO_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Order));
            this.StartActivity(intent);
        }

        private void BtnA_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Account1));
            this.StartActivity(intent);
        }
    }
}