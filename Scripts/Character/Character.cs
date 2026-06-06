using System.Collections.Generic;
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
        public int HP = 0;
        public StateSet state;
        new protected void Start()
        {
            base.Start();
            _Animator = GetComponent<Animator>();
            _Rigidbody2D = GetComponent<Rigidbody2D>();
            Rigidbody2D.freezeRotation = true;
            List<State> states = new List<State>{
                new State("walking"), 
                new State("running"), 
                new State("airbourne"), 
                new State("recovering")
            };

            state.Add(states);

        }
        public Animator Animator { get => _Animator; }
        public Rigidbody2D Rigidbody2D { get => _Rigidbody2D; }
        public void IncrementHP(int i = 1) => HP += i;
        public void DecrementHP(int i = 1) => HP -= i;
    }


}
