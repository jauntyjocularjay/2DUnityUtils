using UnityEngine;



public abstract class PolygonCharacter : Character
{
    public new PolygonCollider2D collider;
    public BoxCharacterData data;
    public new void Start()
    {
        base.Start();
        SetCollider2D();
    }

    public override void SetCollider2D()
    {
        collider = GetComponent<PolygonCollider2D>();
        collider.offset = data.colliderOffset;
    }
    public new void SetRigidbody2D()
    {
        base.SetRigidbody2D();
        RigidBody2D().mass = data.mass;
        RigidBody2D().gravityScale = data.gravityScale;
    }
    public new void SetSpriteRenderer()
    {
        SpriteRenderer().sortingLayerID = data.sortingLayerID;
        SpriteRenderer().sortingOrder = data.sortingOrder;
    }
}