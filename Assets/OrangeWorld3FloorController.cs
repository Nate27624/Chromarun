using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeWorld3FloorController : MonoBehaviour
{
    public Material orangeMat;
    public Material blackMat;

    private float timer = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = 0.5f;
            foreach(Transform child in this.transform)
            {
                if(child.transform.GetComponent<MeshRenderer>().material.name == "5 1")
                {
                    child.transform.GetComponent<MeshRenderer>().material = blackMat;
                }
                else
                {
                    child.transform.GetComponent<MeshRenderer>().material = orangeMat;
                }
            }
        }
    }
}
