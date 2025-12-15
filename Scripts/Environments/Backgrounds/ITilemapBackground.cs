using UnityEngine.Tilemaps;

public interface ITilemapBackground
{
    Tilemap Tilemap { get; set; }
    TilemapRenderer TilemapRenderer { get; set; }
}
