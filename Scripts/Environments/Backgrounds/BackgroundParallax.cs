using UnityEngine;



namespace DMBTools
{
    public abstract class ParallaxBackground : Background
    {
        [Header("Parallax Settings")]
        [Tooltip("Rate of Change dictates how the ParallaxBackgrounds move in relationship to the main camera. If the camera's position is modified on Awake (ex. by the GameManager), you need to account for this when you place your background.")]
        public Vector2 rateOfChange = Vector2.one;
        protected Vector2 cameraInitialLocalPosition;
        protected Vector2 cameraPositionChange;
        protected Vector2 backgroundLocalPosition;
        public bool lock_x = false;
        public bool lock_y = false;

        new void Start()
        {
            base.Start();
            if(Camera == null)
            {
                Camera = Camera.main;
            }
            
            cameraInitialLocalPosition = new Vector2
            (
                Camera.transform.localPosition.x, 
                Camera.transform.localPosition.y
            );
            //cameraInitialLocalPosition = CameraInfo.camera_initial_position;

        }

        void FixedUpdate()
        {
            Scroll();
        }

        void Scroll()
        {
            cameraPositionChange = new Vector2
            (
                !lock_x ? Camera.transform.localPosition.x - cameraInitialLocalPosition.x : 0.0f,
                !lock_y ? Camera.transform.localPosition.y - cameraInitialLocalPosition.y : 0.0f
            );

            backgroundLocalPosition = new Vector2
            (
                backgroundInitialLocalPosition.x + cameraPositionChange.x,
                backgroundInitialLocalPosition.y + cameraPositionChange.y
            );

            // Camera Initial Position - The camera position is what the background positions will be based from
            transform.localPosition = new Vector2
            (
                backgroundLocalPosition.x - (cameraPositionChange.x * rateOfChange.x),
                backgroundLocalPosition.y - (cameraPositionChange.y * rateOfChange.y)
            );
        }

    }
}
