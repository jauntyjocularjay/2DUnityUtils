using System.Collections.Generic;
using UnityEngine;

namespace DMBTools
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(AudioSource))]
    public abstract class Character : MonoBehaviour
    /* @class Character extends Prop to provide everything needed to work with a character with a physical presence and animator effectively combining the AnimatedProp and PhysicalProp  */
    {
        protected SpriteRenderer _SpriteRenderer;
        public SpriteRenderer SpriteRenderer { get => _SpriteRenderer; }
        protected Animator _Animator;
        public Animator Animator { get => _Animator; }
        protected Rigidbody2D _Rigidbody2D;
        public Rigidbody2D Rigidbody2D { get => _Rigidbody2D; }
        protected AudioSource _AudioSource;
        public AudioSource AudioSource { get => _AudioSource; }
        public int HP = 0;
        protected void Start()
        {
            _SpriteRenderer = GetComponent<SpriteRenderer>();
            _Animator = GetComponent<Animator>();

            _Rigidbody2D = GetComponent<Rigidbody2D>();
            _Rigidbody2D.freezeRotation = true;

            _AudioSource = GetComponent<AudioSource>();
        }

        public void IncrementHP(int i = 1) => HP += i;
        public void DecrementHP(int i = 1) => HP -= i;
    }


}
