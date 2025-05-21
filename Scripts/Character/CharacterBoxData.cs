using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class BoxCharacterData : CharacterData
{

    [Header("BoxCollider")]
    public Vector2 colliderOffset;
    public Vector2 colliderSize;
    public float colliderEdgeRadius;

}