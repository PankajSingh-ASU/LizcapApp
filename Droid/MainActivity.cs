
using Android.App;
using Android.Widget;
using Android.OS;
using SQLite.Net.Platform.XamarinAndroid;
using Android.Database.Sqlite;
using System;
using System.Collections.Generic;
using Android.Content;

namespace SQliteTest.Droid
{
	[Activity(Label = "SQliteTest", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		DatabaseAccess d;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);
			SQLiteUtil sq = new SQLiteUtil(this);
			SQLiteDatabase _objSQLiteDatabase = sq.WritableDatabase;
			// Get our button from the layout resource,
			// and attach an event to it
			var dbPath=SqlConnCreator.getConnectionPath();
			 d = new DatabaseAccess(dbPath,new SQLitePlatformAndroid() );

			Button button = FindViewById<Button>(Resource.Id.myButton);

			//button.Click += delegate { 
				var data=d.tableQueries();
				Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner1);
				spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
			ArrayAdapter adapter = 
				new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, data);


				spinner.Adapter = adapter;



			//};

		}
		private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			//Merchant merch = (Merchant)spinner.SelectedItem;
			string table = (string)spinner.GetItemAtPosition(e.Position);
			var columns=d.schemaQuery(table);
			DynamicUICreator creator = new DynamicUICreator();
			var main = FindViewById<LinearLayout>(Resource.Id.mainLayout);

			var layout = main.FindViewById<LinearLayout>(1);
			if (layout != null)
				main.RemoveView(layout);
			 layout=creator.createDynamicUI(this,columns);
			main.AddView(layout);


		}


}
}

