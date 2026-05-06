using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimatorController : MonoBehaviour
{
    public InputSystem_Actions inputs;

    public Animator animator;

    public Vector2 MoveInput;

    private void Awake()
    {
        inputs = new();
    }
    private void OnEnable()
    {
        inputs.Enable();
       inputs.Player3.Movement.performed += OnMovementStart;
       inputs.Player3.Movement.canceled += OnMovementFinish;

        inputs.Player3.Jump.performed += OnJumpStart;
    }



    void Start()
    {

    }
    void Update()
    {

    }
    private void OnMovementStart(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();

        if (MoveInput.x != 0)
            animator.SetBool("IsMoving", true);

        // (MoveInput.x == -1) GetComponent<SpriteRenderer>().flipX = true;

        GetComponent<SpriteRenderer>().flipX = (MoveInput.x == -1 && MoveInput.x != 0) ? true : false;

    }
    private void OnMovementFinish(InputAction.CallbackContext context)
    {
        MoveInput = Vector2.zero;
        animator.SetBool("IsMoving", false);
    }
    private void OnJumpStart(InputAction.CallbackContext context)
    {
        animator.SetTrigger("Jump");
    }

}