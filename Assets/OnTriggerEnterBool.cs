using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterBool : MonoBehaviour
{
    public bool trigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6 || other.gameObject.layer == 3 || other.gameObject.layer == 8)
        {
            trigger = true;
        }
    }
}
