using UnityEngine;

namespace DMBTools
{
    public abstract class Background : DMBMonoBehaviour
    {
        [Tooltip("The camera will default to Camera.main unless otherwise specified.")]
        public Camera _camera;
        public Camera Camera
        {
            get => Camera.main;
            set => _camera = value;
        }
        protected Vector2 backgroundInitialLocalPosition;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        new protected void Start()
        {
            base.Start();
            backgroundInitialLocalPosition = Transform.position;
            Camera ??= Camera.main; // set the camera to the main camera if it is
        }

    }

}
