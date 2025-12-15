using UnityEngine;



namespace DMBTools
{
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class SpriteParallaxBackground : ParallaxBackground, ISpriteBackground
    {

        SpriteRenderer _spriteRenderer;
        public SpriteRenderer SpriteRenderer
        {
            get => GetComponent<SpriteRenderer>();
            set => _spriteRenderer = value;
        }

    }

}
