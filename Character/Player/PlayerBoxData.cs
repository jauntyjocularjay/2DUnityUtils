using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "Data/BoxPlayer", order = 99)]
public class BoxPlayerData : BoxCharacterData
{
    [Header("Player Properties")]
    public Vector3 cameraOffset;
    public float airControlVelocity;
}
