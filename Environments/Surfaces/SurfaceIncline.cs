using UnityEngine;



public class SurfaceIncline : Prop
{
    public PolygonCollider2D collidr;
    new void Start()
    {
        base.Start();
        float width = SpriteRenderer().size.x;
        collidr = GetComponent<PolygonCollider2D>();
        collidr.autoTiling = true;
    }

}
