using UnityEngine;



namespace DMBTools
{
    [RequireComponent(typeof(Transform))]
    public abstract class DMBMonoBehaviour : MonoBehaviour
    {
        protected Transform _Transform;
        protected void Awake()
        {
            _Transform = GetComponent<Transform>();
        }

        public Transform Transform
        {
            get => _Transform;
            set => _Transform = value;
        }
    }
}
