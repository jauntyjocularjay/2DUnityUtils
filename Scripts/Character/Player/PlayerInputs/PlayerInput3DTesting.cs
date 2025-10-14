using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput3DTesting : MonoBehaviour
{
    /*
        - Add Player Input Manager component to your player GameObject
        - Set Notification Behavior to Invoke Unity Events
        - Assign Actions to InputActions object with defined actions
        - Under Events
            - Assign the player object to the input actions used in the game
            - Assign the event to the corresponding method
    */

    private Rigidbody sphereRigidBody;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        sphereRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log($"contextphase: {context.phase}");
        // sphereRigidBody.AddForce(Vector3.up * 5f, ForceMode2D.Impulse); // THERE IS A COMPLETELY SEPARATE FORCE SYSTEM FOR 2D!!!
        // Event Phases
        if (context.started)
        {
            sphereRigidBody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
        if (context.performed)
        {
            sphereRigidBody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
        if (context.canceled)
        {
            sphereRigidBody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }
}
