using UnityEngine;



namespace DMBTools
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteParallaxBackground : ParallaxBackground, ISpriteBackground
    {

        SpriteRenderer _spriteRenderer;
        public SpriteRenderer SpriteRenderer
        {
            get => _spriteRenderer;
            set => _spriteRenderer = value;
        }

        new public void Start()
        {
            base.Start();
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }

    }

}
