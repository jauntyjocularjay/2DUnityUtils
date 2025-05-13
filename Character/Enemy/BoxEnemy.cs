using UnityEngine;

public class BoxEnemy : BoxCharacter
{
    public BoxCharacterData data;

    new void Start()
    {
        base.Start();
        SetHP(data.MaxHP);
    }
}
