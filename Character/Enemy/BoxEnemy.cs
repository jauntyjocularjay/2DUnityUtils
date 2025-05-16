using UnityEngine;

public class BoxEnemy : BoxCharacter
{
    public new BoxEnemyData data;

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
