using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;
    private float playerSpeed = 0;
    public CharacterController player;
    private Vector3 playerInput;
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 directionMovePlayer;
    private float gravity = 9.8f;
    private float fallVelocity = 3;
    private float jumpForce = 4;
    private Animator playerAnimator;
    private float playerSpeedForAnimation;
    
    void Start()
    {
        player = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        horizontalMove = Input.GetAxis("Horizontal") ;
        verticalMove = Input.GetAxis("Vertical");
        
        playerInput = new Vector3(horizontalMove,0f,verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput,1);
        
        if(horizontalMove != 0 || verticalMove !=0)
        {   
            playerAnimator.SetFloat("SpeedZ", Math.Abs(verticalMove));
            playerAnimator.SetFloat("SpeedX", Math.Abs(horizontalMove));
            playerSpeed = 3;
            
            if (Input.GetKey(KeyCode.LeftShift) == true)
            {
                playerSpeed = 4;
                playerAnimator.SetFloat("SpeedZ", 2);
                playerAnimator.SetFloat("SpeedX", 2);
            }
            
            if (Input.GetKeyUp(KeyCode.LeftShift) == true)
            {
                playerSpeed = 3;
                playerAnimator.SetFloat("SpeedZ", 1);
                playerAnimator.SetFloat("SpeedX", 1);
            }
        }
        else
        {
                playerAnimator.SetFloat("SpeedZ", verticalMove);
                playerAnimator.SetFloat("SpeedX", horizontalMove);
        }
        
        CamDirection();

        directionMovePlayer = playerInput.x * camRight + playerInput.z * camForward;
        
        player.transform.LookAt(player.transform.position + directionMovePlayer);
        
        SetGravity();
        
        if (player.isGrounded && Input.GetKey(KeyCode.Space))
        {
            fallVelocity = jumpForce;
            directionMovePlayer.y = fallVelocity;
        }
        
        player.Move(directionMovePlayer * playerSpeed * Time.deltaTime);
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

    void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            directionMovePlayer.y = fallVelocity;
            playerAnimator.SetBool("IsGrounded", true);
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            directionMovePlayer.y = fallVelocity;
            playerAnimator.SetBool("IsGrounded", false);
        }
    }
}