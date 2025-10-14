using DMBTools;
using UnityEngine;
using UnityEngine.InputSystem;



namespace DMBTools
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerInput))]
    public class DMB2DPlayerInput : MonoBehaviour
    {
        /*
            - Add Player Input Manager component to your player GameObject
            - Set Notification Behavior to Invoke Unity Events
            - Assign Actions to InputActions object with defined actions
            - Under Events
                - Assign the player object to the input actions used in the game
                - Assign the event to the corresponding method
        */

        private Rigidbody2D sphereRigidBody;
        private Vector2 movementInput;
        private Character playerCharacter;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            sphereRigidBody = GetComponent<Rigidbody2D>();
        }

        public void MovementInput(InputAction.CallbackContext context)
        {
            movementInput = context.ReadValue<Vector2>();
        }
        public Vector2 MovementInput()
        {
            return movementInput;
        }

        public void Sample(InputAction.CallbackContext context)
        {
            /* Event Phases
             * phases within context are
             *   - context.started
             *   - context.performed
             *   - context.canceled
            */
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
    }
}