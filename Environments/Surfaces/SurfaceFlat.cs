using UnityEngine;

[ExecuteAlways]
public class SurfaceFlat : Prop
{
    float spaceBetween = 0.998f; // Shrinks the width to accommodate other expanding surfaces
    BoxCollider2D collidr;
    public SurfaceFlatData data;

    new void Start()
    {
        base.Start();
        collidr = GetComponent<BoxCollider2D>();
        collidr.size = new Vector2
        (
            SpriteRenderer().size.x * spaceBetween,
            collidr.size.y
        );

        if(data.lock_width)
        {
            SpriteRenderer().size= new Vector2(data.nativeSize.x, SpriteRenderer().size.y);
        }
        if(data.lock_height)
        {
            SpriteRenderer().size= new Vector2(SpriteRenderer().size.x, data.nativeSize.y);
        }
    }
    public Sprite Sprite()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }
    public Vector2 PivotPoint()
    {
        return Sprite().pivot;
    }
}
