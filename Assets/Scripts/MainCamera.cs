
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    public static Camera gameplayCamera;

    private void Awake() => gameplayCamera = GetComponent<Camera>();
}
