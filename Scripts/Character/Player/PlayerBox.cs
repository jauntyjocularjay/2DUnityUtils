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

            HP(data.MaxHP);
        }
    }
}
