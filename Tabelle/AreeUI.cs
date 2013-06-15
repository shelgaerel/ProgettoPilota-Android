using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Core;
using Core.UI;

using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Tabelle
{
	[Activity (Label = "Prototipo")]
	public class AreeUI : DataManagerBase 
	{
		private AreeEngine Engine
		{
			get { return (AreeEngine)base.mEngine; } 
		}

		public AreeEntity Entity
		{
			get {return Engine.CardEntity;}
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			SetContentView (Resource.Layout.AreeUI);
			base.OnCreate(savedInstanceState);
		}
	}
}


