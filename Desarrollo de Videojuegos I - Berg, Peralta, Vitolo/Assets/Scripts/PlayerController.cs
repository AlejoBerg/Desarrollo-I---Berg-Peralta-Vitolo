using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    [SerializeField]private Camera mainCamera;
    [SerializeField]private float jumpForce = 4f;
    [SerializeField]private float _distanceDetectRayCast;
    [SerializeField]private float _distanceRayCast;
    [SerializeField]private GameObject bagPack;
    [SerializeField]private AudioSource jumpSFX;
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
    private float coordsY;
    int layerMask = 1 << 8; // Con esta línea choco solamente con la capa 8
    private bool test = false;
    private Animator playerBagAnimator;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerBagAnimator = bagPack.GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(playerInput.x, coordsY, playerInput.z); ;
        
       //layerMask = ~layerMask; // Con esta línea choco con todo menos con la capa 8

       if(test)
       {
         RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, _distanceDetectRayCast, layerMask))
             {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
             }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * _distanceRayCast, Color.white);
                test = false;
            }
       }
    }

    void Movement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        coordsY = rb.velocity.y;
        playerInput = new Vector3(horizontalMove, 0,verticalMove).normalized * playerSpeed;
        
        if (horizontalMove != 0 || verticalMove != 0)
        {
            playerSpeedForAnimation = 0.2f; 
            playerAnimator.SetFloat("Speed",Math.Abs(playerSpeedForAnimation));
            playerSpeed = 1.5f;
            playerBagAnimator.SetFloat("SpeedBagPack", 0.2f);
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
            playerBagAnimator.SetFloat("SpeedBagPack", 0f);
        }
        
        CamDirection();

        playerInput = playerInput.x * camRight + playerInput.z * camForward;
        transform.LookAt(transform.position + playerInput);
       
        if (Input.GetButtonDown("Jump") && canJump && jumpActive)
        {
            jumpSFX.Play();
            rb.AddForce((Vector3.up)* jumpForce,ForceMode.Impulse);
            playerAnimator.SetBool("IsGrounded", false);
            //playerBagAnimator.SetBool("PlayerJump", true);
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
            //playerBagAnimator.SetBool("PlayerJump", false);
            canJump = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Walls"))
        {
            test = true;
        }
    }
}