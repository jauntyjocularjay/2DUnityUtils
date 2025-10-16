using UnityEngine;
using UnityEngine.InputSystem;



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
        protected float flatSurfaceBounds = 0.8f;

        protected bool SurfaceIsFlat(Collision2D collision)
        {
            return Vector2.Dot(collision.GetContact(0).normal, Vector2.up) > flatSurfaceBounds;
        }
        
    }
}