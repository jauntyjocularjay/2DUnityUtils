using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName ="Data/Platform", order = 10)]
public class PlatformData : ScriptableObject
{
    public Vector2 nativeSize;
    [Header("Size")]
    public bool lockWidth;
    public bool lockHeight;

}
