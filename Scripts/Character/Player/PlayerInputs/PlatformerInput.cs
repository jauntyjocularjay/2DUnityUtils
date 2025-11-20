using UnityEngine;



namespace DMBTools
{
    public abstract class PlatformerInput : UnityEventInput
    /*
        - Add Player Input Manager component to your player GameObject
        - Set Notification Behavior to Invoke Unity Events
        - Assign Actions to InputActions object with defined actions
        - Assign the material "noFriction" to allow the character to slide on vertical or inclined surfaces.
        - Under Events
            - Assign the player object to the input actions used in the game
            - Assign the event to the corresponding method
    */
    {
        protected int jumps = 0;
        [SerializeField] protected PhysicsMaterial2D NoFrictionMaterial;
        [SerializeField] protected float flatSurfaceBounds;
        [SerializeField] protected float verticalSurfaceBounds;
        new protected void Start()
        {
            base.Start();
            player.GetComponent<Rigidbody2D>().freezeRotation = true;
            player.GetComponent<Rigidbody2D>().sharedMaterial = NoFrictionMaterial;
        }

        protected bool SurfaceIsFlat(Collision2D collision)
        {
            Vector2 vector = collision.contacts[0].normal;

            return Vector2.Dot(vector, Vector2.up) > flatSurfaceBounds;
        }

        protected bool SurfaceIsVertical(Collision2D collision)
        {
            Vector2 vector = collision.contacts[0].normal;

            return
                Vector2.Dot(vector, Vector2.right) > verticalSurfaceBounds ||
                Vector2.Dot(vector, Vector2.right) < -verticalSurfaceBounds;
        }

    }

    public abstract class Anim { }
}