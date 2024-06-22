using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneBlack5Controller : MonoBehaviour
{
    public GameObject[] disable;
    public GameObject[] enable;

    public OnTriggerEnterStartBlack5 sphere;

    //public 
    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0; i < disable.Length; i++)
        {
            disable[i].SetActive(true);
        }
        for (var i = 0; i < enable.Length; i++)
        {
            enable[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sphere.sceneNumber == 1)
        {
            for (var i = 0; i < disable.Length; i++)
            {
                disable[i].SetActive(false);
            }
            for (var i = 0; i < enable.Length; i++)
            {
                enable[i].SetActive(true);
            }
            sphere.sceneNumber = 999;
        }
    }
}
