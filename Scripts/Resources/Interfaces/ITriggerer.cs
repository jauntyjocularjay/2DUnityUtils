using UnityEngine;

namespace DMBTools
{

    public interface ITriggerer
    {
        void OnTriggerEnter2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Enter);
        void OnTriggerStay2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Stay);
        void OnTriggerExit2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Exit);
        public void HandleTrigger(Collider2D collider, TriggerType triggerType);

    }
}