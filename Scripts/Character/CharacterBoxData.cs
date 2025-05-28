using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DMBTools
{
    public class BoxCharacterData : CharacterData
    {
    
        [Header("BoxCollider")]
        public Vector2 colliderOffset;
        public Vector2 colliderSize;
        public Vector2 colliderOverlapPoint;
        public float colliderEdgeRadius;
    
    }


}

