using UnityEngine;


namespace DMBTools
{
    public abstract class CharacterData : ScriptableObject
    {
        [Header("Character")]
        public int MaxHP = 0;
        public int currentHP;
        public bool silhouette = false;
        public int jumps = 1;
        public Vector3 movementVelocity = Vector3.one;
    }


}

