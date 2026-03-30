using System;
using System.Collections.Generic;
using UnityEngine;

namespace DMBTools
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Character : Prop
    /* @class Character extends Prop to provide everything needed to work with a character with a physical presence and animator effectively combining the AnimatedProp and PhysicalProp  */
    {
        protected Animator _animator;
        public Animator Animator
        {
            get => GetComponent<Animator>();
            set => _animator = value;
        }
        protected Rigidbody2D _rigidbody2D;
        public Rigidbody2D Rigidbody2D
        {
            get => GetComponent<Rigidbody2D>();
            set => _rigidbody2D = value;
        }
        public int HP = 0;
        public StateSet state;
        new protected void Awake()
        {
            base.Awake();
            _animator = GetComponent<Animator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        new protected void Start()
        {
            base.Start();
            Rigidbody2D.freezeRotation = true;
            List<State> states = new List<State>{
                new State("walking"), 
                new State("running"), 
                new State("airbourne"), 
                new State("recovering")
            };

            state.Add(states);

        }
        public void IncrementHP(int i = 1) => HP += i;
        public void DecrementHP(int i = 1) => HP -= i;
    }


}
