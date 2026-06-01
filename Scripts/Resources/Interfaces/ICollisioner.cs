using UnityEngine;

namespace DMBTools
{
    
    public interface ICollisioner
    {
        void OnCollisionEnter2D(Collision2D collision) => HandleCollision(collision, CollisionType.Enter);
        void OnCollisionStay2D(Collision2D collision) => HandleCollision(collision, CollisionType.Stay);
        void OnCollisionExit2D(Collision2D collision) => HandleCollision(collision, CollisionType.Exit);
        public abstract void HandleCollision(Collision2D collision, CollisionType collisionType);
    }
}