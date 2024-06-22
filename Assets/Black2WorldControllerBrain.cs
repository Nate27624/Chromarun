using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black2WorldControllerBrain : MonoBehaviour
{
    public GameObject[] door1False;
    public GameObject[] door2False;
    public GameObject[] door3False;
    public GameObject[] finalSetFalse;

    public GameObject OVR;

    public bool beaten1;
    public bool beaten2;
    public bool beaten3;
    // Start is called before the first frame update
    void Start()
    {
        beaten1 = false;
        beaten2 = false;
        beaten3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (beaten1)
        {
            for(var i = 0;i < door1False.Length; i++)
            {
                door1False[i].SetActive(false);
            }
        }

        if (beaten2)
        {
            for (var i = 0; i < door2False.Length; i++)
            {
                door2False[i].SetActive(false);
            }
        }

        if (beaten3)
        {
            for (var i = 0; i < door3False.Length; i++)
            {
                door3False[i].SetActive(false);
            }
        }

        if (beaten3 && beaten2 && beaten1)
        {
            for (var i = 0; i < finalSetFalse.Length; i++)
            {
                finalSetFalse[i].SetActive(false);
            }
        }
    }
}
