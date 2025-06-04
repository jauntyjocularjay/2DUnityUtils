using UnityEngine;




namespace DMBTools
{
    public abstract class Area : Surface
    {
        public BoxCollider2D collidr;

        public new void Start()
        {
            base.Start();
            
        }
    }
}