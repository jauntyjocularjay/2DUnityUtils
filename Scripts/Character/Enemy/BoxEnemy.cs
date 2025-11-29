using UnityEngine;

namespace DMBTools
{
    public abstract class BoxEnemy : BoxCharacter
    {
        BoxEnemyData _Data;

        protected void Start()
        {
            HP(Data.MaxHP);
            SpriteRenderer.sortingOrder = Data.sortingOrder;
        }

        public BoxEnemyData Data
        {
            get => _Data;
        }
    }
}
