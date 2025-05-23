using UnityEngine;


namespace DMBTools
{

    [ExecuteAlways]
    public class Prop : MonoBehaviour
    {
        Transform tx;
        SpriteRenderer sr;


        public void Start()
        {
            tx = GetComponent<Transform>();
            sr = GetComponent<SpriteRenderer>();
        }

        public Transform Transform()
        {
            return tx;
        }

        public void SetPosition(Vector2 v)
        {
            tx.position = v;
        }
        public void SetXPositionX(float f)
        {
            tx.position = new Vector2(f, tx.position.y);
        }

        public void SetPositionY(float f)
        {
            tx.position = new Vector2(tx.position.x, f);
        }

        public void SetTransform(Vector3 position, Quaternion rotation)
        {
            Transform().SetPositionAndRotation(position, rotation);
        }

        public SpriteRenderer SpriteRenderer()
        {
            return sr;
        }
        public void SetSprite(Sprite sprite)
        {
            sr.sprite = sprite;
        }

        public Sprite Sprite()
        {
            return sr.sprite;
        }
        public Vector2 PivotPoint()
        {
            return sr.sprite.pivot;
        }

    }
}
