using UnityEditor;
using UnityEngine;


[ExecuteAlways]
public class SurfaceFlat : Prop
{
    float spaceBetween = 0.99f; // Shrinks the width to accommodate other expanding surfaces
    public BoxCollider2D collidr;
    new void Start()
    {
        base.Start();
        collidr = GetComponent<BoxCollider2D>();
        // collidr.offset = new Vector2
        // (
        //     0,
        //     collidr.offset.y
        // ); 
        collidr.size = new Vector2
        (
            SpriteRenderer().size.x * spaceBetween,
            collidr.size.y
        );
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
