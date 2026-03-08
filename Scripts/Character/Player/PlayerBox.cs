using UnityEngine;



namespace DMBTools
{
    public abstract class BoxPlayer : BoxCharacter
    {
        public BoxPlayerData data;
        new protected void Awake()
        {
            base.Awake();
        }
        new protected void Start()
        {
            base.Start();
            SpriteRenderer.sortingLayerID = data.sortingLayerID;
            SpriteRenderer.sortingOrder = data.sortingOrder;

            BoxCollider2D.offset = data.colliderOffset;
            BoxCollider2D.size = data.colliderSize;
            BoxCollider2D.edgeRadius = data.colliderEdgeRadius;

            Rigidbody2D.mass = data.mass;
            Rigidbody2D.gravityScale = data.gravityScale;

            HP = data.MaxHP;
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
    }
}
