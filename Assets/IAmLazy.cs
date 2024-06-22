using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAmLazy : MonoBehaviour
{
    public GameObject platform;
    public GameObject OVR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(platform.transform.position.z < 0)
        {
            platform.transform.position = new Vector3(0, 0, 0);
            platform.GetComponent<XtoYLegit>().enabled = false;
            platform.SetActive(false);
        }
    }
}
