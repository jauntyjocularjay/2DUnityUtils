using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DMBTools
{
    [RequireComponent(typeof(PlayerInput))]    
    public abstract class Cursor : MonoBehaviour
    {

        protected Vector3 mouseWorldPosition;
        public float clickThreshold = 0.1f;
        PlayerInput _playerInput;
        protected PlayerInput PlayerInput
        {
            get => _playerInput;
        }

        protected void Start()
        {

            _playerInput = GetComponent<PlayerInput>();
        }

        protected void FixedUpdate()
        {
            mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(
                Mouse.current.position.value.x,
                Mouse.current.position.value.y,
                Camera.main.nearClipPlane
            ));

            transform.position = mouseWorldPosition;
        }

    }
}