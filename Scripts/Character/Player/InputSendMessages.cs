using UnityEngine;
using UnityEngine.InputSystem;

public abstract class SendMessagesInput : MonoBehaviour
/*
    SendMessages is the input handling method that most resembles traditional input handling.
    Uses Start() and Update().
*/
{
    public Vector2 _Move_Vector;

    public abstract void OnAttack();
    public abstract void OnCrouch();
    public abstract void OnInteract();
    public abstract void OnJump();
    public abstract void OnLook();
    public void OnMove(InputValue inputValue)
    {
        _Move_Vector = inputValue.Get<Vector2>();
    }
    public abstract void OnNext();
    public abstract void OnPrevious();
    public abstract void OnSprint();
}
