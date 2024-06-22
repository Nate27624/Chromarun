using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black2TriggerBrainController : MonoBehaviour
{
    public Black2WorldControllerBrain black2Brain;
    public bool door1;
    public bool door2;
    public bool door3;

    public GameObject OVR;
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

        if (other.gameObject.layer == 8 || other.gameObject.layer == 6 || other.gameObject.layer == 3)
        {
            if (door1)
            {
                black2Brain.beaten1 = true;
            }else if (door2)
            {
                black2Brain.beaten2 = true;
            }else if (door3)
            {
                black2Brain.beaten3 = true;
            }

            OVR.transform.position = new Vector3(0, 1, 0);
            OVR.GetComponent<RecenterPlayer>().recenterPlayer();
        }
    }
}
