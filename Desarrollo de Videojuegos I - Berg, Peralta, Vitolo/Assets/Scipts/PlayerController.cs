using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed ;
    private Animator playerAnimator;
    private float vertical;
    private float horizontal;
    private Vector3 playerMovement;
    
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
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

    
        Debug.Log("horizontal" + horizontal);
       
        
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
            playerMovement = new Vector3(0, 0, vertical) * playerSpeed * Time.deltaTime;
            transform.Translate(playerMovement * playerSpeed * Time.deltaTime);
          
            if (Input.GetKey(KeyCode.Space) == true)
            {
                playerAnimator.SetBool("Jump", true);
                playerAnimator.SetBool("Walk", false);
                playerSpeed = 2;
                playerMovement = new Vector3(0, 0, vertical) * playerSpeed * Time.deltaTime;
                transform.Translate(playerMovement * playerSpeed * Time.deltaTime);
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
            playerMovement = new Vector3(0, 0, vertical) * playerSpeed * Time.deltaTime;
            transform.Translate(playerMovement * playerSpeed * Time.deltaTime);
            
            
            if (Input.GetKey(KeyCode.Space) == true)
            {
                playerAnimator.SetBool("Jump", true);
                playerAnimator.SetBool("Run", false);
                playerSpeed = 5;
                playerMovement = new Vector3(0, 0, vertical) * playerSpeed * Time.deltaTime;
                transform.Translate(playerMovement * playerSpeed * Time.deltaTime);
            }

            if (Input.GetKeyUp(KeyCode.Space) == true)
            {
                playerAnimator.SetBool("Jump", false);
                playerAnimator.SetBool("Run", true);
            }
        }
        else if (Input.GetKey(KeyCode.Space) == true && vertical == 0  && Input.GetKey(KeyCode.LeftShift) == false)
        {
            playerAnimator.SetBool("Jump", true);
            playerAnimator.SetBool("OnIdle", false);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Rigth", false);
            playerAnimator.SetBool("Left", false);
        }
        else if (horizontal == 1 && vertical == 0 && Input.GetKey(KeyCode.D))
        {
            playerAnimator.SetBool("Rigth", true);
            playerAnimator.SetBool("Left", false);
            playerAnimator.SetBool("OnIdle", false);
            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Jump", false);
        }
        
        else if (horizontal == -1  && vertical == 0 && Input.GetKey(KeyCode.A))
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
}
