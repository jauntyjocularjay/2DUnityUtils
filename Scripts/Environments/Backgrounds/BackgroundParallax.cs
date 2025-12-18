using UnityEngine;



namespace DMBTools
{
    public abstract class ParallaxBackground : Background
    {
        [Header("Parallax Settings")]
        [Tooltip("Rate of Change dictates how the ParallaxBackgrounds move in relationship to the main camera. If the camera's position is modified on Awake (ex. by the GameManager), you need to account for this when you place your background.")]
        public Vector2 rateOfChange = Vector2.zero;
        protected Vector2 cameraInitialLocalPosition;
        protected Vector2 cameraPositionChange;
        protected Vector2 backgroundLocalPosition;
        public CameraInfo CameraInfo
        {
            get => Camera.main.GetComponent<CameraInfo>();
            set => CameraInfo = value;
        }

        new void Start()
        {
            base.Start();
            cameraInitialLocalPosition = CameraInfo.camera_initial_position;

        }

        void FixedUpdate()
        {
            Scroll();
        }

        void Scroll()
        {
            cameraPositionChange = new Vector2
            (
                Camera.transform.localPosition.x - cameraInitialLocalPosition.x,
                Camera.transform.localPosition.y - cameraInitialLocalPosition.y
            );
            backgroundLocalPosition = new Vector2
            (
                backgroundInitialLocalPosition.x + cameraPositionChange.x,
                backgroundInitialLocalPosition.y + cameraPositionChange.y
            );
            // Camera Initial Position - The camera position is what the background positions will be based from
            Transform.localPosition = new Vector2
            (
                backgroundLocalPosition.x - (cameraPositionChange.x * rateOfChange.x / 10),
                backgroundLocalPosition.y - (cameraPositionChange.y * rateOfChange.y / 10)
            );
        }

    }
}