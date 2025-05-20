using UnityEngine;

public class BoxEnemy : BoxCharacter
{
    public BoxEnemyData data;

    new void Start()
    {
        base.Start();
        SetHP(data.MaxHP);
    }

    public BoxEnemyData Data()
    {
        return data;
    }
}
