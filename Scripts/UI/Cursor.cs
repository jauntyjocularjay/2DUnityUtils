using UnityEditor.Build;
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

            // Transform.position = PlayerInput.;
        }

        void FixedUpdate()
        {
            Transform.position = new Vector2(Mouse.current.position.value.x, Mouse.current.position.value.y);
        }

    }
}