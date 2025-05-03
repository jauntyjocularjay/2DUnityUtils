using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName ="Data/SurfaceFlat", order = 10)]
public class SurfaceFlatData : ScriptableObject
{
    public Vector2 nativeSize;
    [Header("Size")]
    public bool lockWidth;
    public bool lockHeight;
    void Awake()
    {
    }

}
