using UnityEngine;
using UnityEngine.InputSystem;



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
        [SerializeField] protected PhysicsMaterial2D NoFrictionMaterial;
        readonly float flatSurfaceBounds = 0.8f;
        new protected void Start()
        {
            base.Start();
            player.GetComponent<Rigidbody2D>().freezeRotation = true;
            player.GetComponent<Rigidbody2D>().sharedMaterial = NoFrictionMaterial;
        }

        protected bool SurfaceIsFlat(Collision2D collision)
        {
            return Vector2.Dot(collision.GetContact(0).normal, Vector2.up) > flatSurfaceBounds;
        }

        

        protected bool AtLeastOneFlatSurface(Collision2D collision)
        {
            foreach(ContactPoint2D contact in collision.contacts)
            {
                if (Vector2.Dot(contact.normal, Vector2.up) > flatSurfaceBounds)
                {
                    return true;
                }
            }
            return false;
        }
        
    }
}