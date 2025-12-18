using UnityEngine;



namespace DMBTools
{

    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class DestroyableProp : AnimatedProp
    {
        BoxCollider2D _BoxCollider2D;
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
        void OnCollisionEnter2D(Collision2D collision) => HandleCollision(collision, TriggerType.Enter);
        void OnCollisionStay2D(Collision2D collision) => HandleCollision(collision, TriggerType.Stay);
        void OnCollisionExit2D(Collision2D collision) => HandleCollision(collision, TriggerType.Exit);
        public abstract void HandleCollision(Collision2D collision, TriggerType triggerType);
        void OnTriggerEnter2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Enter);
        void OnTriggerStay2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Stay);
        void OnTriggerExit2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Exit);
        public abstract void HandleTrigger(Collider2D collider, TriggerType triggerType);

        public void SelfDestruct() => GameObject.Destroy(this);
    }

}
