using UnityEngine;

namespace DMBTools
{
    public abstract class BoxEnemy : BoxCharacter
    {
        public BoxEnemyData data;


        new protected void Start()
        {
            base.Start();
            HP = data.MaxHP;
            SpriteRenderer.sortingOrder = data.sortingOrder;
        }
    }
}
