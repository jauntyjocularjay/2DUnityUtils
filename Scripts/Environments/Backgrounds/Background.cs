using UnityEngine;

namespace DMBTools
{
    public abstract class Background : MonoBehaviour
    {
        [Tooltip("The camera will default to Camera.main unless otherwise specified.")]
        public Camera _camera;
        public Camera Camera
        {
            get => _camera;
            set => _camera = value;
        }
        protected Vector2 backgroundInitialLocalPosition;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        protected void Start()
        {
            backgroundInitialLocalPosition = transform.position;
            if(Camera == null) Camera = Camera.main; // set the camera to the main camera if it is
        }

    }

}
