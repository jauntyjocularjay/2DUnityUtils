using UnityEngine;
using UnityEngine.InputSystem;



namespace DMBTools
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Character))]
    public abstract class UnityEventInput : MonoBehaviour
    {
        Character character;
        [SerializeField] Vector2 _movementInput;
        /*
            - Add Player Input Manager component to your player GameObject
            - Set Notification Behavior to Invoke Unity Events
            - Assign Actions to InputActions object with defined actions
            - Under Events
                - Assign the player object to the input actions used in the game
                - Assign the event to the corresponding method
        */
        protected void Start()
        {
            character = GetComponent<Character>();
            character.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        public void MovementInput(InputAction.CallbackContext context)
            => _movementInput = context.ReadValue<Vector2>();
        public void ResetMovementInput()
        {
            MovementVector = _movementInput;
        }
        public Vector2 MovementVector
        {
            get => _movementInput;
            set => _movementInput = value;
        }
        public bool ResetMovementVectorX()
            => _movementInput.x == 0.0f;
        public bool ResetMovementVectorY()
            => _movementInput.y == 0.0f;

        void OnAction(InputAction.CallbackContext context)
        {
            //   Event Phases
            //   phases within context are
            //     - context.started
            //     - context.performed
            //     - context.canceled
        }

    }
}