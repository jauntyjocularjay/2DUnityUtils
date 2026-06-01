using UnityEngine;
using UnityEngine.Tilemaps;

namespace DMBTools
{
    [RequireComponent(typeof(Tilemap))]
    [RequireComponent(typeof(TilemapRenderer))]
    public class TilemapParallaxBackground : ParallaxBackground, ITilemapBackground
    {
        Tilemap _tilemap;
        public Tilemap Tilemap
        {
            get => GetComponent<Tilemap>();
            set => _tilemap = value;
        }
        TilemapRenderer _tilemapRenderer;
        public TilemapRenderer TilemapRenderer
        {
            get => GetComponent<TilemapRenderer>();
            set => _tilemapRenderer = value;
        }
    }
}