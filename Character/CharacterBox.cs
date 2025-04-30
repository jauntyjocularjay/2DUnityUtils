using System.Collections;
using UnityEngine;




public abstract class BoxCharacter : Character
{
    public BoxCharacterData data;
    private new BoxCollider2D collider;
    public new void Start()
    {
        base.Start();
        SetCollider2D();
        SetRigidbody2D();
    }
    public override void SetCollider2D()
    {
        collider = GetComponent<BoxCollider2D>();
        collider.offset = data.colliderOffset;
        collider.size = data.colliderSize;
    }
    public new void SetRigidbody2D()
    {
        //base.SetRigidbody2D();
        RigidBody2D().mass = data.mass;
        RigidBody2D().gravityScale = data.gravityScale;
    }
    public new void SetSpriteRenderer()
    {
        //base.SetSpriteRenderer();
        SpriteRenderer().sortingLayerID = data.sortingLayerID;
        SpriteRenderer().sortingOrder = data.sortingOrder;
    }
}
