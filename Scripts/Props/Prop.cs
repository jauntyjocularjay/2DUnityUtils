using UnityEngine;


namespace DMBTools
{

    [ExecuteAlways]
    [RequireComponent(typeof (SpriteRenderer))]
    public abstract class Prop : DMBMonoBehaviour
    /* @class { Prop } and its extending classes provide ease of use in Unity. Often setting single vector values such as: GetComponent<Transform>().position = new Vector2(3, GetComponent<Transform>().position.y); becomes SetPositionX(3); */
    {
        SpriteRenderer sr;

        new protected void Awake()
        /* @method Attaches the Transform, SpriteRenderer components to variables for later fetching. */
        {
            base.Awake();
            sr = GetComponent<SpriteRenderer>();
        }

        public SpriteRenderer SpriteRenderer()
        /* @method Returns the SpriteRenderer component from the GameObject */
        {
            return sr;
        }
    }
}
