using UnityEngine;



namespace DMBTools
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(AudioSource))]
    public abstract class Character : MonoBehaviour, ICombatant
    /* @class Character extends Prop to provide everything needed to work with a character with a physical presence and animator effectively combining the AnimatedProp and PhysicalProp  */
    {
        SpriteRenderer _spriteRenderer;
        public SpriteRenderer SpriteRenderer { get; set; }
        Animator _animator;
        public Animator Animator { get; set; }
        Collider2D _collider2D;
        public Collider2D Collider2D { get; set; }
        Rigidbody2D _rigidbody2D;
        public Rigidbody2D Rigidbody2D { get; set; }
        AudioSource _audioSource;
        public AudioSource AudioSource { get; set; }

        protected void Start()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Animator = GetComponent<Animator>();
            Collider2D = GetComponent<Collider2D>();

            Rigidbody2D = GetComponent<Rigidbody2D>();
            Rigidbody2D.freezeRotation = true;

            AudioSource = GetComponent<AudioSource>();
        }
    }


}
