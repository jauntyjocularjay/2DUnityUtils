using UnityEngine;

namespace DMBTools
{
    public abstract class BoxEnemy : BoxCharacter
    {
        BoxEnemyData _Data;

        new protected void Start()
        {
            base.Start();
            HP = Data.MaxHP;
            SpriteRenderer.sortingOrder = Data.sortingOrder;
        }

        public BoxEnemyData Data
        {
            get => _Data;
        }
    }
}
