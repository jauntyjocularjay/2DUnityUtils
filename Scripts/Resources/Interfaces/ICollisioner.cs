using UnityEngine;

namespace DMBTools
{
    
    public interface ICollisioner
    {
        void OnCollisionEnter2D(Collision2D collision);
        void OnCollisionStay2D(Collision2D collision);
        void OnCollisionExit2D(Collision2D collision);

        // Copy and paste these when using ICollisioner interface
        // public void OnCollisionEnter2D(Collision2D collision) => HandleCollision(collision, CollisionType.Enter);
        // public void OnCollisionStay2D(Collision2D collision) => HandleCollision(collision, CollisionType.Stay);
        // public void OnCollisionExit2D(Collision2D collision) => HandleCollision(collision, CollisionType.Exit);

        public abstract void HandleCollision(Collision2D collision, CollisionType collisionType);
    }
}