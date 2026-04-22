using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public InputSystem_Actions inputs;

    public Vector2 MoveInput;
    public int MoveSpeed;

    private void Awake()
    {
        inputs = new();
    }

    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Move.performed += OnPlayerMove;
        inputs.Player.Move.canceled += OnPlayerMoveCanceled;
        inputs.Player.Attack_1.started += OnAttack1;
        inputs.Player.Attack_1.started += OnAttack2;
    }

    private void OnAttack1(InputAction.CallbackContext context)
    {
        Debug.Log("AT_1");
    }

    private void OnAttack2(InputAction.CallbackContext context)
    {
        Debug.Log("AT_2");
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        OnMove();
    }

    private void OnPlayerMoveCanceled(InputAction.CallbackContext context)
    {
        MoveInput = Vector2.zero;
    }

    private void OnPlayerMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    public void OnMove()
    {
        if (MoveInput != Vector2.zero)
        {
            transform.position += (Vector3)MoveInput * MoveSpeed * Time.deltaTime;
        }
    }
}
