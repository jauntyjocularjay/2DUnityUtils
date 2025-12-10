using UnityEngine;



namespace DMBTools
{
    [ExecuteAlways]
    public abstract class ParallaxBackground : StaticBackground
    {
        [Header("Parallax Settings")]
        [Tooltip("Rate of Change dictates how the ParallaxBackgrounds move in relationship to the main camera. If the camera's position is modified on Awake (ex. by the GameManager), you need to account for this when you place your background.")]
        public Vector2 rateOfChange = Vector2.zero;
        protected Vector2 cameraInitialLocalPosition;
        protected Vector2 cameraPositionChange;
        protected Vector2 backgroundLocalPosition;

        new void Start()
        {
            base.Start();
            cameraInitialLocalPosition = ViewingCamera.transform.localPosition;
        }
        new public virtual void FixedUpdate()
        {
            Scroll();
        }

        void Scroll()
        {
            cameraPositionChange = new Vector2
            (
                ViewingCamera.transform.localPosition.x - cameraInitialLocalPosition.x,
                ViewingCamera.transform.localPosition.y + cameraInitialLocalPosition.y
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
