using System;
using UnityEngine;

namespace GameCore
{
	/// <summary> allows inspecting scriptable objects through fields </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public class InspectableAttribute : PropertyAttribute
	{
		
	}
}