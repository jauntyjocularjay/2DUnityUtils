using UnityEngine;
using UnityEngine.Tilemaps;


namespace DMBTools {
    [RequireComponent(typeof(Tilemap))]
    [RequireComponent(typeof(TilemapRenderer))]
    [RequireComponent(typeof(TilemapCollider2D))]
    [RequireComponent(typeof(CompositeCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class DMBPlatformTilemap : MonoBehaviour
    {
        Tilemap tilemap;
        TilemapRenderer tilemapRenderer;
        TilemapCollider2D tilemapCollider2D;
        CompositeCollider2D compositeCollider2D;
        public Vector2 compositeColliderOffset = new Vector2(0,-0.02f);
        Rigidbody2D _rigidbody2D;
    
        protected void Start()
        {
            tilemap = GetComponent<Tilemap>();
    
            tilemapRenderer = GetComponent<TilemapRenderer>();
    
            tilemapCollider2D = GetComponent<TilemapCollider2D>();
            tilemapCollider2D.compositeOperation = Collider2D.CompositeOperation.Merge;

            compositeCollider2D = GetComponent<CompositeCollider2D>();
            compositeCollider2D.offset = compositeColliderOffset;
    
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.bodyType = RigidbodyType2D.Static;
        }
    
    }
}