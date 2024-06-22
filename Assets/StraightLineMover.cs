using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightLineMover : MonoBehaviour
{
    public GameObject OVRCam;
    public float speed;

    public bool forward;
    public bool down;
    public bool left;
    public bool right;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (forward) OVRCam.transform.Translate(Vector3.forward * (speed) * Time.deltaTime);
        if (down) OVRCam.transform.Translate(Vector3.back * (speed ) * Time.deltaTime);
        if(left) OVRCam.transform.Translate(Vector3.left * (speed) * Time.deltaTime);
        if(right) OVRCam.transform.Translate(Vector3.right * (speed) * Time.deltaTime);
    }
}
