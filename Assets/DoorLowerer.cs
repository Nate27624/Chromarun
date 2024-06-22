using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLowerer : MonoBehaviour
{
    public bool lower;
    public bool raise;

    public bool deactivateObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lower)
        {
            if (this.transform.position.y > -98) this.transform.Translate(Vector3.down * 80 * Time.deltaTime); else lower = false;
        }
        if (raise)
        {
            if (this.transform.position.y < -94) this.transform.Translate(Vector3.up * 80 * Time.deltaTime); else raise = false;
        }


    }
}
