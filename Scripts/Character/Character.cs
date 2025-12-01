using UnityEngine;

namespace DMBTools
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Character : Prop
    /* @class Character extends Prop to provide everything needed to work with a character with a physical presence and animator effectively combining the AnimatedProp and PhysicalProp  */
    {
        Animator _Animator;
        Rigidbody2D _Rigidbody2D;
        protected int hp = 0;
        new protected void Awake()
        {
            base.Awake();
            _Animator = GetComponent<Animator>();
            _Rigidbody2D = GetComponent<Rigidbody2D>();
        }
        new protected void Start()
        {
            base.Start();
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
            set => _Animator = value;
        }
        /* @method Animator() returns the Animator component from the GameObject */

        public Rigidbody2D Rigidbody2D
        {
            get => _Rigidbody2D;
            set => _Rigidbody2D = value;
        }
        /* @method RigidBody2D() returns the Rigidbody2D component from the GameObject */

    }


}
