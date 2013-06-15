using System;

namespace Core
{
    [AttributeUsage(AttributeTargets.Property)]
	public class FieldName : Attribute
	{
		public string Name;
		public FieldName(string name)
		{
			this.Name = name;
		}
	}
}

