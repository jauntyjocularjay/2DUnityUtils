using UnityEngine;


namespace DMBTools
{

    [ExecuteAlways]
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class Prop : DMBMonoBehaviour
    /* @class { Prop } and its extending classes provide ease of use in Unity. Often setting single vector values such as: GetComponent<Transform>().position = new Vector2(3, GetComponent<Transform>().position.y); becomes SetPositionX(3); */
    {
        SpriteRenderer _SpriteRenderer;
        new protected void Awake()
        {
            base.Awake();
            _SpriteRenderer = GetComponent<SpriteRenderer>();
        }

        public SpriteRenderer SpriteRenderer
        /* @method Returns the SpriteRenderer component from the GameObject */
        {
            get => _SpriteRenderer;
            set => _SpriteRenderer = value;
        }

    }
}
