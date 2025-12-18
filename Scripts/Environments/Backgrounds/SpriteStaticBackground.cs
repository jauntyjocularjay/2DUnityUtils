using UnityEngine;

namespace DMBTools
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class StaticSpriteBackground : StaticBackground, ISpriteBackground
    {
        SpriteRenderer _spriteRenderer;
        public SpriteRenderer SpriteRenderer
        {
            get => GetComponent<SpriteRenderer>();
            set => _spriteRenderer = value;
        }
    }
}