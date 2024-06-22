using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecenterPlayer : MonoBehaviour
{
    public GameObject OVR;
    public GameObject mainCam;

    public bool recenterOnStart;

    public bool recenterNow;
    // Start is called before the first frame update
    void Start()
    {
        if (recenterOnStart)
        {
            recenterPlayer();
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        if (recenterNow)
        {
            recenterPlayer();
            recenterNow = false;
        }
    }

    public void recenterPlayer()
    {
        OVR.transform.position = new Vector3(OVR.transform.position.x - mainCam.transform.localPosition.x, OVR.transform.position.y - mainCam.transform.localPosition.y, OVR.transform.position.z - mainCam.transform.localPosition.z);
        OVR.transform.eulerAngles = new Vector3(0, OVR.transform.eulerAngles.y - mainCam.transform.eulerAngles.y, 0);
    }
}
