using UnityEngine;



namespace DMBTools
{

    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class DestroyableProp : AnimatedProp, ICollisioner
    {
        BoxCollider2D _BoxCollider2D;
        public GameObject itemPrefab;
        new protected void Start()
        {
            base.Start();
            _BoxCollider2D = GetComponent<BoxCollider2D>();
        }
        public BoxCollider2D BoxCollider2D
        {
            get => GetComponent<BoxCollider2D>();
            set => BoxCollider2D = value;
        }
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
