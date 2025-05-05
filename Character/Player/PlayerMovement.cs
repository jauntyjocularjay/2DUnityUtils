using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    BoxPlayer character;
    private Vector2 _moveDirection;
    public InputActionReference move;
    public InputActionReference attack;
    public InputActionReference jump;
    void Start()
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
    public void Move(InputAction.CallbackContext obj){
        if(MoveVector().x < 0)
        {
            character.SpriteRenderer().flipX = true;
        }
        else if (MoveVector().x > 0)
        {
            character.SpriteRenderer().flipX = false;
        }
        character.GetComponent<Rigidbody2D>().linearVelocityX = MoveVector().x * 5;
    }
    void Attack(InputAction.CallbackContext obj){}
    void Jump(InputAction.CallbackContext obj){}
    public Vector2 MoveVector()
    {
        return _moveDirection;
    }
}
