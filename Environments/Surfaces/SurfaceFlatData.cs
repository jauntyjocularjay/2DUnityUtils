using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName ="Data/SurfaceFlat", order = 10)]
public class SurfaceFlatData : ScriptableObject
{
    public Vector2 nativeSize;
    [Header("Size")]
    public bool lock_width;
    public bool lock_height;
    void Awake()
    {
    }

}
