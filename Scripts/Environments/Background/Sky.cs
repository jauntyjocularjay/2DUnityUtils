using UnityEngine;



namespace DMBTools
{
    public abstract class Sky : DMBMonoBehaviour
    {
        Camera mainCamera;
        Vector2 initialPosition;
        void Start()
        {
            mainCamera = Camera.main;
            initialPosition = new Vector2
            (
                Transform.position.x,
                Transform.position.y
            );
        }
        void FixedUpdate()
        {
            Transform.position = new Vector2
            (
                initialPosition.x + mainCamera.transform.position.x,
                initialPosition.y + mainCamera.transform.position.y
            );
        }
    }
}