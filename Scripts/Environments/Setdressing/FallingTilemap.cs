using UnityEngine;
using UnityEngine.Tilemaps;
using DMBTools;

public class FallingTilemap : DMBMonoBehaviour
{
    TilemapRenderer _tilemapRenderer;
    TilemapRenderer TilemapRenderer
    {
        get => _tilemapRenderer;
        set => _tilemapRenderer = value;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public new void Start()
    {
        base.Start();
        TilemapRenderer = GetComponent<TilemapRenderer>();        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
