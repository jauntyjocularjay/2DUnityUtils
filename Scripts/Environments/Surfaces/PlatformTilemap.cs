using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace DMBTools {
    [RequireComponent(typeof(Tilemap))]
    [RequireComponent(typeof(TilemapRenderer))]
    [RequireComponent(typeof(TilemapCollider2D))]
    [RequireComponent(typeof(CompositeCollider2D))]
    [RequireComponent(typeof(PlatformEffector2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class DMBPlatformTilemap : MonoBehaviour
    {
        Tilemap _tilemap;
        protected Tilemap Tilemap { get; set; }
        TilemapRenderer _tilemapRenderer;
        protected TilemapRenderer TilemapRenderer {get; set;}
        TilemapCollider2D _tilemapCollider2D;
        protected TilemapCollider2D TilemapCollider2D {get; set;}
        CompositeCollider2D _compositeCollider2D;
        public CompositeCollider2D CompositeCollider2D {get; set;}
        public Vector2 compositeColliderOffset = new Vector2(0,-0.02f);
        PlatformEffector2D _platformEffector2D;
        public PlatformEffector2D PlatformEffector2D { get; set; }
        public bool oneWayPlatform;
        Rigidbody2D _rigidbody2D;
        public Rigidbody2D Rigidbody2D { get; set; }

        protected void Start()
        {
            Tilemap = GetComponent<Tilemap>();
    
            TilemapRenderer = GetComponent<TilemapRenderer>();
    
            TilemapCollider2D = GetComponent<TilemapCollider2D>();
            TilemapCollider2D.compositeOperation = Collider2D.CompositeOperation.Merge;

            CompositeCollider2D = GetComponent<CompositeCollider2D>();
            CompositeCollider2D.offset = compositeColliderOffset;
            CompositeCollider2D.usedByEffector = oneWayPlatform;

            PlatformEffector2D = GetComponent<PlatformEffector2D>();
            PlatformEffector2D.useColliderMask = false;
            PlatformEffector2D.useOneWay = oneWayPlatform;

            Rigidbody2D = GetComponent<Rigidbody2D>();
            Rigidbody2D.bodyType = RigidbodyType2D.Static;
        }

    }
}