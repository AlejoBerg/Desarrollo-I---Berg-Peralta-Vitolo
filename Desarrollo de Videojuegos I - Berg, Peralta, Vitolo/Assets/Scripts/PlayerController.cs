using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float jumpForce = 4f;
    [SerializeField]private GameObject bagPack;
    [SerializeField]private AudioSource jumpSFX;
    [SerializeField]private float playerSpeed = 1.5f;
    private Camera mainCamera;
    private bool jumpActive = false;
    private float horizontalMove;
    private float verticalMove;
    private Vector3 playerInput;
    private Vector3 camForward;
    private Vector3 camRight;
    private bool isGrounded = true;
    private bool runActive = false;
    private Animator playerAnimator;
    private float playerSpeedForAnimation;
    private Rigidbody rb;
    private float coordsY;
    int layerMask = 1 << 8; // Con esta línea choco solamente con la capa 8
    private bool wallDetected = false;
    [HideInInspector]public bool pickUpItem = false;
    [HideInInspector]public bool pickUpTorch = false;
    private float currentJumpTime = 0f;
    [SerializeField] private float delayJumpTime = 1.3f;
    //public ParticleSystem particles;
   // protected static bool doSuperJump = false;
    
    //public static bool DoSuperJump { get => doSuperJump; set => doSuperJump = value;}
    
    void Awake() 
    { 
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        mainCamera = Camera.main;
      //  particles = GetComponentInChildren<ParticleSystem>();
    }
    
    void Update()
    {
        Movement();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(playerInput.x, coordsY, playerInput.z);

       if(wallDetected)
       {
         RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 0.4f, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1.5f, Color.white);
                wallDetected = false;
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
            
            if (Input.GetKey(KeyCode.LeftShift) && runActive)
            {
                playerSpeed = 5f;
                playerSpeedForAnimation = 1.2f;
                playerAnimator.SetFloat("Speed",Math.Abs(playerSpeedForAnimation ));
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) && runActive)
            {
                playerSpeed = 2f;
                playerSpeedForAnimation = 0.2f; 
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.LeftShift) && runActive)
            {
                playerSpeed = 2f;
                playerSpeedForAnimation = 0.2f; 
            }
            playerSpeedForAnimation = 0;
            playerAnimator.SetFloat("Speed",Math.Abs(playerSpeedForAnimation));
        }
        
        if (pickUpItem)
        {
            playerAnimator.SetBool("ItemPickUp",true);
        }
        else
        {
            playerAnimator.SetBool("ItemPickUp",false);
        }
        
        CamDirection();

        playerInput = playerInput.x * camRight + playerInput.z * camForward;
        transform.LookAt(transform.position + playerInput);
       
       
            
            if (Input.GetButtonDown("Jump") && isGrounded && jumpActive)
            {
                if (currentJumpTime >= delayJumpTime)
                {
                jumpSFX.Play();
                rb.AddForce((Vector3.up)* jumpForce,ForceMode.Impulse);
                //Debug.Log("velocidad en y" + rb.velocity.y);
                //rb.velocity = new Vector3(playerInput.x, jumpForce, playerInput.z);
                playerAnimator.SetBool("IsGrounded", false);
                isGrounded = false;
                currentJumpTime = 0;
                }
            }
            //if(jumpForce == 7f){doSuperJump = true;}
            else 
            {
             currentJumpTime += Time.deltaTime;
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
        if (other.gameObject.tag.Equals("Floor") || other.gameObject.tag.Equals("Bridge") )
        {
            playerAnimator.SetBool("IsGrounded", true);
            isGrounded = true;
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Walls"))
        {
            wallDetected = true;
        }
    }

    public void ChangeWalkPlayerSpeed(float speed)
    {
        playerSpeed = speed;
    }
    
    public void ChangeConditionToJump(bool condition)
    {
        jumpActive = condition;
    }
    
    public void ChangeConditionToRun(bool condition)
    {
        runActive = condition;
    }
    
    public void ChangeJumpForce(float force)
    {
        jumpForce = force;
    }
    
    public void ChangeCameraPos(Vector3 pos)
    {
        camRight = pos;
    }
}