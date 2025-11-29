using UnityEngine;
using UnityEngine.Tilemaps;



namespace DMBTools
{
    public abstract class Area : Prop
    {
        TilemapCollider2D collidr;
        Rigidbody2D rb;

        new protected void Awake()
        {
            collidr = GetComponent<TilemapCollider2D>();
            rb = GetComponent<Rigidbody2D>();
        }
        new protected void Start()
        {
            collidr.isTrigger = true;
            rb.bodyType = RigidbodyType2D.Static;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        public TilemapCollider2D CompositeCollider2D()
        {
            return collidr;
        }
        public Rigidbody2D Rigidbody2D()
        /* @method Rigidbody2D() returns the Rigidbody2D component from the GameObject */
        {
            return rb;
        }
        public void SetRigidbody2D()
        /* @method Rigidbody2D() returns the Rigidbody2D component from the GameObject */
        {
        }
    }
}