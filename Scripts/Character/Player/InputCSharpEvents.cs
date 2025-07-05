using UnityEngine;
using UnityEngine.InputSystem;

namespace DMBTools
{
    public abstract class CSharpEventsInput : MonoBehaviour
    {
        BoxPlayer character;
        private Vector2 _moveDirection;
        public InputActionReference move;
        public InputActionReference attack;
        public InputActionReference jump;
        public void Start()
        {
            character = GetComponent<BoxPlayer>();
        }

        public void Update()
        {
            _moveDirection = move.action.ReadValue<Vector2>();
        }

        void OnEnable()
        {
            attack.action.started += Attack;
            jump.action.started += Jump;
        }
        void OnDisable()
        {
            attack.action.started -= Attack;
            jump.action.started -= Jump;
        }

        /*** Abstract Input Methods ***/
        public abstract void Attack(InputAction.CallbackContext obj);
        public abstract void Jump(InputAction.CallbackContext obj);
        public Vector2 MoveVector()
        {
            return _moveDirection;
        }
    }
}