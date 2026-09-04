using UnityEngine;

namespace DMBTools
{

    public interface ITriggerer
    {
        void OnTriggerEnter2D(Collider2D collider);
        void OnTriggerStay2D(Collider2D collider);
        void OnTriggerExit2D(Collider2D collider);

        // Paste these methods when using the Triggerer interface
        // public void OnTriggerEnter2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Enter);
        // public void OnTriggerStay2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Stay);
        // public void OnTriggerExit2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Exit);

        public void HandleTrigger(Collider2D collider, TriggerType type);
    }
}