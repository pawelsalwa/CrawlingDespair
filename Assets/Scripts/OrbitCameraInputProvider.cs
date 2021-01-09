using System.Collections;
using System.Collections.Generic;
using Character.Teddy;
using Cinemachine;
using UnityEngine;

public class OrbitCameraInputProvider : MonoBehaviour
{
	[SerializeField] private CinemachineFreeLook cinemachineFreeLook = null;
	// [SerializeField] private InputMappingWrapper input = null;
	[SerializeField] private float speedX = 1f;
	[SerializeField] private float speedY = 1f;

	private void Start()
	{
		cinemachineFreeLook = GetComponent<CinemachineFreeLook>();
	}

	public void MoveCamera(Vector2 val)
	{
		var newAxisX = cinemachineFreeLook.m_XAxis;
		newAxisX.Value += val.x * speedX * Time.deltaTime;
		cinemachineFreeLook.m_XAxis = newAxisX;

		var newAxisY = cinemachineFreeLook.m_YAxis;
		newAxisY.Value += val.y * speedY * Time.deltaTime;
		cinemachineFreeLook.m_YAxis = newAxisY;
	}


	private void Update()
	{
		MoveCamera(InputMappingWrapper.InputMapping.Player.Look.ReadValue<Vector2>());
	}
}