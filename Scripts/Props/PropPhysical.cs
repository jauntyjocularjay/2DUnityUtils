using UnityEngine;


namespace DMBTools
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class PhysicalProp : Prop
    /* @class Physical Prop includes the Prop class and addes getters and setters for a BoxCollider2D, Rigidbody2D */
    {
        BoxCollider2D collidr;
        Rigidbody2D rb;

        new public void Awake()
        /* @method Start() calls Prop.Start() and sets references to the BoxCollider2D and Rigidbody2D */
        {
            base.Awake();
            collidr = GetComponent<BoxCollider2D>();
            rb = GetComponent<Rigidbody2D>();
        }
        protected void Start()
        {
            rb.freezeRotation = true;
        }

        public BoxCollider2D BoxCollider2D()
        /* @method BoxCollider2D() returns the BoxCollider2D component from the GameObject */
        {
            return collidr;
        }
        void BoxCollider2DOffset(Vector2 offset)
        /* @method BoxCollider2DOffset(Vector2 offset) sets the offset of the BoxCollider2D component */
        {
            collidr.offset = offset;
        }
        void BoxCollider2DOffsetX(float x)
        /* @method BoxCollider2DOffsetX(float x) sets the X value of the BoxCollider2D's offset, keeping the current Y value */
        {
            collidr.offset = new Vector2(x, collidr.offset.y);
        }
        void BoxCollider2DOffsetY(float y)
        /* @method BoxCollider2DOffsetY(float y) sets the Y value of the BoxCollider2D's offset, keeping the current X value */
        {
            collidr.offset = new Vector2(collidr.offset.x, y);
        }
        void BoxCollider2DSize(Vector2 size)
        /* @method BoxCollider2DSize(Vector2 size) sets the size of the BoxCollider2D component */
        {
            collidr.size = size;
        }
        void BoxCollider2DSizeX(float x)
        /* @method BoxCollider2DSizeX(float x) sets the X value of the BoxCollider2D's size, keeping the current Y value */
        {
            collidr.size = new Vector2(x, collidr.size.y);
        }
        void BoxCollider2DSizeY(float y)
        /* @method BoxCollider2DSizeY(float y) sets the Y value of the BoxCollider2D's size, keeping the current X value */
        {
            collidr.size = new Vector2(collidr.size.x, y);
        }
        void BoxCollider2D(Vector2 offset, Vector2 size)
        /* @method BoxCollider2D sets both the offset and size with vectors */
        {
            BoxCollider2DOffset(offset);
            BoxCollider2DSize(size);
        }
        public Rigidbody2D Rigidbody2D()
        /* @method Rigidbody2D() returns the Rigidbody2D component from the GameObject */
        {
            return rb;
        }
    }
}
