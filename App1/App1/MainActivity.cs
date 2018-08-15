using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using SkiaSharp;
using Microcharts;
using Microcharts.Droid;

namespace App1
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_main);

			Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

			FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            var entries = new[]
            {
                new Entry(200)
                {
                    Label = "January",
                    ValueLabel = "200",
                    Color = SKColor.Parse("#266489")
                },
                new Entry(400)
                {
                    Label = "February",
                    ValueLabel = "400",
                    Color = SKColor.Parse("#68B9C0")
                },
                new Entry(-100)
                {
                    Label = "March",
                    ValueLabel = "-100",
                    Color = SKColor.Parse("#90D585")
                }
            };

            var chart = new BarChart() { Entries = entries };
            var chart1 = new PointChart() { Entries = entries };
            var chart2 = new LineChart() { Entries = entries };
            var chart3 = new DonutChart() { Entries = entries };
            var chart4 = new RadialGaugeChart() { Entries = entries };
            var chart5 = new RadarChart() { Entries = entries };

            var chartView = FindViewById<ChartView>(Resource.Id.chartView);
            var chartView1 = FindViewById<ChartView>(Resource.Id.chartView1);
            var chartView2 = FindViewById<ChartView>(Resource.Id.chartView2);
            var chartView3 = FindViewById<ChartView>(Resource.Id.chartView3);
            var chartView4 = FindViewById<ChartView>(Resource.Id.chartView4);
            var chartView5 = FindViewById<ChartView>(Resource.Id.chartView5);

            chartView.Chart = chart;
            chartView1.Chart = chart1;
            chartView2.Chart = chart2;
            chartView3.Chart = chart3;
            chartView4.Chart = chart4;
            chartView5.Chart = chart5;

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

