using UnityEngine;

namespace DMBTools
{
    public abstract class BoxEnemy : BoxCharacter
    {
        public BoxEnemyData data;

        new void Awake()
        {
            base.Awake();
            HP(data.MaxHP);
            SpriteRenderer().sortingOrder = data.sortingOrder;
        }

        public BoxEnemyData Data()
        {
            return data;
        }
    }
}
