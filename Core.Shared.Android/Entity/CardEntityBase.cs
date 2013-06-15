using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using System.ComponentModel;

namespace Core
{
	public class CardEntityBase
    {
		public CardEntityBase()
		{
		}

		private List<DataBinding> mDataBindingList;
		public List<DataBinding> DataBindingList 
		{
			get { return mDataBindingList; }
			set { mDataBindingList = value; }
		}

		public object this[string name]
		{
			get { return GetValue(name); }
			set { SetValue(name, value); }
		}

		private object GetValue(string name)
		{
			PropertyDescriptor prop = TypeDescriptor.GetProperties(this)[name];
			return prop.GetValue (this);
		}

		private void SetValue(string name, object value)
		{

		}
	}
}
