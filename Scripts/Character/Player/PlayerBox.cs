using System.Collections;
using UnityEngine;



public class BoxPlayer: BoxCharacter
{
    public BoxPlayerData data;
    // public PlayerMovement playerMovement;
    public new void Start()
    {
        base.Start();

        SetCollider2D();
        SetRigidbody2D();

        SpriteRenderer().sortingLayerID = data.sortingLayerID;
        SpriteRenderer().sortingOrder = data.sortingOrder;

        BoxCollider2D().offset = data.colliderOffset;
        BoxCollider2D().size = data.colliderSize;
        BoxCollider2D().edgeRadius = data.colliderEdgeRadius;
        
        RigidBody2D().mass = data.mass;
        RigidBody2D().gravityScale = data.gravityScale;

        SetHP(data.MaxHP);
    }
}
