using System.Reflection;
using UnityEditor;

namespace SalwaExtensions
{
	public static class SerializedPropertyExtension
	{
		/// <summary> useful for property drawers so you can have actual object that is drawn, not just serialized property.... </summary>
		/// <param name="prop"></param>
		/// <returns></returns>
		public static object GetTargetObjectOfProperty(this SerializedProperty prop) 
		{
			if (prop == null) return null;

			var path = prop.propertyPath.Replace(".Array.data[", "[");
			object obj = prop.serializedObject.targetObject;
			var elements = path.Split('.');
			foreach (var element in elements)
			{
				// if (element.Contains("[")) //jebac obsluge tablic
				// {
				// 	var elementName = element.Substring(0, element.IndexOf("["));
				// 	var index = System.Convert.ToInt32(element.Substring(element.IndexOf("[")).Replace("[", "").Replace("]", ""));
				// 	obj = GetValue_Imp(obj, elementName, index);
				// }
				// else
				{
					obj = GetValue_Imp(obj, element);
				}
			}
			return obj;
		}
		
		private static object GetValue_Imp(object source, string name)
		{
			if (source == null)
				return null;
			var type = source.GetType();

			while (type != null)
			{
				var f = type.GetField(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
				if (f != null)
					return f.GetValue(source);

				var p = type.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
				if (p != null)
					return p.GetValue(source, null);

				type = type.BaseType;
			}
			return null;
		}
	}
}