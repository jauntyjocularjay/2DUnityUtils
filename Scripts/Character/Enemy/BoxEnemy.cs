using UnityEngine;

namespace DMBTools
{
    public abstract class BoxEnemy : BoxCharacter
    {
        public BoxEnemyData data;

        protected void Start()
        {
            HP(data.MaxHP);
            SpriteRenderer.sortingOrder = data.sortingOrder;
        }

        public BoxEnemyData Data()
        {
            return data;
        }
    }
}
