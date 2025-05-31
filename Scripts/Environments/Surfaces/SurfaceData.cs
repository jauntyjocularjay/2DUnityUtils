using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName ="DMBTools/Data/Surface", order = 10)]
public class SurfaceData : ScriptableObject
{
    [Header("Size")]
    public Vector2 nativeSize;
    public bool lockWidth;
    public bool lockHeight;

}
