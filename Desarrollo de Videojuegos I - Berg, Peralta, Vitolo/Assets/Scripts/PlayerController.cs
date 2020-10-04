using System.Collections;
using System.Collections.Generic;
using System;
using Amazon.Runtime.Internal.Transform;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    [SerializeField]private Camera mainCamera;
    [SerializeField]private float jumpForce = 4f;
    private float horizontalMove;
    private float verticalMove;
    private float playerSpeed = 1.5f;
    private Vector3 playerInput;
    private Vector3 camForward;
    private Vector3 camRight;
    private bool canJump = true;
    private Animator playerAnimator;
    private float playerSpeedForAnimation;
    private Rigidbody rb;
    [HideInInspector] public bool jumpActive = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        
        playerInput = new Vector3(horizontalMove, 0,verticalMove).normalized * playerSpeed;
        
        if (horizontalMove != 0 || verticalMove != 0)
        { 
            playerSpeedForAnimation = 0.2f; 
            playerAnimator.SetFloat("Speed",Math.Abs(playerSpeedForAnimation));
            playerSpeed = 1.5f;
            
            /*if (Input.GetKey(KeyCode.LeftShift))
            {
                playerSpeed = 3f;
                playerSpeedForAnimation = 1.2f;
                playerAnimator.SetFloat("Speed",Math.Abs(playerSpeedForAnimation ));
            }
            
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                playerSpeed = 1.5f;
                playerSpeedForAnimation = 0.2f; 
            }*/ 
        }
        else
        {   playerSpeedForAnimation = 0;
            playerAnimator.SetFloat("Speed",Math.Abs(playerSpeedForAnimation));
        }
        
        CamDirection();

        playerInput = playerInput.x * camRight + playerInput.z * camForward;
        transform.LookAt(transform.position + playerInput);
       
        if (Input.GetButtonDown("Jump") && canJump && jumpActive)
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.VelocityChange);
            playerAnimator.SetBool("IsGrounded", false);
            canJump = false;
        }
       
        playerInput.y = rb.velocity.y;
        rb.velocity = playerInput;
    }

   void CamDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Floor"))
        {
            playerAnimator.SetBool("IsGrounded", true);
            canJump = true;
        }
    }
}