using System.Collections;
using UnityEngine;

namespace DMBTools
{
    public abstract class Character : Prop
    {
        private Animator animator;
        private Rigidbody2D rigidBody;
    
        new public void Start()
        {
            base.Start();
            animator = GetComponent<Animator>();
            rigidBody = GetComponent<Rigidbody2D>();
        }
        public Animator Animator()
        {
            return animator;
        }
        public abstract void SetCollider2D();
        public void SetRigidbody2D()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.bodyType = RigidbodyType2D.Dynamic;
            rigidBody.freezeRotation = true;
        }
        public Rigidbody2D RigidBody2D()
        {
            return rigidBody;
        }
        public void SetHP(int currentHP)
        {
            Animator().SetInteger("HP", currentHP);
        }
        public int HP()
        {
            return Animator().GetInteger("HP");
        }
        public void DecrementHP()
        {
            SetHP(HP() - 1);
        }
        public void LinearVelocityX(float x)
        {
            rigidBody.linearVelocity = new Vector2
            (
                x,
                rigidBody.linearVelocityY
            );
        }
        public void LinearVelocityY(float y)
        {
            rigidBody.linearVelocity = new Vector2
            (
                rigidBody.linearVelocityX,
                y
            );
        }
        public void LinearVelocity(Vector2 vector)
        {
            rigidBody.linearVelocity = vector;
        }


    }


}
