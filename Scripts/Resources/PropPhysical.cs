using UnityEngine;


namespace DMBTools
{
    public abstract class PhysicalProp : Prop
    {
        BoxCollider2D collidr;
        Rigidbody2D rb;

        new public void Start()
        {
            base.Start();
            collidr = GetComponent<BoxCollider2D>();
            rb = GetComponent<Rigidbody2D>();
        }

        public BoxCollider2D BoxCollider2D()
        {
            return collidr;
        }
        void BoxCollider2D(Vector2 offset, Vector2 size)
        {
            collidr.offset = offset;
            collidr.size = size;
        }

        public Rigidbody2D Rigidbody2D()
        {
            return rb;
        }
    }
}
