using UnityEngine;
using UnityEngine.Tilemaps;



namespace DMBTools
{
    public abstract class MovingTilemap : MonoBehaviour, ITriggerer
    {
        TilemapRenderer _tilemapRenderer;
        TilemapRenderer TilemapRenderer
        {
            get => _tilemapRenderer;
            set => _tilemapRenderer = value;
        }
        BoxCollider2D _boxCollider2D;
        BoxCollider2D BoxCollider2D
        {
            get => _boxCollider2D;
            set => _boxCollider2D = value;
        }
        public bool isTriggered = false;
        [Tooltip("In hundreths of a Unity unit per second.")]
        public Vector2 movementVelocity = new Vector2(1f, 1f);
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public void Start()
        {
            TilemapRenderer = GetComponent<TilemapRenderer>();
            BoxCollider2D = GetComponent<BoxCollider2D>();
        }

        public void FixedUpdate()
        {
            if(isTriggered)
            {
                transform.localPosition = new Vector2
                (
                    transform.localPosition.x + movementVelocity.x / 100,
                    transform.localPosition.y + movementVelocity.y / 100
                );
            }
        }

        public void OnTriggerEnter2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Enter);
        public void OnTriggerStay2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Stay);
        public void OnTriggerExit2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Exit);

        public void HandleTrigger(Collider2D collider, TriggerType triggerType)
        {
            if(triggerType == TriggerType.Enter && collider.CompareTag(Tag.Player)) 
            {
                isTriggered = true;
            }
        }
    }
}