using UnityEngine;

namespace DMBTools
{
    public abstract class Character : Prop
    /* @class Character extends Prop to provide everything needed to work with a character with a physical presence and animator effectively combining the AnimatedProp and PhysicalProp  */
    {
        private Animator animator;
        private Rigidbody2D rigidBody;
        protected int hp = 0;

        new public void Start()
        /* @method Start() calls Prop.Start() and sets the 
                animator and rigidBody variables */
        {
            base.Start();
            animator = GetComponent<Animator>();
            rigidBody = GetComponent<Rigidbody2D>();
        }
        public void HP(int currentHP)
        {
            hp = currentHP;
        }
        public int HP() => hp;
        public void IncrementHP(int i = 1) => hp += i;
        public void DecrementHP(int i = 1) => hp -= i;
        public Animator Animator()
        /* @method Animator() returns the Animator component from the GameObject */
        {
            return animator;
        }
        public abstract void SetCollider2D();
        /* @method SetCollider2D() should be implemented by subclasses to set up the Collider2D component */
        public void SetRigidbody2D(bool rotation = true)
        /* @method SetRigidbody2D() fetches the Rigidbody2D 
            component and freezes its rotation by default */
        {
            rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.freezeRotation = rotation;
        }
        public Rigidbody2D Rigidbody2D()
        /* @method RigidBody2D() returns the Rigidbody2D 
            component from the GameObject */
        {
            return rigidBody;
        }
        public void LinearVelocityX(float x)
        /* @method LinearVelocityX(float x) sets the X 
                value of the Rigidbody2D's linear velocity, 
                keeping the current Y value */
        {
            rigidBody.linearVelocity = new Vector2
            (
                x,
                rigidBody.linearVelocityY
            );
        }
        public void LinearVelocityY(float y)
        /* @method LinearVelocityY(float y) sets the Y 
                value of the Rigidbody2D's linear 
                velocity, keeping the current X value */
        {
            rigidBody.linearVelocity = new Vector2
            (
                rigidBody.linearVelocityX,
                y
            );
        }
        public void LinearVelocity(Vector2 vector)
        /* @method LinearVelocity(Vector2 vector) sets the 
                Rigidbody2D's linear velocity using a 
                Vector2 */
        {
            rigidBody.linearVelocity = vector;
        }

    }


}
