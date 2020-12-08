using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle5 : MonoBehaviour
{
    [SerializeField] private GameObject platform1;
    [SerializeField] private GameObject platform2;
    [SerializeField] private GameObject platform3;
    [SerializeField] private GameObject newPosPlat1;
    [SerializeField] private GameObject newPosPlat1b;
    [SerializeField] private GameObject newPosPlat2;
    [SerializeField] private GameObject bridgeParticles1;
    [SerializeField] private GameObject bridgeParticles2;
    [SerializeField] private GameObject bridgeParticles3;
    [SerializeField] private GameObject parchment1;
    [SerializeField] private GameObject parchment2;
    [SerializeField] private GameObject parchment3;
    [SerializeField] private GameObject wallOut;
    [SerializeField] private float platformsSpeed;
    private bool doOnce = true;
    private Rigidbody platform1RB;
    private Rigidbody platform2RB;
    private bool doOnce2 = true;
    private bool doOnce3 = true;
    private bool doOnce4 = true;

    private void Awake()
    {
        platform1RB = platform1.GetComponent<Rigidbody>();
        platform2RB = platform2.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        bridgeParticles1.GetComponent<ChangeValueOfParticles>().SetMinMaxParticles(0);
        bridgeParticles2.GetComponent<ChangeValueOfParticles>().SetMinMaxParticles(0);
        bridgeParticles3.GetComponent<ChangeValueOfParticles>().SetMinMaxParticles(0);
    }

    void Update()
    {
        if (GameManager.ItemsAmount2 == 5 && doOnce)
        {
           MovePlatform1();
           wallOut.SetActive(false);
        }

        if (GameManager.ParchmentsAmount == 1 && doOnce2) // valores a definir
        {
            MovePlatform1Up();
        }
        else if (GameManager.ParchmentsAmount == 2 && doOnce3)  // valores a definir
        {
            MovePlatform2Up();
        }
        else if (GameManager.ParchmentsAmount == 3 && doOnce4)  // valores a definir
        {
            MovePlatform3();
        }
    }
    
    void MovePlatform1()
    {
        platform1RB.MovePosition(Vector3.MoveTowards(platform1RB.position, newPosPlat1.transform.position, platformsSpeed * Time.deltaTime));

        if (platform1RB.position == newPosPlat1.transform.position)
        {
            parchment1.SetActive(true);
            doOnce = false;
        }
    }
    
    void MovePlatform1Up()
    {
        platform1RB.MovePosition(Vector3.MoveTowards(platform1RB.position, newPosPlat1b.transform.position, platformsSpeed * Time.deltaTime));
        
        if (platform1RB.position == newPosPlat1b.transform.position)
        {
            bridgeParticles1.GetComponent<ChangeValueOfParticles>().SetMinMaxParticles(2000);
            parchment2.SetActive(true);
            doOnce2 = false;
        }
    }
    
    void MovePlatform2Up()
    {
        bridgeParticles1.GetComponent<ChangeValueOfParticles>().SetMinMaxParticles(0);
        platform2RB.MovePosition(Vector3.MoveTowards(platform2RB.position, newPosPlat2.transform.position, platformsSpeed * Time.deltaTime));

        if (platform2RB.position == newPosPlat2.transform.position)
        {
            bridgeParticles2.GetComponent<ChangeValueOfParticles>().SetMinMaxParticles(2000);
            parchment3.SetActive(true);
            doOnce3 = false;
        }
    }
    
    void MovePlatform3()
    {
        bridgeParticles2.GetComponent<ChangeValueOfParticles>().SetMinMaxParticles(0);
        bridgeParticles3.GetComponent<ChangeValueOfParticles>().SetMinMaxParticles(2000);
        doOnce4 = false;
    }
}