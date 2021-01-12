using System.Collections;
using System.Collections.Generic;
using Character.Teddy;
using ScriptableObjects;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    public static Camera gameplayCamera;

    private void Awake() => gameplayCamera = GetComponent<Camera>();
}
