using UnityEngine;
using UnityEngine.Tilemaps;


namespace DMBTools {
    [RequireComponent(typeof(Tilemap))]
    [RequireComponent(typeof(TilemapRenderer))]
    [RequireComponent(typeof(TilemapCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlatformTilemap : MonoBehaviour
    {
        Tilemap tilemap;
        TilemapRenderer tilemapRenderer;
        TilemapCollider2D tilemapCollider2D;
        Rigidbody2D _rigidbody2D;
    
        protected void Start()
        {
            tilemap = GetComponent<Tilemap>();
    
            tilemapRenderer = GetComponent<TilemapRenderer>();
    
            tilemapCollider2D = GetComponent<TilemapCollider2D>();
            tilemapCollider2D.compositeOperation = Collider2D.CompositeOperation.Merge;
    
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.bodyType = RigidbodyType2D.Static;
        }
    
    }
}