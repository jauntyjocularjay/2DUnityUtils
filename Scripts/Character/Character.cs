using UnityEngine;

namespace DMBTools
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Character : Prop
    /* @class Character extends Prop to provide everything needed to work with a character with a physical presence and animator effectively combining the AnimatedProp and PhysicalProp  */
    {
        protected Animator _Animator;
        protected Rigidbody2D _Rigidbody2D;
        protected int _hp = 0;
        public int HP { get; set; }
        new protected void Awake()
        {
            base.Awake();
            _Animator = GetComponent<Animator>();
            _Rigidbody2D = GetComponent<Rigidbody2D>();
        }
        new protected void Start()
        {
            base.Start();
            Rigidbody2D.freezeRotation = true;
        }
        public Animator Animator
        {
            get => GetComponent<Animator>();
            set => _Animator = value;
        }
        public Rigidbody2D Rigidbody2D
        {
            get => GetComponent<Rigidbody2D>();
            set => _Rigidbody2D = value;
        }
        public void IncrementHP(int i = 1) => HP += i;
        public void DecrementHP(int i = 1) => HP -= i;
    }


}
