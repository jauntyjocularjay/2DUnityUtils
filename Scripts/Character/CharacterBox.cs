using System.Collections;
using UnityEngine;



namespace DMBTools
{
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class BoxCharacter : Character
    {
        BoxCollider2D _BoxCollider2D;

        new protected void Start()
        {
            base.Start();
            _BoxCollider2D = GetComponent<BoxCollider2D>();
        }

        public BoxCollider2D BoxCollider2D
        {
            get => _BoxCollider2D;
        }
    }
}
