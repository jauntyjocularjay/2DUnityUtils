using UnityEngine;



namespace DMBTools
{
    public abstract class PlatformerInput : UnityEventInput
    /*
        - Add Player Input Manager component to your player GameObject
        - Set Notification Behavior to Invoke Unity Events
        - Assign Actions to InputActions object with defined actions
        - Under Events
            - Assign the player object to the input actions used in the game
            - Assign the event to the corresponding method
    */
    {
        protected int jumps = 0;
        [SerializeField] protected float flatSurfaceBounds;
        [SerializeField] protected float verticalSurfaceBounds;
        new protected void Start()
        {
            base.Start();
            player.GetComponent<Rigidbody2D>().freezeRotation = true;
        }

        protected bool SurfaceIsFlat(Collision2D collision)
        {
            Vector2 normal;

            foreach (ContactPoint2D contact in collision.contacts)
            {
                normal = contact.normal;

                if (Vector2.Dot(normal, Vector2.up) > flatSurfaceBounds)
                {
                    return true;
                }
            }

            return false;

            // Vector2 vector = collision.contacts[0].normal;
            // return Vector2.Dot(vector, Vector2.up) > flatSurfaceBounds;
        }

        protected bool SurfaceIsVertical(Collision2D collision)
             => Vector2.Dot(collision.contacts[0].normal, Vector2.right) > verticalSurfaceBounds ||
                Vector2.Dot(collision.contacts[0].normal, Vector2.right) < -verticalSurfaceBounds;

    }

    public abstract class Anim { }
}