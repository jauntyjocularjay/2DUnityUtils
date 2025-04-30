using UnityEngine;

[ExecuteAlways]
public abstract class Manager : MonoBehaviour
{
    Camera cam;
    readonly float mapUnitSide = 1.40625f;
    [Header("Camera Orthagonal Size Multiplier")]
    public float size = 4.0f;
    void Awake()
    {
        cam = Camera.main;
        cam.orthographicSize = size * mapUnitSide;
    }
    public Camera MainCamera()
    {
        return cam;
    }
}
