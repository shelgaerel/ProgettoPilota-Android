using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace Core
{
	public static class CardEngineFactory
	{
		public static CardEngineBase CreateEngine(string engineQualifiedName, string entityQualifiedName)
		{
			CardEngineBase engine = (CardEngineBase)CreateObject(engineQualifiedName);
			CardEntityBase entity = (CardEntityBase)CreateObject(entityQualifiedName);

			entity.DataBindingList = GetDataBindingList (entityQualifiedName);
			engine.SetEntity(entity);

			return (CardEngineBase)engine;
		}

		public static object CreateObject(string assemblyQualifiedName)
		{
			Type providerType = Type.GetType(assemblyQualifiedName, true);
			
			if (providerType == null)
				throw new Exception(string.Format("Creazione {0} fallita", assemblyQualifiedName));  
			
			return Activator.CreateInstance(providerType);
		}

		private static List<DataBinding> GetDataBindingList(string entityName)
		{
			Type entityType = Type.GetType(entityName, true);

			List<DataBinding> fieldList = new List<DataBinding>();
			PropertyInfo[] entityProperty = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty);
			
			foreach (PropertyInfo property in entityProperty) 
			{
				DataBinding bindingItem = new DataBinding ();
				bindingItem.PropName = property.Name;

				IEnumerable<FieldName> fieldNames = (IEnumerable<FieldName>)property.GetCustomAttributes(typeof(FieldName), true);
				foreach (var field in fieldNames) 
					bindingItem.FieldName = field.Name;

				fieldList.Add(bindingItem);
			}

			return fieldList;
		}

		private static Assembly LoadAssembly(string engineQualifiedName)
		{
			Type engineType = Type.GetType(engineQualifiedName, true);
			
			string fileName = GetPluginAssemblyNameFrom(engineType);
			Assembly assembly = Assembly.LoadFrom(fileName);
			return assembly;
		}

		private static string GetPluginAssemblyNameFrom(Type toLoad)
		{
			string fileName = string.Format("{0}{1}", toLoad.Namespace, ".dll");
			var location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			return Path.Combine(location, fileName);
		}
	}
}

