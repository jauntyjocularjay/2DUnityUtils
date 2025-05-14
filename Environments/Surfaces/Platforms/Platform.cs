using UnityEngine;

[ExecuteAlways]
public class Platform : Surface
{
    public PlatformData data;

    new void Start()
    {
        base.Start();
        
        gameObject.tag = "Platform";

        base.dataNativeSize = data.nativeSize;
        base.dataLockWidth = data.lockWidth;
        base.dataLockHeight = data.lockHeight;

        Rigidbody2D().bodyType = RigidbodyType2D.Static;

        if(data.lockWidth)
        {
            SpriteRenderer().size= new Vector2(data.nativeSize.x, SpriteRenderer().size.y);
        }
        if(data.lockHeight)
        {
            SpriteRenderer().size= new Vector2(SpriteRenderer().size.x, data.nativeSize.y);
        }
    }
    
}
