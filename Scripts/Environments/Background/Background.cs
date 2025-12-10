using UnityEngine;



namespace DMBTools
{
    public abstract class Background : DMBMonoBehaviour
    {
        protected Vector2 backgroundInitialPosition;
        new void Start()
        {
            base.Start();
            backgroundInitialPosition = new Vector2
            (
                Transform.position.x,
                Transform.position.y
            );
        }
        void FixedUpdate()
        {
            Transform.position = new Vector2
            (
                backgroundInitialPosition.x + Camera.main.transform.position.x,
                backgroundInitialPosition.y + Camera.main.transform.position.y
            );
        }
    }
}