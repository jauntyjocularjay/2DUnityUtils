using UnityEngine;


namespace DMBTools
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class PhysicalProp : Prop
    /* @class Physical Prop includes the Prop class and addes getters and setters for a BoxCollider2D, Rigidbody2D */
    {
        BoxCollider2D _BoxCollider2D;
        Rigidbody2D _RigidBody;

        new protected void Start()
        /* @method Start() calls Prop.Start() and sets references to the BoxCollider2D and Rigidbody2D */
        {
            base.Start();
            _BoxCollider2D = GetComponent<BoxCollider2D>();
            _RigidBody = GetComponent<Rigidbody2D>();
            _RigidBody.freezeRotation = true;
        }

        public BoxCollider2D BoxCollider2D
        /* @method BoxCollider2D() returns the BoxCollider2D component from the GameObject */
        {
            get => _BoxCollider2D;
        }
        void BoxCollider2DOffset(Vector2 offset)
        /* @method BoxCollider2DOffset(Vector2 offset) sets the offset of the BoxCollider2D component */
        {
            _BoxCollider2D.offset = offset;
        }
        void BoxCollider2DOffsetX(float x)
        /* @method BoxCollider2DOffsetX(float x) sets the X value of the BoxCollider2D's offset, keeping the current Y value */
        {
            _BoxCollider2D.offset = new Vector2(x, _BoxCollider2D.offset.y);
        }
        void BoxCollider2DOffsetY(float y)
        /* @method BoxCollider2DOffsetY(float y) sets the Y value of the BoxCollider2D's offset, keeping the current X value */
        {
            _BoxCollider2D.offset = new Vector2(_BoxCollider2D.offset.x, y);
        }
        void BoxCollider2DSize(Vector2 size)
        /* @method BoxCollider2DSize(Vector2 size) sets the size of the BoxCollider2D component */
        {
            _BoxCollider2D.size = size;
        }
        void BoxCollider2DSizeX(float x)
        /* @method BoxCollider2DSizeX(float x) sets the X value of the BoxCollider2D's size, keeping the current Y value */
        {
            _BoxCollider2D.size = new Vector2(x, _BoxCollider2D.size.y);
        }
        void BoxCollider2DSizeY(float y)
        /* @method BoxCollider2DSizeY(float y) sets the Y value of the BoxCollider2D's size, keeping the current X value */
        {
            _BoxCollider2D.size = new Vector2(_BoxCollider2D.size.x, y);
        }
        void BoxCollider2DOffsetSize(Vector2 offset, Vector2 size)
        /* @method BoxCollider2D sets both the offset and size with vectors */
        {
            BoxCollider2DOffset(offset);
            BoxCollider2DSize(size);
        }
        public Rigidbody2D Rigidbody2D()
        /* @method Rigidbody2D() returns the Rigidbody2D component from the GameObject */
        {
            return _RigidBody;
        }
    }
}
