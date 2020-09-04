using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float playerSpeed = 2;
    private float playerSpeedForAnimation;
    private Animator playerAnimator = null;
    private float vertical;
    private float horizontal;
    private Rigidbody rb = null;
    private bool isGrounded = true;
    private float jumpForce = 5;
    private Vector3 direction = Vector3.zero;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        vertical = Input.GetAxisRaw("Vertical") * playerSpeed; //Adelante y Atras
        horizontal = Input.GetAxisRaw("Horizontal") * playerSpeed; //Izquierda y derecha
        playerAnimator.SetFloat("Speed", Math.Abs(playerSpeedForAnimation));

        if (horizontal !=0 || vertical !=0)
        {
            playerSpeed = 2;
            playerSpeedForAnimation = playerSpeed;

            if (Input.GetKey(KeyCode.LeftShift) == true)
            {
                playerSpeed = 3;
                playerSpeedForAnimation = playerSpeed;
            }
                
            direction.x = horizontal;
            direction.z = vertical;
            transform.Translate (direction.normalized * Time.deltaTime * playerSpeed, Space.World);
            transform.forward = direction;
        }
        else
        {
            playerSpeedForAnimation = 0;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            playerAnimator.SetBool("IsGrounded", isGrounded);
        }
    }

    private void OnCollisionEnter (Collision other) 
    {
        if (other.gameObject.tag.Equals("Floor"))
        {
            isGrounded = true;
            playerAnimator.SetBool("IsGrounded", isGrounded);
        }
    }
}
