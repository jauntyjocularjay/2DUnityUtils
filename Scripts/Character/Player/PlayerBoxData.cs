using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/BoxPlayer", order = 80)]
public class BoxPlayerData : BoxCharacterData
{
    [Header("Player Properties")]
    public Vector3 cameraOffset;
    public float airControlVelocity;
}
