using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;


public class MovementController : MonoBehaviour
{
    InputAction moveAction;

    [SerializeField]
    CharacterController controller;

    Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(moveInput.x, 0, moveInput.y) * Time.deltaTime);
    }

    public void onMove(InputAction.CallbackContext ctx)
    {
        Debug.Log(ctx.phase);

        moveInput = ctx.ReadValue<Vector2>();
    }
}
