using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed ;
    private Animator playerAnimator;
    private float vertical; 
    
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
        Vector3 playerMovement = new Vector3(0, 0, vertical) * playerSpeed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }

    private void Animation()
    {
        if (vertical != 0 && Input.GetKey(KeyCode.LeftShift) == false)
        {
           
            playerAnimator.SetBool("OnIdle", false);
            playerAnimator.SetBool("Walk", true);
            playerAnimator.SetBool("Run", false);
            playerSpeed = 2;
            Vector3 playerMovement = new Vector3(0, 0, vertical) * playerSpeed * Time.deltaTime;
            transform.Translate(playerMovement * playerSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.LeftShift) == true)
        {
            
            playerAnimator.SetBool("OnIdle", false);
            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Run", true);
            playerSpeed = 5;
            Vector3 playerMovement = new Vector3(0, 0, vertical) * playerSpeed * Time.deltaTime;
            transform.Translate(playerMovement * playerSpeed * Time.deltaTime);
        }
        else
        {
            playerAnimator.SetBool("OnIdle", true);
            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Run", false);
        }
        
    }
    
}
