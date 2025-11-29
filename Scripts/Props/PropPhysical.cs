using UnityEngine;


namespace DMBTools
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class PhysicalProp : Prop
    /* @class Physical Prop includes the Prop class and addes getters and setters for a BoxCollider2D, Rigidbody2D */
    {
        BoxCollider2D _BoxCollider2D;
        Rigidbody2D _Rigidbody2D;
        new protected void Awake()
        {
            _BoxCollider2D = GetComponent<BoxCollider2D>();
            _Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        protected void Start()
        /* @method Start() calls Prop.Start() and sets references to the BoxCollider2D and Rigidbody2D */
        {
            Rigidbody2D.freezeRotation = true;
        }

        public BoxCollider2D BoxCollider2D
        /* @method BoxCollider2D() returns the BoxCollider2D component from the GameObject */
        {
            get => _BoxCollider2D;
            set => _BoxCollider2D = value;
        }
        public Rigidbody2D Rigidbody2D
        {
            get => _Rigidbody2D;
            set => _Rigidbody2D = value;
        }
    }
}
