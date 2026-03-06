using UnityEngine;
using UnityEngine.Tilemaps;



namespace DMBTools
{
    public class FallingTilemap : DMBMonoBehaviour, ITriggerer
    {
        TilemapRenderer _tilemapRenderer;
        TilemapRenderer TilemapRenderer
        {
            get => _tilemapRenderer;
            set => _tilemapRenderer = value;
        }
        public bool triggered = false;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public new void Start()
        {
            base.Start();
            TilemapRenderer = GetComponent<TilemapRenderer>();        
        }

        void OnTriggerEnter2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Enter);
        void OnTriggerStay2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Stay);
        void OnTriggerExit2D(Collider2D collider) => HandleTrigger(collider, TriggerType.Exit);
        public void HandleTrigger(Collider2D collider, TriggerType triggerType)
        {
            if(triggerType == TriggerType.Enter && collider.CompareTag(Tag.Player))
            {
                triggered = true;
            }
        }
    }
}