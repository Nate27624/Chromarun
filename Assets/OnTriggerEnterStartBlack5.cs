using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterStartBlack5 : MonoBehaviour
{
    public GameObject player;
    public GameObject Sphere;
    public Material GreenMat;
    public Material DefMat;

    public bool sceneOne;
    public bool sceneTwo;

    public int sceneNumber;

    public AudioSource scream;

    public void Start()
    {
        Sphere.GetComponent<MeshRenderer>().material = DefMat;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            if (sceneOne)
            {
                Sphere.GetComponent<MeshRenderer>().material = GreenMat;
                player.GetComponent<ContinuousMovement>().startGame = 1;
                player.GetComponent<ContinuousMovementBlack5>().startGame = 1;
                sceneNumber = 1;
                scream.Play();
            }

            if (sceneTwo)
            {
                Sphere.GetComponent<MeshRenderer>().material = GreenMat;
                player.GetComponent<ContinuousMovementBlack5>().enabled = false;
                player.GetComponent<ContinuousMovement>().speed = 5 + 3 / 4;
                player.GetComponent<ContinuousMovement>().startGame = 1;
                sceneNumber = 45;
            }
        }
     }
 }
