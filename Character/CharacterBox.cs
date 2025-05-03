using System.Collections;
using UnityEngine;




public abstract class BoxCharacter : Character
{
    new BoxCollider2D collider;
    
    public new void Start()
    {
        base.Start();
        SetCollider2D();
    }
    public override void SetCollider2D()
    {
        collider = GetComponent<BoxCollider2D>();
    }
    public BoxCollider2D BoxCollider2D()
    {
        return collider;
    }
}
