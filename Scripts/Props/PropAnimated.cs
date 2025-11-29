using UnityEngine;

namespace DMBTools
{
    [RequireComponent(typeof(Animator))]
    public abstract class AnimatedProp : Prop
    /* @class Animated Prop includes the Prop class and addes getters and setters for the Animator */
    {
        Animator _Animator;
        new protected void Awake()
        {
            _Animator = GetComponent<Animator>();
        }
        public Animator Animator
        {
            get => _Animator;
            set => _Animator = value;
        }
    }
}
