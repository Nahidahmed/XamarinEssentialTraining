﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TourStops.Droid
{
	[Activity(Label = "TourStops.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		//		int count = 1;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button1 = FindViewById<Button>(Resource.Id.callButton1);
			Button button2 = FindViewById<Button>(Resource.Id.callButton2);

			button1.Click += delegate
			{
				CallNumber(button1.Text);
				var result = AddNumbers(3, 6);
			};
			button2.Click += delegate
			{
				CallNumber(button2.Text);
			};
		}
		private int AddNumbers(int number1, int number2)
		{
			var localNumber = number1 + 5;
			var total = localNumber + number2;
			return total;
		}
		private void CallNumber(string phoneNumber)
		{
			var callDialog = new AlertDialog.Builder(this);
			callDialog.SetMessage("Call " + phoneNumber);


			callDialog.SetPositiveButton("Call", delegate
			{
				var callIntent = new Intent(Intent.ActionCall);
				callIntent.SetData(Android.Net.Uri.Parse("tel:" + phoneNumber));
				StartActivity(callIntent);
			});
			callDialog.SetNeutralButton("Cancel", delegate { });

			callDialog.Show();
		}
	}
}

