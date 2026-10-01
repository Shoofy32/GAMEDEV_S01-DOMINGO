using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;


public class MovementController : MonoBehaviour
{
    [SerializeField]
    CharacterController controller;
    float gravity = -9.81f;
    float speed = 5f;
    float jumpHeight = 2f;

    Vector3 velocity;
    Vector2 moveInput;

    void Update()
    {

        Vector3 move = transform.  * moveInput.y;

        move *= speed;

        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f; 
        else
            velocity.y += gravity * Time.deltaTime;

        Vector3 total = (move * Time.deltaTime) + new Vector3(0, velocity.y * Time.deltaTime, 0);
        controller.Move(total);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    public void OnLook(InputValue value)
    {
        Vector2 lookInput = value.Get<Vector2>();
        transform.Rotate(Vector3.up, lookInput.x);
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && controller.isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}
