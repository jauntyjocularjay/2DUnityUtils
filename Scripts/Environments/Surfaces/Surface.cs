using UnityEngine;


namespace DMBTools
{
    [ExecuteAlways]
    public abstract class Surface : PhysicalProp
    {
        readonly float spaceBetween = 0.999f; // Shrinks the width to accommodate other expanding surfaces

        public SurfaceData data;
        [Header("Uneditable Information")]
        public Vector2 dataNativeSize;
        public bool dataLockWidth;
        public bool dataLockHeight;


        new public void Awake()
        {
            base.Awake();

            Rigidbody2D().bodyType = RigidbodyType2D.Static;

            BoxCollider2D().size = new Vector2
            (
                SpriteRenderer().size.x * spaceBetween,
                BoxCollider2D().size.y
            );
        }

        public float SpaceBetween()
        {
            return spaceBetween;
        }
    }
}
