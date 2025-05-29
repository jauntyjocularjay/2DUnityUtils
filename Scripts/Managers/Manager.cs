using UnityEngine;
using UnityEngine.SceneManagement;



public abstract class Manager : MonoBehaviour
{
    readonly float mapUnitSide = 2.8125f;
    [Header("Camera Orthagonal Size Multiplier")]
    public float size = 2.0f;
    public Scene nextScene;
    public Vector3 cameraMinimumPosition = Vector3.zero;
    public Vector3 cameraMaximumPosition = Vector3.zero;
    public void Start()
    {
        MainCamera().orthographicSize = size * mapUnitSide;
    }
    public Camera MainCamera()
    {
        return Camera.main;
    }

}
