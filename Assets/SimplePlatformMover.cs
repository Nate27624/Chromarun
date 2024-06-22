using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatformMover : MonoBehaviour
{
    public GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        platform.transform.Translate(Vector3.back * 30 * Time.deltaTime);
    }
}
