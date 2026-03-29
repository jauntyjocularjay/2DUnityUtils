using UnityEngine;


namespace DMBTools
{
    [ExecuteAlways]
    public abstract class Surface : PhysicalProp
    {
        readonly float spaceBetween = 0.999f; // Shrinks the width to accommodate other expanding surfaces

        public SurfaceData data;
        
        [Space(10)]
        [SerializeField] private SurfaceDataPreview preview;


        new public void Start()
        {
            base.Start();
            
            // Update preview struct for inspector visibility
            if (data != null)
            {
                preview = new SurfaceDataPreview
                {
                    nativeSize = data.nativeSize,
                    lockWidth = data.lockWidth,
                    lockHeight = data.lockHeight
                };
            }

            Rigidbody2D.bodyType = RigidbodyType2D.Static;

            BoxCollider2D.size = new Vector2
            (
                SpriteRenderer.size.x * spaceBetween,
                BoxCollider2D.size.y
            );
        }

        public float SpaceBetween()
        {
            return spaceBetween;
        }
    }

    [System.Serializable]
    public struct SurfaceDataPreview
    {
        [Header("📊 Current Data Values")]
        [ReadOnly, Tooltip("Read-only preview of data.nativeSize")]
        public Vector2 nativeSize;
        
        [ReadOnly, Tooltip("Read-only preview of data.lockWidth")]
        public bool lockWidth;
        
        [ReadOnly, Tooltip("Read-only preview of data.lockHeight")]
        public bool lockHeight;
    }
}
