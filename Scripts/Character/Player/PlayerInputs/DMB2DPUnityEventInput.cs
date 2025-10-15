using UnityEngine;
using UnityEngine.InputSystem;



namespace DMBTools
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Character))]
    public abstract class DMBUnityEventInput2D : MonoBehaviour
    {
        /*
            - Add Player Input Manager component to your player GameObject
            - Set Notification Behavior to Invoke Unity Events
            - Assign Actions to InputActions object with defined actions
            - Under Events
                - Assign the player object to the input actions used in the game
                - Assign the event to the corresponding method
        */
        private Vector2 movementInput;
        void OnCollisionEnter2D(Collision2D collision) => HandleCollision(collision, CollisionType.Enter);
        void OnCollisionStay2D(Collision2D collision) => HandleCollision(collision, CollisionType.Stay);
        void OnCollisionExit2D(Collision2D collision) => HandleCollision(collision, CollisionType.Exit);
        public abstract void HandleCollision(Collision2D collision, CollisionType type);
        void OnTriggerEnter2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Enter);
        void OnTriggerStay2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Stay);
        void OnTriggerExit2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Exit);
        public abstract void HandleTrigger(Collider2D collider, TriggerType type);
        public void MovementInput(InputAction.CallbackContext context) => movementInput = context.ReadValue<Vector2>();
        public Vector2 MovementVector()
        {
            Debug.Log($"MovementInput: {movementInput}");
            return movementInput;
        }
        /*
        public void Sample(InputAction.CallbackContext context)
        {
        * Event Phases
        * phases within context are
        *   - context.started
        *   - context.performed
        *   - context.canceled
        *
            if (context.started)
            {
            }
            if (context.performed)
            {
            }
            if (context.canceled)
            {
            }
        }
        */

    }
}