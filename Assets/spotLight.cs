using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotLight : MonoBehaviour
{
    public Transform cam;
    public GameObject lightObject;
    public Vector3 offset;
    public Vector3 rotationOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lightObject.transform.position = new Vector3(cam.position.x + offset.x, cam.position.y + offset.y, +cam.position.z + offset.z);
        lightObject.transform.eulerAngles = new Vector3(cam.eulerAngles.x + rotationOffset.x, cam.eulerAngles.y + rotationOffset.y, cam.eulerAngles.z + rotationOffset.z);
    }
}
