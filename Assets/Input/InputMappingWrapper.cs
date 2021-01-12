using UnityEngine;

namespace Input
{
	
	public class InputMappingWrapper
	{

		private static InputMapping inputMappingCache;

		public static InputMapping InputMapping { get; private set; }

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitInput()
		{
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