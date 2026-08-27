using UnityEngine;



namespace DMBTools
{
    [RequireComponent(typeof(Transform))]
    public abstract class DMBMonoBehaviour : MonoBehaviour
    {
        Transform _Transform;
        protected void Start()
        {
            _Transform = GetComponent<Transform>();
        }

        public Transform Transform
        {
            get => GetComponent<Transform>();
            set => _Transform = value;
        }
    }
}
