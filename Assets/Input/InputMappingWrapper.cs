using UnityEngine;

namespace Input
{
	
	public class InputMappingWrapper
	{

		private static InputMapping inputMappingCache;

		public static InputMapping InputMapping { get; private set; }

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void InitInput()
		{
			Debug.Log($"<color=white>input inited</color>");
			InputMapping = new InputMapping();
			InputMapping.Player.Enable();
			InputMapping.UI.Disable();
		}

		public static void EnableUiMapping()
		{
			InputMapping.Player.Disable();
			InputMapping.UI.Enable();
		}

		public static void EnablePlayerMapping()
		{
			InputMapping.Player.Enable();
			InputMapping.UI.Disable();
		}
	}
}