using UnityEngine;


namespace DMBTools
{
    public abstract class CharacterData : ScriptableObject
    {
        [Header("Character")]
        public int MaxHP = 0;
        public bool courtesy = false;
        public int ExtraJumps = 0;
        public bool flipX = false;
        public Vector3 movementVelocity = Vector3.one;

        [Header("SpriteRenderer")]
        public int sortingLayerID = 0;
        public int sortingOrder = 0;
        [Header("Rigidbody")]
        public float mass = 1.0f;
        public float gravityScale = 1.0f;
    
    }


}

