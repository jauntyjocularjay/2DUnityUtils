using System.Collections;
using UnityEngine;



public abstract class BoxPlayer: BoxCharacter
{
    public BoxPlayerData data;
    // public PlayerMovement playerMovement;
    public new void Start()
    {
        base.Start();

        SetCollider2D();
        SetRigidbody2D();

        BoxCollider2D().offset = data.colliderOffset;
        BoxCollider2D().size = data.colliderSize;
        
        RigidBody2D().mass = data.mass;
        RigidBody2D().gravityScale = data.gravityScale;

        SpriteRenderer().sortingLayerID = data.sortingLayerID;
        SpriteRenderer().sortingOrder = data.sortingOrder;

        SpriteRenderer().sortingLayerID = data.sortingLayerID;
        SpriteRenderer().sortingOrder = data.sortingOrder;

        SetHP(data.MaxHP);
    }
}
