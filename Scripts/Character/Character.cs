using UnityEngine;

namespace DMBTools
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Character : Prop
    /* @class Character extends Prop to provide everything needed to work with a character with a physical presence and animator effectively combining the AnimatedProp and PhysicalProp  */
    {
        Animator _Animator;
        Rigidbody2D _RigidBody2D;
        protected int hp = 0;

        new protected void Start()
        /* @method Start() calls Prop.Start() and sets the 
                animator and rigidBody variables */
        {
            base.Start();
            _Animator = GetComponent<Animator>();
            _RigidBody2D = GetComponent<Rigidbody2D>();
        }
        public void HP(int currentHP)
        {
            hp = currentHP;
        }
        public int HP() => hp;
        public void IncrementHP(int i = 1) => hp += i;
        public void DecrementHP(int i = 1) => hp -= i;
        public Animator Animator
        {
            get => _Animator;
        }
        /* @method Animator() returns the Animator component from the GameObject */

        public Rigidbody2D Rigidbody2D
        {
            get => _RigidBody2D;
        }
        /* @method RigidBody2D() returns the Rigidbody2D component from the GameObject */

        public float LinearVelocityX() => _RigidBody2D.linearVelocityX;
        public float LinearVelocityY() => _RigidBody2D.linearVelocityY;
        public void LinearVelocityX(float x) => _RigidBody2D.linearVelocity = new Vector2(x, LinearVelocityY());
        /* @method LinearVelocityX(float x) sets the X value of the Rigidbody2D's linear velocity, keeping the current Y value */

        public void LinearVelocityY(float y) => _RigidBody2D.linearVelocity = new Vector2(LinearVelocityX(), y);
        /* @method LinearVelocityY(float y) sets the Y value of the Rigidbody2D's linear velocity, keeping the current X value */
        public void LinearVelocity(Vector2 vector) => _RigidBody2D.linearVelocity = vector;
        /* @method LinearVelocity(Vector2 vector) sets the Rigidbody2D's linear velocity using a Vector2 */



    }


}
