using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;
    private float playerSpeed;
    private Vector3 playerInput;
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 directionMovePlayer;
    [SerializeField]private float jumpForce = 5f;
    private bool canJump = true;
    private Animator playerAnimator;
    private float playerSpeedForAnimation;
    private Rigidbody rb;
    public bool jumpActive = false;
    
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
       
        playerInput = new Vector3(horizontalMove * playerSpeed, rb.velocity.y ,verticalMove * playerSpeed) ;
        //playerInput = Vector3.ClampMagnitude(playerInput,1);
        
        if (horizontalMove != 0 || verticalMove != 0)
        { 
            playerSpeedForAnimation = 0.2f; 
            playerAnimator.SetFloat("Speed",Math.Abs(playerSpeedForAnimation));
            playerSpeed = 5;
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerSpeed = 7;
                playerSpeedForAnimation = 1.2f;
                playerAnimator.SetFloat("Speed",Math.Abs(playerSpeedForAnimation ));
            }
            
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                playerSpeed = 5;
                playerSpeedForAnimation = 0.2f; 
            }
        }
        else
        {   playerSpeedForAnimation = 0;
            playerAnimator.SetFloat("Speed",Math.Abs(playerSpeedForAnimation));
        }
        
        CamDirection();

        directionMovePlayer = playerInput.x * camRight + playerInput.z * camForward;
       
        transform.LookAt(transform.position + directionMovePlayer);
        
        rb.AddForce(directionMovePlayer);
        
        if (Input.GetKey(KeyCode.Space) && canJump && jumpActive)
        {
            rb.velocity += Vector3.up * jumpForce;
            playerAnimator.SetBool("IsGrounded", false);
            canJump = false;
        }
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