using UnityEngine;

namespace DMBTools
{
    public abstract class Background : DMBMonoBehaviour
    {
        public Vector2 rateOfChange = Vector2.one;
        Vector2 initialPosition;
        Camera mainCamera;
        Vector2 cameraInitialPosition;

        void Start()
        {
            initialPosition = new Vector2(Transform.position.x, Transform.position.y);
            mainCamera = Camera.main;
            cameraInitialPosition = mainCamera.transform.position;
        }
        void FixedUpdate()
        {
            Vector2 totalChange = new Vector2
            (
                mainCamera.transform.position.x - cameraInitialPosition.x,
                mainCamera.transform.position.y - cameraInitialPosition.y
            );
            Transform.position = new Vector2
            (
                initialPosition.x - totalChange.x * rateOfChange.x,
                initialPosition.y - totalChange.y * rateOfChange.y
            );
        }

    }

}
