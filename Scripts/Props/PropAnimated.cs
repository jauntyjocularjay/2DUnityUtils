using UnityEngine;

namespace DMBTools
{
    [RequireComponent(typeof(Animator))]
    public abstract class AnimatedProp : Prop
    /* @class Animated Prop includes the Prop class and addes getters and setters for the Animator */
    {
        Animator animator;

        new public void Start()
        {
            base.Start();

            animator = GetComponent<Animator>();
        }

        public Animator Animator()
        /* @method returns the animator */
        {
            return animator;
        }
        public void Animator(Animator animatr)
        /* @method sets the animator */
        {
            animator = animatr;
        }
    }
}
