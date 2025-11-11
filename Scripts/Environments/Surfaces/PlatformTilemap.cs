using DMBTools;
using UnityEngine;
using UnityEngine.Tilemaps;



[RequireComponent(typeof(Tilemap))]
[RequireComponent(typeof(TilemapRenderer))]
[RequireComponent(typeof(TilemapCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlatformTilemap : DMBMonoBehaviour
{
    Tilemap tilemap;
    TilemapRenderer tilemapRenderer;
    TilemapCollider2D tilemapCollider2D;
    new Rigidbody2D rigidbody2D;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();

        tilemapRenderer = GetComponent<TilemapRenderer>();

        tilemapCollider2D = GetComponent<TilemapCollider2D>();
        tilemapCollider2D.compositeOperation = Collider2D.CompositeOperation.Merge;

        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.bodyType = RigidbodyType2D.Static;


    }

}
