using UnityEngine;

namespace DMBTools
{
    public abstract class BoxEnemy : BoxCharacter
    {
        [ScriptableObject] public BoxEnemyData data;

        new protected void Start()
        {
            base.Start();
            HP = data.MaxHP;
        }
    }
}
