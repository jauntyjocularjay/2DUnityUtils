using UnityEngine;

namespace DMBTools
{
    public abstract class AnimatedProp : Prop
    {
        Animator animator;

        new public void Start()
        {
            base.Start();

            animator = GetComponent<Animator>();
        }

        public Animator Animator()
        {
            return animator;
        }
        public void Animator(Animator animatr)
        {
            animator = animatr;
        }
    }
}
