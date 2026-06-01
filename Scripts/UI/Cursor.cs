using UnityEngine;

namespace DMBTools
{
    public abstract class Cursor : Prop
    {
        Vector2 position;

        new void Start()
        {
            base.Start();
            Transform.position = Vector2.zero;
        }
    }
}