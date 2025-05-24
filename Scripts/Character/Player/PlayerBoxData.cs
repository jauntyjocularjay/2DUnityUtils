using UnityEngine;
using Assets.DMBTools.FractionScale;

namespace DMBTools
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/BoxPlayer", order = 80)]
    public class BoxPlayerData : BoxCharacterData
    {
        [Header("Player Properties")]
        public Vector3 cameraOffset;
        [Header("airControl is an integer between 0-12 that adds velocity during jumps.")]
        public int airControl;
        public FractionScale airControlVelocity = new FractionScale(0, 12);
        public void AirControlVelocity(int i)
        {
            airControlVelocity.SetNumerator(i);
            airControl = i;
        }
        public float AirControlVelocity()
        {
            return airControlVelocity.ToFloat();
        }
    }


}

