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
    private bool isGrounded = true;
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
        vertical = Input.GetAxisRaw("Vertical"); // Z
        horizontal = Input.GetAxisRaw("Horizontal");
        playerMovement = new Vector3(horizontal, 0f, vertical) * playerSpeed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }

    private void Animation()
    {
        if (vertical != 0 && Input.GetKey(KeyCode.LeftShift) == false)
        {
            playerAnimator.SetBool("OnIdle", false);
            playerAnimator.SetBool("Walk", true);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Jump", false);
            playerAnimator.SetBool("Rigth", false);
            playerAnimator.SetBool("Left", false);
            playerSpeed = 2;
            playerMovement = new Vector3(horizontal, 0, vertical) * playerSpeed * Time.deltaTime;
            transform.Translate(playerMovement * playerSpeed * Time.deltaTime);
          
            if (Input.GetKey(KeyCode.Space) == true && isGrounded == true)
            {
                playerAnimator.SetBool("Jump", true);
                playerAnimator.SetBool("Walk", false);
                playerSpeed = 2;
                playerMovement = new Vector3(horizontal, 0, vertical) * playerSpeed * Time.deltaTime;
                transform.Translate(playerMovement * playerSpeed * Time.deltaTime);
                rb.velocity = transform.up * jumpHight;
                isGrounded = false;
            }

            if (Input.GetKeyUp(KeyCode.Space) == true)
            {
                playerAnimator.SetBool("Jump", false);
                playerAnimator.SetBool("Walk", true);
            }
        }
        else if(Input.GetKey(KeyCode.LeftShift) == true && vertical != 0 )
        {
            playerAnimator.SetBool("OnIdle", false);
            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Run", true);
            playerAnimator.SetBool("Jump", false);
            playerAnimator.SetBool("Rigth", false);
            playerAnimator.SetBool("Left", false);
            playerSpeed = 5;
            playerMovement = new Vector3(horizontal, 0, vertical) * playerSpeed * Time.deltaTime;
            transform.Translate(playerMovement * playerSpeed * Time.deltaTime);
            
            if (Input.GetKey(KeyCode.Space) == true && isGrounded == true)
            {
                playerAnimator.SetBool("Jump", true);
                playerAnimator.SetBool("Run", false);
                playerSpeed = 5;
                playerMovement = new Vector3(horizontal, 0, vertical) * playerSpeed * Time.deltaTime;
                transform.Translate(playerMovement * playerSpeed * Time.deltaTime);
                rb.velocity = transform.up * jumpHight;
                isGrounded = false;
            }

            if (Input.GetKeyUp(KeyCode.Space) == true)
            {
                playerAnimator.SetBool("Jump", false);
                playerAnimator.SetBool("Run", true);
            }
        }
        else if (Input.GetKey(KeyCode.Space) == true && vertical == 0  && Input.GetKey(KeyCode.LeftShift) == false && isGrounded == true)
        {
            playerAnimator.SetBool("Jump", true);
            playerAnimator.SetBool("OnIdle", false);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Rigth", false);
            playerAnimator.SetBool("Left", false);
            rb.velocity = transform.up * jumpHight;
            isGrounded = false;
        }
        else if (horizontal == 1 && vertical == 0)
        {
            playerAnimator.SetBool("Rigth", true);
            playerAnimator.SetBool("Left", false);
            playerAnimator.SetBool("OnIdle", false);
            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Jump", false);
        }
        else if (horizontal == -1  && vertical == 0)
        {
            playerAnimator.SetBool("Rigth", false);
            playerAnimator.SetBool("Left", true);
            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Jump", false);
            playerAnimator.SetBool("OnIdle", false);
        }
        else
        {
            playerAnimator.SetBool("OnIdle", true);
            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Jump", false);
            playerAnimator.SetBool("Rigth", false);
            playerAnimator.SetBool("Left", false);
        }
    }
    private void OnCollisionEnter (Collision other)  
    {
        if (other.gameObject.tag.Equals("Floor"))
        {
            isGrounded = true;
        }
    }
}
