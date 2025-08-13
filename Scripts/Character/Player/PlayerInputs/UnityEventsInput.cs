using UnityEngine;
using UnityEngine.InputSystem;


namespace DMBTools {
    public abstract class UnityEventsInput : MonoBehaviour
    {
        [SerializeField] PlayerInput playerInput;
        [SerializeField] InputActionAsset inputAction;
        [SerializeField] protected Character character;
        [SerializeField] protected Vector2 movementVector;
        public Vector2 movementSpeed = Vector2.zero;
        protected void Start()
        {
            character = GetComponent<Character>();
            playerInput = GetComponent<PlayerInput>();
            inputAction = playerInput.actions;
            playerInput.notificationBehavior = PlayerNotifications.InvokeUnityEvents;
        }
        public void MovementVector(InputAction.CallbackContext context) => movementVector = context.action.ReadValue<Vector2>();
        protected Vector2 MovementVector() => movementVector;

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