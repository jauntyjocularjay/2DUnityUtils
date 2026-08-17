using UnityEngine;


namespace DMBTools
{
    public abstract class CharacterData : ScriptableObject
    {
        [Header("Character")]
        public int MaxHP = 0;
        public bool silhouette = false;
        public int ExtraJumps = 0;
        public Vector3 movementVelocity = Vector3.one;
    }


}

