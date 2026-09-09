using UnityEditor.EditorTools;
using UnityEngine;



namespace DMBTools
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "DMBTools/Data/BoxPlayer", order = 99)]
    public class PlayerData : CharacterData
    {
        public int maxHealth;
        public int HP;
        [Tooltip("airControl is an integer between 0-12 that adds velocity during jumps dictated by the input Vector.x")]
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

