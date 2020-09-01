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
    
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb = transform.GetComponent<Rigidbody>();
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
        playerMovement = new Vector3(horizontal, 0f, vertical) * playerSpeed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }

    private void Animation()
    {
        if (vertical != 0) // Movimiento adelante y atrás (Caminata)
        {   
            playerSpeed = 2;
            playerAnimator.SetBool("Walk", true);
            playerAnimator.SetBool("OnIdle", false);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Jump", false);
            playerAnimator.SetBool("Rigth", false);
            playerAnimator.SetBool("Left", false);
            
            if (Input.GetKey(KeyCode.LeftShift)) // Correr
            {
                playerSpeed = 5;
                playerAnimator.SetBool("Run", true);
                playerAnimator.SetBool("Jump", false);
                playerAnimator.SetBool("Walk", false);
                playerAnimator.SetBool("Rigth", false);
                playerAnimator.SetBool("Left", false);
                playerAnimator.SetBool("OnIdle", false);
            }
            
            if (Input.GetKey(KeyCode.Space) && jumpAttempts < 1)
            {
                playerAnimator.SetBool("Jump", true);
                playerAnimator.SetBool("Walk", false);
                playerAnimator.SetBool("Run", false);
                playerAnimator.SetBool("Rigth", false);
                playerAnimator.SetBool("Left", false);
                playerAnimator.SetBool("OnIdle", false);
                rb.velocity = transform.up * jumpHight;
                jumpAttempts++;
            } 
        }
     
        else if (horizontal == -1) //Movimiento Izquierda
        {
            playerAnimator.SetBool("OnIdle", false);
            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Jump", false);
            playerAnimator.SetBool("Rigth", false);
            playerAnimator.SetBool("Left", true);
            playerSpeed = 2;
            
            if (Input.GetKey(KeyCode.Space) && jumpAttempts < 1)
            {
                playerAnimator.SetBool("Jump", true);
                playerAnimator.SetBool("Walk", false);
                playerAnimator.SetBool("Run", false);
                playerAnimator.SetBool("Rigth", false);
                playerAnimator.SetBool("Left", false);
                playerAnimator.SetBool("OnIdle", false);
                rb.velocity = transform.up * jumpHight;
                jumpAttempts++;
            } 
        }
        else if (horizontal == 1) //Movimiento derecha
        {
            playerAnimator.SetBool("Rigth", true);
            playerAnimator.SetBool("OnIdle", false);
            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Jump", false);
            playerAnimator.SetBool("Left", false);
            playerSpeed = 2;
            
            if (Input.GetKey(KeyCode.Space) && jumpAttempts < 1)
            {
                playerAnimator.SetBool("Jump", true);
                playerAnimator.SetBool("Walk", false);
                playerAnimator.SetBool("Run", false);
                playerAnimator.SetBool("Rigth", false);
                playerAnimator.SetBool("Left", false);
                playerAnimator.SetBool("OnIdle", false);
                rb.velocity = transform.up * jumpHight;
                jumpAttempts++;
            } 
        }
        else // Entra al idle
        {
            playerAnimator.SetBool("OnIdle", true);
            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Jump", false);
            playerAnimator.SetBool("Rigth", false);
            playerAnimator.SetBool("Left", false);
            
            if (Input.GetKey(KeyCode.Space) && jumpAttempts < 1)
            {
                playerAnimator.SetBool("Jump", true);
                playerAnimator.SetBool("Walk", false);
                playerAnimator.SetBool("Run", false);
                playerAnimator.SetBool("Rigth", false);
                playerAnimator.SetBool("Left", false);
                playerAnimator.SetBool("OnIdle", false);
                rb.velocity = transform.up * jumpHight;
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
