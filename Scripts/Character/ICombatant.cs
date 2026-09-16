using UnityEngine;



namespace DMBTools
{
    public interface ICombatant
    {
        public SpriteRenderer SpriteRenderer { get; set; }
        public Animator Animator { get; set; }
        public Collider2D Collider2D { get; set; }
        public AudioSource AudioSource { get; set; }
    }

}