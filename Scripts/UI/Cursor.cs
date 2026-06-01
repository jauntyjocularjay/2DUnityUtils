using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DMBTools
{
    [RequireComponent(typeof(PlayerInput))]    
    public abstract class Cursor : Prop
    {
        Vector3 mousePosition;
        PlayerInput _playerInput;
        PlayerInput PlayerInput
        {
            get => _playerInput;
        }

        new void Start()
        {
            base.Start();

            _playerInput = GetComponent<PlayerInput>();
        }

        void FixedUpdate()
        {
            mousePosition = new Vector3(
                Mouse.current.position.value.x,
                Mouse.current.position.value.y,
                Camera.main.nearClipPlane
            );

            Transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }

    }
}