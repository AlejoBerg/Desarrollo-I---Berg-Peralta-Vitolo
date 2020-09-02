using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); //X
        float vertical = Input.GetAxisRaw("Vertical"); //Z
        Vector3 playerMovement = new Vector3(horizontal, 0, vertical) * playerSpeed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }
}
