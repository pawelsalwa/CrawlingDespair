using System.Collections.Generic;
using UnityEngine;

namespace Character
{
	public class CharacterDissolvator : MonoBehaviour
	{
		[SerializeField]
		private CharacterBase dyingCharacter = null;

		[SerializeField]
		private float timeout = 2f;

		[SerializeField]
		private AnimationCurve dissCurve = null;

		[SerializeField]
		private new Renderer renderer = null;

		[SerializeField]
		private string dissolveFloatKey = "_Dissolve";

		private bool dissolvin = false;
		private float progress = 0f;

		private List<Material> materials;

		private void Start()
		{
			dyingCharacter.CharacterHealth.OnDeath += OnDeath;
			materials = new List<Material>(renderer.materials);

			foreach (var material in materials)
			{
				material.SetFloat(dissolveFloatKey, 1f);
			}
		}

		private void OnDeath()
		{
			Invoke(nameof(StartDissolve), timeout);
		}

		[ContextMenu("StartDissolve")]
		private void StartDissolve()
		{
			dissolvin = true;
			progress = 0f;
		}

		void Update()
		{
			if (!dissolvin)
			{
				return;
			}

			foreach (var material in materials)
			{
				material.SetFloat(dissolveFloatKey, dissCurve.Evaluate(progress += Time.deltaTime));
			}
		}

		[ContextMenu("Reset")]
		private void Reset()
		{
			dissolvin = false;
			progress = 0f;

			foreach (var material in materials)
			{
				material.SetFloat(dissolveFloatKey, 1f);
			}
		}
	}
}