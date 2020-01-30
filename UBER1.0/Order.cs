using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace UBER1._0
{
    [Activity(Label = "Order")]
    public class Order : Activity
    {
        private Button btnOrder;
        private TextView uCount, uCost;
        private int count = 10;
        Timer timer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.order);

            btnOrder = FindViewById<Button>(Resource.Id.btnOrderUber);
            uCount = FindViewById<TextView>(Resource.Id.uberTime);
            uCost = FindViewById<TextView>(Resource.Id.uberCost);

            btnOrder.Click += btnOrder_Click;

            //money = FindViewById<TextView>(Resource.Id.AccStatus);
            //money.Text = Intent.GetStringExtra("text");

        }

        private void calcCost()
        {
            int r = (new Random()).Next(10, 100);
            String text = r.ToString("00");
            RunOnUiThread(() =>
            {
                uCost.Text = "" + text + "$";
            });
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        protected override void OnResume()
        {
            base.OnResume();
            timer = new Timer();
            timer.Interval = 1000; //5 seconds
            timer.Elapsed += Timer_Elapsed;

        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            if (count > 0)
            {
                if (count == 10) { calcCost(); }
                count--;
                RunOnUiThread(() =>
                {
                    uCount.Text = "" + count;
                });
            }
            else
            {
                RunOnUiThread(() =>
                {
                    count = 10;
                    Toast.MakeText(this, "Hello it's your UBER driver waiting", ToastLength.Short).Show();
                    uCount.Text = "" + count;
                    timer.Stop();
                });

            }
        }
    }
}