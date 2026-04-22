using System;
using UnityEngine;
using UnityEngine.InputSystem;


public enum PlayerCcontroler
{
    None,
    Player1,
    Player2
}

public class PlayerControl : MonoBehaviour
{
    public InputSystem_Actions inputs;

    public Vector2 MoveInput;
    public int MoveSpeed;

    public PlayerCcontroler playerCcontroler;   

  

    private void Awake()
    {
        inputs = new();
    }

    private void OnEnable()
    {
        inputs.Enable();

        switch (playerCcontroler)
        {
            case PlayerCcontroler.None:
                break;
            case PlayerCcontroler.Player1:
                {
                    inputs.Player.Player1_Move.performed += OnPlayerMove;
                    inputs.Player.Player1_Move.canceled += OnPlayerMoveCanceled;
                    inputs.Player.Attack_1.started += OnAttack1;
                    inputs.Player.Attack_1.started += OnAttack2;
                }
                break;
            case PlayerCcontroler.Player2:

                {
                    inputs.Player.Player2_Move.performed += OnPlayerMove;
                    inputs.Player.Player2_Move.canceled += OnPlayerMoveCanceled;
                    inputs.Player.Player2_Move.started += OnAttack1;
                    inputs.Player.Player2_Move.started += OnAttack2;
                }
                break;
        }

       
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
