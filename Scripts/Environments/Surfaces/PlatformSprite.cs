using UnityEngine;
using UnityEngine.Tilemaps;


namespace DMBTools {
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class DMBSpritePlatform : MonoBehaviour
    {
        // SpriteRenderer spriteRenderer;
        BoxCollider2D boxCollider2D;
        public Vector2 compositeColliderOffset = new Vector2(0,-0.02f);
    
        protected void Start()
        {
            // spriteRenderer = GetComponent<SpriteRenderer>();

            boxCollider2D = GetComponent<BoxCollider2D>();
            boxCollider2D.compositeOperation = Collider2D.CompositeOperation.Merge;
            boxCollider2D.offset += compositeColliderOffset;
        }
    
    }
}