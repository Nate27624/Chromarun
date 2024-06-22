using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black2PlayerMover : MonoBehaviour
{
    public Vector3 sendPlayer;
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
            OVR.transform.position = sendPlayer;
        }
    }
}
