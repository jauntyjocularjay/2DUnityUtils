using UnityEngine;

namespace DMBTools
{
    public abstract class ParallaxBackground : Background
    {
        public Vector2 rateOfChange = Vector2.zero;
        Vector2 backgroundInitialLocalPosition;
        Vector2 cameraInitialLocalPosition;

        new void Start()
        {
            base.Start();
            backgroundInitialLocalPosition = Transform.localPosition;
            cameraInitialLocalPosition = Camera.main.transform.localPosition;
        }
        void FixedUpdate()
        {
            Scroll();
        }

        void Scroll()
        {
            Vector2 cameraPositionChange = new Vector2
            (
                Camera.main.transform.localPosition.x - cameraInitialLocalPosition.x,
                Camera.main.transform.localPosition.y + cameraInitialLocalPosition.y
            );
            Vector2 backgroundLocalPosition = new Vector2
            (
                backgroundInitialLocalPosition.x + cameraPositionChange.x,
                backgroundInitialLocalPosition.y + cameraPositionChange.y
            );
            // Camera Initial Position - The camera position is what the background positions will be based from
            Transform.localPosition = new Vector2
            (
                backgroundLocalPosition.x - (backgroundLocalPosition.x * rateOfChange.x / 10),
                backgroundLocalPosition.y - (backgroundLocalPosition.y * rateOfChange.y / 10)
            );
        }

    }

}
