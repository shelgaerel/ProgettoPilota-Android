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
using Java.Util;

using Core;

namespace Prototipo
{
	[Activity (Label = "Navigator", MainLauncher = true)]			
	public class Navigator : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			this.SetContentView(Resource.Layout.Navigator);

			Button btnAree = FindViewById<Button>(Resource.Id.Aree);
			if(btnAree != null)
			{
				btnAree.Click += StartUI;
			}
		}

		public void StartUI(object sender, EventArgs e)
		{
			CardEngineBase engine;
			string UIQualifiedName;
			string engineQualifiedName;
			string entityQualifiedName;
			string resourceQualifiedName;

			View item = sender as View;
			Type itemType = Type.GetType(item.Tag.ToString());

			switch (item.Tag.ToString()) 
			{
			case "AreeUI":
				UIQualifiedName = "Tabelle.AreeUI, Tabelle.Android";
				engineQualifiedName = "Tabelle.AreeEngine, Tabelle.Android";
				entityQualifiedName = "Tabelle.AreeEntity, Tabelle.Android";
				resourceQualifiedName = "Prototipo.Resource, Prototipo.Android";
				engine = CardEngineFactory.CreateEngine(engineQualifiedName, entityQualifiedName);

				Intent intent = new Intent (this, Type.GetType (UIQualifiedName));
				intent.PutExtra ("ENGINE", Utility.DataContractSerialize (engine, false));
				intent.PutExtra ("RESOURCE", resourceQualifiedName);
				intent.PutExtra ("ACTION", (int)CardAction.Read);

				this.StartActivity(intent);

				break;
			default:
				break;
			}
		}
	}
}

