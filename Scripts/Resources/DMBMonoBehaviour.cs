using UnityEngine;



namespace DMBTools
{
    [RequireComponent(typeof (Transform))]
    public abstract class DMBMonoBehaviour : MonoBehaviour
    {
        Transform tx;
        public void Start()
        {
            tx = GetComponent<Transform>();
        }

        public Transform Transform()
        {
            return tx;
        }
        public void Transform(Vector3 position, Quaternion rotation)
        /* @method Sets the Transform's position and rotation */
        {
            Transform().SetPositionAndRotation(position, rotation);
        }
        public void SetPosition(Vector2 v)
        /* @method Sets the position of the Transform component using a Vector2. */
        {
            Transform().position = v;
        }
        public void SetXPositionX(float f)
        /* @method Sets the X value of the Transform's position, keeping the current Y value */
        {
            Transform().position = new Vector2(f, Transform().position.y);
        }
        public void SetPositionY(float f)
        /* @method Sets the Y value of the Transform's position, keeping the current X value */
        {
            Transform().position = new Vector2(Transform().position.x, f);
        }
    }
}
