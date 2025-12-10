using UnityEngine;



namespace DMBTools
{
    public abstract class StaticBackground : DMBMonoBehaviour
    {
        [Tooltip("The camera will default to Camera.main unless otherwise specified.")]
        public Camera _camera;
        protected Vector2 backgroundInitialLocalPosition;
        new void Awake()
        {
            base.Awake();
            _camera = _camera ? _camera : Camera.main;
            backgroundInitialLocalPosition = new Vector2
            (
                Transform.localPosition.x,
                Transform.localPosition.y
            );
        }
        new void Start()
        {
            base.Start();
            _camera = _camera ? _camera : Camera.main;
            backgroundInitialLocalPosition = new Vector2
            (
                Transform.localPosition.x,
                Transform.localPosition.y
            );
        }
        public Camera ViewingCamera
        {
            get => _camera;
            set => _camera = value;
        }
        public virtual void FixedUpdate()
        {
            Transform.position = new Vector2
            (
                backgroundInitialLocalPosition.x + ViewingCamera.transform.localPosition.x,
                backgroundInitialLocalPosition.y + ViewingCamera.transform.localPosition.y
            );
        }
    }
}