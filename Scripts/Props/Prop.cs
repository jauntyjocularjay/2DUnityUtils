using UnityEngine;


namespace DMBTools
{

    [ExecuteAlways]
    public abstract class Prop : MonoBehaviour
    /* @class { Prop } and its extending classes provide ease of use in Unity. Often setting single vector values such as:
            GetComponent<Transform>().position = new Vector2(3, GetComponent<Transform>().position.y);
            becomes
            SetPositionX(3);
    */
    {
        Transform tx;
        SpriteRenderer sr;


        public void Start()
        /* @method Attaches the Transform, SpriteRenderer components to variables for later fetching. */
        {
            tx = GetComponent<Transform>();
            sr = GetComponent<SpriteRenderer>();
        }

        public Transform Transform()
        /* @method Returns the Transform component from the GameObject */
        {
            return tx;
        }

        public void SetPosition(Vector2 v)
        /* @method Sets the position of the Transform component using a Vector2. */
        {
            tx.position = v;
        }
        public void SetXPositionX(float f)
        /* @method Sets the X value of the Transform's position, keeping the current Y value */
        {
            tx.position = new Vector2(f, tx.position.y);
        }

        public void SetPositionY(float f)
        /* @method Sets the Y value of the Transform's position, keeping the current X value */
        {
            tx.position = new Vector2(tx.position.x, f);
        }

        public void SetTransform(Vector3 position, Quaternion rotation)
        /* @method Sets the Transform's position and rotation */
        {
            Transform().SetPositionAndRotation(position, rotation);
        }

        public SpriteRenderer SpriteRenderer()
        /* @method Returns the SpriteRenderer component from the GameObject */
        {
            return sr;
        }
        public void SetSprite(Sprite sprite)
        /* @method Sets the sprite of the SpriteRenderer component */
        {
            sr.sprite = sprite;
        }

        public Sprite Sprite()
        /* @method Gets the current sprite assigned to the SpriteRenderer */
        {
            return sr.sprite;
        }
        public Vector2 PivotPoint()
        /* @method Gets the pivot point of the current sprite */
        {
            return sr.sprite.pivot;
        }

    }
}
