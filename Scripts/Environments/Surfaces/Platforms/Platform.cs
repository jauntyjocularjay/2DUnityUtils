using UnityEngine;



namespace DMBTools
{
    [ExecuteAlways]
    public abstract class Platform : Surface
    {
        new public void Awake()
        {
            base.Awake();

            gameObject.tag = "Platform";

            dataNativeSize = data.nativeSize;
            dataLockWidth = data.lockWidth;
            dataLockHeight = data.lockHeight;

            if (data.lockWidth && SpriteRenderer().size.x > data.nativeSize.x)
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

            if (data.lockHeight && SpriteRenderer().size.y > data.nativeSize.y)
            {
                float heightDifferential = BoxCollider2D().size.y / SpriteRenderer().size.y;
                BoxCollider2D().size = new Vector2
                (
                    BoxCollider2D().size.x,
                    data.nativeSize.y * heightDifferential
                );
                SpriteRenderer().size = new Vector2
                (
                    SpriteRenderer().size.x,
                    data.nativeSize.y
                );
            }
        }

    }
}