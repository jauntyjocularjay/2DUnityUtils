using UnityEngine;
using UnityEngine.InputSystem;



namespace DMBTools
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(BoxPlayer))]
    public abstract class UnityEventInput : MonoBehaviour
    {
        [SerializeField] protected BoxPlayer player;
        [SerializeField] protected Fan flags;
        [SerializeField] Vector2 movementInput;
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
            player = GetComponent<BoxPlayer>();
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        void OnCollisionEnter2D(Collision2D collision)
            => HandleCollision(collision, CollisionType.Enter);
        void OnCollisionStay2D(Collision2D collision)
            => HandleCollision(collision, CollisionType.Stay);
        void OnCollisionExit2D(Collision2D collision)
            => HandleCollision(collision, CollisionType.Exit);
        void OnTriggerEnter2D(Collider2D collider)
            => HandleTrigger(collider, TriggerType.Enter);
        void OnTriggerStay2D(Collider2D collider)
            => HandleTrigger(collider, TriggerType.Stay);
        void OnTriggerExit2D(Collider2D collider)
            => HandleTrigger(collider, TriggerType.Exit);
        public abstract void HandleCollision(Collision2D collision, CollisionType type);
        public abstract void HandleTrigger(Collider2D collider, TriggerType type);
        public void MovementInput(InputAction.CallbackContext context)
            => movementInput = context.ReadValue<Vector2>();
        public void ResetMovementInput()
            => MovementVector(movementInput);
        protected Vector2 MovementVector(Vector2 vector2)
            => movementInput = vector2;
        protected Vector2 MovementVector()
            => movementInput;
        protected bool MovementVectorXZero()
            => movementInput.x == 0.0f;
        protected bool MovementVectorYZero()
            => movementInput.y == 0.0f;

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