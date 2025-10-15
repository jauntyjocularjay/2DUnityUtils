using System.Collections;
using UnityEngine;



namespace DMBTools
{
    public abstract class BoxCharacter : Character
    {
        BoxCollider2D collidr;

        new protected void Start()
        {
            base.Start();
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
