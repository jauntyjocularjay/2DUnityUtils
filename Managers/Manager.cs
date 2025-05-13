using UnityEngine;



[ExecuteAlways]
public abstract class Manager : MonoBehaviour
{
    readonly float mapUnitSide = 1.40625f;
    [Header("Camera Orthagonal Size Multiplier")]
    public float size = 4.0f;
    void Awake()
    {
        MainCamera().orthographicSize = size * mapUnitSide;
    }
    public Camera MainCamera()
    {
        return Camera.main;
    }
}
