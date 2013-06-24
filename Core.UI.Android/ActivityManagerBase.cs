
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Core;

namespace Core.UI
{
	public abstract class ActivityManagerBase: Activity
	{
		protected CardEngineBase mEngine { get; private set; }
	
		protected override void OnCreate (Bundle savedInstanceState)
		{
			string engineQualifiedName = Intent.GetStringExtra ("ENGINE");
			if (!string.IsNullOrEmpty (engineQualifiedName)) 
				mEngine = Utility.DataContractDeserialize (engineQualifiedName, false) as CardEngineBase;

			string resourceQualifiedName = Intent.GetStringExtra ("RESOURCE");
			CardAction action =  (CardAction)Intent.GetIntExtra ("ACTION", 0);

			Type resourceType = Type.GetType(resourceQualifiedName, true);
			Type[] nestedTypes = resourceType.GetNestedTypes();

			foreach (var nestedClass in nestedTypes) 
			{
				if (nestedClass.Name == "Id") 
				{
					foreach (FieldInfo field in nestedClass.GetFields())
					{
						int idField;
						EditText viewfield;
					
						// Se la costante appartiene all'elenco dei campi taggati sull'entità, allora leggo il valore e aggiorno il campo a video
						if (mEngine.CardEntity.DataBindingList.Where(a => a.FieldName == field.Name).Count() > 0)
						{
							idField = (int)field.GetRawConstantValue();
							viewfield = FindViewById<EditText>(idField);
//							View aa = FindViewById (idField);
//							Type ee = Type.GetType (aa., true);


							viewfield.Text = (string)mEngine.CardEntity[mEngine.CardEntity.DataBindingList.First(a => a.FieldName == field.Name).PropName];
						}
					}
				}
			}

			base.OnCreate(savedInstanceState);
		}

		public void Read()
		{

		}

		public void Update()
		{

		}
	}
}

