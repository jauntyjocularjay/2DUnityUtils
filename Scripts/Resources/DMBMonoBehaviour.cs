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
        public void SetPosition(Vector2 v)
        /* @method Sets the position of the Transform component using a Vector2. */
        {
            Transform.position = v;
        }

        public void SetPositionX(float f)
        /* @method Sets the Y value of the Transform's position, keeping the current X value */
        {
            Transform.position = new Vector2(f, Transform.position.y);
        }
        public void SetPositionY(float f)
        /* @method Sets the X value of the Transform's position, keeping the current Y value */
        {
            Transform.position = new Vector2(Transform.position.x, f);
        }
    }
}
