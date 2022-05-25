using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public Transform groundCheck;
    public LayerMask groundMask;
    bool isGrounded;
    float groundDistance = 0.4f;

    Vector3 playerVelocity;
    Vector3 move;

    float moveSpeed = 3f;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            move = transform.right * x + transform.forward * z * 1.35f;
        }
        else
        {
            move = Vector3.ClampMagnitude(transform.right * x + transform.forward * z, 1f);
        }

        controller.Move(move * moveSpeed * Time.deltaTime);

        if (isGrounded)
        {
            playerVelocity.y = -2f;
        }
        else
        {
            playerVelocity.y -= 18f * Time.deltaTime;
        }

        controller.Move(playerVelocity * Time.deltaTime);

    }
}