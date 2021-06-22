using System;
using UnityEngine;

namespace SalwaExtensions
{


	[AttributeUsage(AttributeTargets.Field)]
	public class DrawIfAttribute : PropertyAttribute
	{
		public string boolFieldName;

		public DrawIfAttribute(string boolFieldName)
		{
			this.boolFieldName = boolFieldName;
		}
	}
}