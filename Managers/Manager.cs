using UnityEngine;
using UnityEngine.SceneManagement;



[ExecuteAlways]
public abstract class Manager : MonoBehaviour
{
    readonly float mapUnitSide = 2.8125f;
    [Header("Camera Orthagonal Size Multiplier")]
    public float size = 4.0f;
    public Scene nextScene;
    public Vector3 cameraMinimumPosition;
    public Vector3 cameraMaximumPosition;
    public void Start()
    {
        MainCamera().orthographicSize = size * mapUnitSide;
    }
    public Camera MainCamera()
    {
        return Camera.main;
    }
}
