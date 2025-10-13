using UnityEngine;
using UnityEngine.InputSystem;


namespace DMBTools
{
    [RequireComponent(typeof(Character))]
    [RequireComponent(typeof(PlayerInput))]
    public abstract class UnityEventsInput : MonoBehaviour
    {
        [SerializeField] PlayerInput playerInput;
        [SerializeField] InputActionAsset inputAction;
        [SerializeField] protected Character character;
        [SerializeField] protected Vector3 movementVector;
        protected void Start()
        {
            character = GetComponent<Character>();
            playerInput = GetComponent<PlayerInput>();
            playerInput.actions = inputAction;
            /*
                @todo Learn how to do this:
                    Disable all actions maps *done*
                    Enable specific action map "Player"
            */
            // playerInput.actions.Disable();
            // playerInput.actions.
            playerInput.notificationBehavior = PlayerNotifications.InvokeUnityEvents;
        }
        public void MovementVector(InputAction.CallbackContext context)
        // Don't forget to setup Events in PlayerInput
            => movementVector = context.action.ReadValue<Vector2>();
        protected Vector2 MovementVector()
            => movementVector;

        void OnCollisionEnter2D(Collision2D collision) => HandleCollision(collision, CollisionType.Enter);
        void OnCollisionStay2D(Collision2D collision) => HandleCollision(collision, CollisionType.Stay);
        void OnCollisionExit2D(Collision2D collision) => HandleCollision(collision, CollisionType.Exit);
        public abstract void HandleCollision(Collision2D collision, CollisionType collisionType);

        void OnTriggerEnter2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Enter);
        void OnTriggerStay2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Stay);
        void OnTriggerExit2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Exit);
        public abstract void HandleTrigger(Collider2D collider, TriggerType triggerType);


    }
}
