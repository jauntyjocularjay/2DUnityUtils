using UnityEngine;
using UnityEngine.Tilemaps;

public interface ITilemapBackground
{
    public Camera Camera { get; set; }
    Tilemap Tilemap { get; set; }
    TilemapRenderer TilemapRenderer { get; set; }
}
