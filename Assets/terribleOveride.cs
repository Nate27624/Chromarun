using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terribleOveride : MonoBehaviour
{
    public GameObject OVR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OVR.GetComponent<ContinuousMovement>().startGame = 1;
    }
}
