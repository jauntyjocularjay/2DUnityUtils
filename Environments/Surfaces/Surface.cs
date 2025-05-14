using UnityEngine;

[ExecuteAlways]
public abstract class Surface : Prop
{
    readonly float spaceBetween = 0.999f; // Shrinks the width to accommodate other expanding surfaces
    BoxCollider2D collidr;

    [Header("Uneditable Information")]
    public Vector2 dataNativeSize;
    public bool dataLockWidth;
    public bool dataLockHeight;

    new void Start()
    {
        base.Start();
        
        collidr.size = new Vector2
        (
            SpriteRenderer().size.x * spaceBetween,
            collidr.size.y
        );
    }

    public BoxCollider2D BoxCollider2D()
    {
        return collidr;
    }
    void BoxCollider2D(Vector2 offset, Vector2 size)
    {
        collidr.offset = offset;
        collidr.size = size;
    }

    public float SpaceBetween()
    {
        return spaceBetween;
    }
}
