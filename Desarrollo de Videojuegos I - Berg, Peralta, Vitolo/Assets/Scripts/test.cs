using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerController _player;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _player = GetComponent<PlayerController>();
    }
    
   
}
