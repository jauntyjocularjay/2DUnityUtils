using UnityEngine;

[ExecuteAlways]
public class SurfaceFlat : Prop
{
    float spaceBetween = 0.999f; // Shrinks the width to accommodate other expanding surfaces
    BoxCollider2D collidr;
    public SurfaceFlatData data;
    [Header("Uneditable Information")]
    public Vector2 dataNativeSize;
    public bool dataLockWidth;
    public bool dataLockHeight;

    new void Start()
    {
        base.Start();
        
        dataNativeSize = data.nativeSize;
        dataLockWidth = data.lockWidth;
        dataLockHeight = data.lockHeight;
        
        collidr = GetComponent<BoxCollider2D>();
        collidr.size = new Vector2
        (
            SpriteRenderer().size.x * spaceBetween,
            collidr.size.y
        );

        if(data.lockWidth)
        {
            SpriteRenderer().size= new Vector2(data.nativeSize.x, SpriteRenderer().size.y);
        }
        if(data.lockHeight)
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
