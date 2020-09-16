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
    private float jumpForce = 2.4f;
    private Animator playerAnimator;
    private float playerSpeedForAnimation;
    public bool jumpActive = false;
    
    void Start()
    {
        player = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetBool("IsOnStart", true);
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
            playerSpeedForAnimation = 0.2f; 
            playerAnimator.SetFloat("Speed",Math.Abs(playerSpeedForAnimation));
            playerSpeed = 3;
            
            if (Input.GetKey(KeyCode.LeftShift) == true)
            {
                playerSpeed = 4;
                playerSpeedForAnimation = 1.2f;
                playerAnimator.SetFloat("Speed",Math.Abs(playerSpeedForAnimation ));
            }
            
            if (Input.GetKeyUp(KeyCode.LeftShift) == true)
            {
                playerSpeed = 3;
            }
        }
        else
        {   playerSpeedForAnimation = 0; 
            playerAnimator.SetFloat("Speed",Math.Abs(playerSpeedForAnimation));
        }
        
        CamDirection();

        directionMovePlayer = playerInput.x * camRight + playerInput.z * camForward;
        
        player.transform.LookAt(player.transform.position + directionMovePlayer);
        
        SetGravity();
        
        if (player.isGrounded && jumpActive && Input.GetKey(KeyCode.Space))
        {
            fallVelocity = jumpForce;
            directionMovePlayer.y = fallVelocity;
            playerAnimator.SetBool("IsOnStart", false);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Collectable"))
        {
            Debug.Log("Agarraste un coleccionable");
        }
    }
}