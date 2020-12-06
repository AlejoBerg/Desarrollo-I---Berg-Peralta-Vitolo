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
    [SerializeField] private GameObject newPosPlat2;
    [SerializeField] private GameObject newPosPlat3;
    [SerializeField] private GameObject bridgeParticles1;
    [SerializeField] private GameObject bridgeParticles2;
    [SerializeField] private GameObject bridgeParticles3;
    [SerializeField] private float platformsSpeed;
    private bool doOnce = true;
    private Rigidbody platform1RB;
    private Rigidbody platform2RB;
    private Rigidbody platform3RB;
    private bool doOnce2 = true;
    private bool doOnce3 = true;
    private bool doOnce4 = true;

    private void Awake()
    {
        platform1RB = platform1.GetComponent<Rigidbody>();
        platform2RB = platform2.GetComponent<Rigidbody>();
        platform3RB = platform3.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        bridgeParticles1.GetComponent<FadeOutParticles>().ExecuteFadeParticle();
        bridgeParticles2.GetComponent<FadeOutParticles>().ExecuteFadeParticle();
        bridgeParticles3.GetComponent<FadeOutParticles>().ExecuteFadeParticle();
    }

    void Update()
    {
        if (GameManager.ItemsAmount2 == 5 && doOnce)
        {
           MovePlatform1();
        }

        if (GameManager.ParchmentsAmount == 1 && doOnce2) // valores a definir
        {
            MovePlatform1Up();
            doOnce2 = false;
        }
        else if (GameManager.ParchmentsAmount == 2 && doOnce3)  // valores a definir
        {
            MovePlatform2();
        }
        else if (GameManager.ParchmentsAmount == 3 && doOnce4)  // valores a definir
        {
            MovePlatform3();
        }
    }

    //FALTA AJUSTAR BIEN LOS MOVIMIENTOS DE LAS PLATAFORMAS
    
    void MovePlatform1()
    {
        platform1RB.MovePosition(Vector3.MoveTowards(platform1RB.position, newPosPlat1.transform.position, platformsSpeed * Time.deltaTime));

        if (platform1RB.position == newPosPlat1.transform.position) { doOnce = false; }
    }
    
    void MovePlatform1Up()
    {
        bridgeParticles1.GetComponent<FadeInParticles>().ExecuteFadeParticle();
        //Agregar que suba la primer plataforma
    }
    
    void MovePlatform2()
    {
        bridgeParticles1.GetComponent<FadeOutParticles>().ExecuteFadeParticle();
        platform2RB.MovePosition(Vector3.MoveTowards(platform2RB.position, newPosPlat2.transform.position, platformsSpeed * Time.deltaTime));

        if (platform2RB.position == newPosPlat2.transform.position)
        {
            doOnce3 = false;
            bridgeParticles2.GetComponent<FadeInParticles>().ExecuteFadeParticle();
        }
    }
    
    void MovePlatform3()
    {
        bridgeParticles2.GetComponent<FadeOutParticles>().ExecuteFadeParticle();
        platform3RB.MovePosition(Vector3.MoveTowards(platform3RB.position, newPosPlat3.transform.position, platformsSpeed * Time.deltaTime));
      
        if (platform2RB.position == newPosPlat2.transform.position)
        {
            doOnce4 = false;
            bridgeParticles3.GetComponent<FadeInParticles>().ExecuteFadeParticle();
        }
    }
}