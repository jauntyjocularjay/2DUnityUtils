using UnityEngine;



namespace DMBTools
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "DMBTools/Data/BoxPlayer", order = 0)]
    public class BoxPlayerData : BoxCharacterData
    {
        [Header("airControl is an integer between 0-12 that adds velocity during jumps.")]
        public int airControl;
        public FractionScale airControlVelocity = new FractionScale(0, 12);
        public void AirControlVelocity(int i)
        {
	        airControlVelocity.Numerator = i;
            airControl = i;
        }
        public float AirControlVelocity()
            => airControlVelocity.ToFloat();
    }


}

