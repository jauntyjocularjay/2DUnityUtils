using UnityEngine;
using UnityEngine.InputSystem;

namespace DMBTools
{
    [RequireComponent(typeof(PlayerInput))]    
    public abstract class Cursor : Prop
    {
        Vector2 position;
        PlayerInput _playerInput;

        PlayerInput PlayerInput
        {
            get => _playerInput;
        }

        new void Start()
        {
            base.Start();

            _playerInput = GetComponent<PlayerInput>();

            Transform.position = Vector2.zero;
        }
    }
}