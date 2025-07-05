using UnityEngine;

namespace DMBTools
{
    public abstract class BoxEnemy : BoxCharacter
    {
        public BoxEnemyData data;

        new void Start()
        {
            base.Start();
            SetHP(data.MaxHP);
            SpriteRenderer().sortingOrder = data.sortingOrder;
        }

        public BoxEnemyData Data()
        {
            return data;
        }
    }
}
