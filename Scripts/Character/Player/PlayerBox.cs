using System.Collections;
using UnityEngine;



namespace DMBTools
{
    public abstract class BoxPlayer : BoxCharacter
    {
        public BoxPlayerData data;
        public new void Start()
        {
            base.Start();

            SetCollider2D();
            SetRigidbody2D();

            SpriteRenderer().sortingLayerID = data.sortingLayerID;
            SpriteRenderer().sortingOrder = data.sortingOrder;

            BoxCollider2D().offset = data.colliderOffset;
            BoxCollider2D().size = data.colliderSize;
            BoxCollider2D().edgeRadius = data.colliderEdgeRadius;

            Rigidbody2D().mass = data.mass;
            Rigidbody2D().gravityScale = data.gravityScale;

            HP(data.MaxHP);
        }
    }
}
