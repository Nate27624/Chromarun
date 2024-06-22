using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black5Resetter : MonoBehaviour
{
    public GameObject[] platforms;
    public GameObject raisePlatform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 8)
        {
            for(var i = 0; i < platforms.Length; i++)
            {
                platforms[i].GetComponent<DoorLowerer>().lower = true;
            }
            raisePlatform.GetComponent<DoorLowerer>().raise = true;
        }
    }

}
