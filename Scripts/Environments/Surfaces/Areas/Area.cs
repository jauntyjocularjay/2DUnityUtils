using UnityEngine;
using UnityEngine.Tilemaps;



namespace DMBTools
{
    public abstract class Area : Prop
    {
        TilemapCollider2D collidr;
        Rigidbody2D rb;

        public new void Start()
        {
            base.Start();

            SetCompositeCollider2D();
            SetRigidbody2D();

        }

        public TilemapCollider2D CompositeCollider2D()
        {
            return collidr;
        }
        void SetCompositeCollider2D()
        {
            collidr = GetComponent<TilemapCollider2D>();

            collidr.isTrigger = true;
        }
        public Rigidbody2D Rigidbody2D()
        /* @method Rigidbody2D() returns the Rigidbody2D component from the GameObject */
        {
            return rb;
        }
        public void SetRigidbody2D()
        /* @method Rigidbody2D() returns the Rigidbody2D component from the GameObject */
        {
            rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}