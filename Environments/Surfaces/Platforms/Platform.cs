using UnityEngine;



[ExecuteAlways]
public class Platform : Surface
{
    public PlatformData data;

    new void Start()
    {
        base.Start();
        
        gameObject.tag = "Platform";

        dataNativeSize = data.nativeSize;
        dataLockWidth = data.lockWidth;
        dataLockHeight = data.lockHeight;
        
        Rigidbody2D().bodyType = RigidbodyType2D.Static;

        if(data.lockWidth)
        {
            BoxCollider2D().size = new Vector2
            (
                data.nativeSize.x * SpaceBetween(), 
                BoxCollider2D().size.y
            );
            SpriteRenderer().size = new Vector2
            (
                data.nativeSize.x, 
                SpriteRenderer().size.y
            );
        }
        if(data.lockHeight)
        {
            float heightDifferential = BoxCollider2D().size.y / SpriteRenderer().size.y;
            BoxCollider2D().size = new Vector2
            (
                BoxCollider2D().size.x,
                data.nativeSize.y * heightDifferential
            );
            SpriteRenderer().size= new Vector2
            (
                SpriteRenderer().size.x, 
                data.nativeSize.y
            );
        }
    }
    
}
