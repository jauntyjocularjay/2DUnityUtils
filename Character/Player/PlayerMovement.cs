using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    BoxCharacter character;
    private Vector2 _moveDirection;
    public InputActionReference move;
    public InputActionReference attack;
    public InputActionReference jump;
    void Start()
    {
        character = GetComponent<BoxCharacter>();
    }

    // Update is called once per frame
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
    void Move(InputAction.CallbackContext obj){}
    void Attack(InputAction.CallbackContext obj){}
    void Jump(InputAction.CallbackContext obj){}
    public Vector2 MoveVector()
    {
        return _moveDirection;
    }
}
