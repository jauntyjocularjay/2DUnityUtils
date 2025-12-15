using UnityEngine;



namespace DMBTools
{
    public abstract class StaticBackground : Background
    {
        public void FixedUpdate()
        {
            MoveWithCamera();
        }
        void MoveWithCamera()
        {
            Transform.position = new Vector2
            (
                backgroundInitialLocalPosition.x + Camera.transform.localPosition.x,
                backgroundInitialLocalPosition.y + Camera.transform.localPosition.y
            );
        }

    }
}