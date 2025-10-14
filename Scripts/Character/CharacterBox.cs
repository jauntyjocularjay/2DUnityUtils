using System.Collections;
using UnityEngine;



namespace DMBTools
{
    public abstract class BoxCharacter : Character
    {
        BoxCollider2D collidr;

        public new void Awake()
        {
            base.Awake();
            SetCollider2D();
        }
        
        public override void SetCollider2D()
        {
            collidr = GetComponent<BoxCollider2D>();
        }
        public BoxCollider2D BoxCollider2D()
        {
            return collidr;
        }
    }
}
