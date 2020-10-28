using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{    
    //[SerializeField]private Camera mainCamera;
    private Camera mainCamera;
    [SerializeField]private float jumpForce = 4f;
    [SerializeField]private GameObject bagPack;
    [SerializeField]private AudioSource jumpSFX;
    [SerializeField]private float playerSpeed = 1.5f;
    private bool jumpActive = false;
    private float horizontalMove;
    private float verticalMove;
    private Vector3 playerInput;
    private Vector3 camForward;
    private Vector3 camRight;
    private bool isGrounded = true;
    private bool canRun = false;
    private Animator playerAnimator;
    private float playerSpeedForAnimation;
    private Rigidbody rb;
    private float coordsY;
    int layerMask = 1 << 8; // Con esta línea choco solamente con la capa 8
    private bool wallDetected = false;
    private Animator playerBagAnimator;
    [HideInInspector]public bool pickUpItem = false;
    [HideInInspector]public bool pickUpTorch = false;
    
    public void Awake() 
    { 
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerBagAnimator = bagPack.GetComponent<Animator>();
        mainCamera = Camera.main;
    }
    
    void Update()
    {
        Movement();
        if (GameManager.ParchmentsAmount == 2) { jumpActive = true;}
        Debug.Log("posicion" + transform.position);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(playerInput.x, coordsY, playerInput.z); ;

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
            //playerSpeed = 1.5f;
            playerBagAnimator.SetFloat("SpeedBagPack", 0.2f);
            if (Input.GetKey(KeyCode.LeftShift) && canRun)
            {
                playerSpeed = 3f;
                playerSpeedForAnimation = 1.2f;
                playerAnimator.SetFloat("Speed",Math.Abs(playerSpeedForAnimation ));
            }
            
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                playerSpeed = 1.5f;
                playerSpeedForAnimation = 0.2f; 
            }
        }
        else
        {   playerSpeedForAnimation = 0;
            playerAnimator.SetFloat("Speed",Math.Abs(playerSpeedForAnimation));
            playerBagAnimator.SetFloat("SpeedBagPack", 0f);
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
            jumpSFX.Play();
            rb.AddForce((Vector3.up)* jumpForce,ForceMode.Impulse);
            playerAnimator.SetBool("IsGrounded", false);
            isGrounded = false;
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

    public void ChangePlayerSpeed(float speed)
    {
        playerSpeed = speed;
    }
}