using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;

namespace LecturesDroid
{
	[Activity(Label = "LecturesDroid", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			ListView categoriesList = FindViewById<ListView>(Resource.Id.categorieslistView);
			categoriesList.Adapter = new LecturesAdapter(this, categoriesList);
		}
	}
}


