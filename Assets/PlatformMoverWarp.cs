using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoverWarp : MonoBehaviour
{
    public float minVal;
    public float maxVal;

    public float newXVal;
    public GameObject areaXVal;

    public Transform platform;
    public float speedStart;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = speedStart;
        
        maxVal = maxVal + areaXVal.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        platform.Translate(Vector2.left * speed * Time.deltaTime);
        if (platform.localPosition.x >= maxVal)
        {
            platform.transform.position = new Vector3(newXVal, platform.position.y, platform.position.z);
        }
        if (platform.localPosition.x <= minVal)
        {
            speed = -speedStart;
        }


    }
}
