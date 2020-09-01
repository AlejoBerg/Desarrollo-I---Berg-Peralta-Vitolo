using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed ;
    private Animator playerAnimator;
    private float vertical;
    private float horizontal;
    private Vector3 playerMovement;
    private Rigidbody rb;
    private int jumpAttempts  = 0;
    public float jumpHight;
    Vector3 direction = Vector3.zero;
    private Camera camRef;
    
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb = transform.GetComponent<Rigidbody>();
        camRef = Camera.main;
    }

    private void Update()
    {
        Movement();
        Animation();
    }

    private void Movement()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        
        if (horizontal !=0 || vertical !=0)
        {
            direction.x = horizontal;
            direction.z = vertical;
            rb.velocity = direction * playerSpeed;
            transform.forward = Vector3.Lerp(transform.forward, direction, 0.51f);
        }
    }

    private void Animation()
    {
        if (vertical != 0 || horizontal != 0) // Movimiento adelante, atras y laterales
        {   
            playerSpeed = 2;
            playerAnimator.SetBool("Walk", true);
            playerAnimator.SetBool("OnIdle", false);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Jump", false);
            
            if (Input.GetKey(KeyCode.LeftShift)) // Correr
            {
                playerSpeed = 5;
                playerAnimator.SetBool("Run", true);
                playerAnimator.SetBool("Jump", false);
                playerAnimator.SetBool("Walk", false);
                playerAnimator.SetBool("OnIdle", false);
            }
            
            if (Input.GetKey(KeyCode.Space) && jumpAttempts < 1) // Salto
            {
                playerAnimator.SetBool("Jump", true);
                playerAnimator.SetBool("Walk", false);
                playerAnimator.SetBool("Run", false);
                playerAnimator.SetBool("OnIdle", false);
                rb.AddForce(new Vector3(0f,jumpHight,0f),ForceMode.Impulse);
                jumpAttempts++;
            } 
        }
        
        else // Entra al idle
        {
            playerSpeed = 2;
            playerAnimator.SetBool("OnIdle", true);
            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Jump", false);
            
            if (Input.GetKey(KeyCode.Space) && jumpAttempts < 1)
            {
                playerAnimator.SetBool("Jump", true);
                playerAnimator.SetBool("Walk", false);
                playerAnimator.SetBool("Run", false);
                playerAnimator.SetBool("OnIdle", false);
                rb.AddForce(new Vector3(0f,jumpHight,0f),ForceMode.Impulse);
                jumpAttempts++;
            }  
        }
    }
    private void OnCollisionEnter (Collision other)  
    {
        if (other.gameObject.tag.Equals("Floor"))
        {
            jumpAttempts = 0;
        }
    }
}
