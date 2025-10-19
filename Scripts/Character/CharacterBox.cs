using System.Collections;
using UnityEngine;



namespace DMBTools
{
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class BoxCharacter : Character
    {
        BoxCollider2D collidr;

        new protected void Awake()
        {
            base.Awake();
            collidr = GetComponent<BoxCollider2D>();
        }
        
        public BoxCollider2D BoxCollider2D()
        {
            return collidr;
        }
    }
}
