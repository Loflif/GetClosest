using System;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private float MovementForce = 20.0f;
    
    private FirstPersonController FPController;
    private Rigidbody             Body           = null;
    private Vector2               MovementVector = Vector2.zero;

    private void Awake()
    {
        FPController = new FirstPersonController();
        FPController.Enable();
        Body = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        BindInput();
    }

    private void OnDisable()
    {
        UnbindInput();
    }

    private void BindInput()
    {
        FPController.PlayerOne.Move.performed += UpdateMovementVector;
    }

    private void UnbindInput()
    {
        FPController.PlayerOne.Move.performed -= UpdateMovementVector;
    }

    private void UpdateMovementVector(InputAction.CallbackContext pContext)
    {
        MovementVector = pContext.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 flatMovementVector = new Vector3(MovementVector.x, 0, MovementVector.y);
        
        Body.AddForce(flatMovementVector * (MovementForce * Time.fixedDeltaTime), ForceMode.Impulse); 
        
    }
}
