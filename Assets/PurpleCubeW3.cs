using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleCubeW3 : MonoBehaviour
{
    public GameObject cubePref;
    private GameObject tempObstacle;
    public int cubesCount;
    public Transform instanceCubePos;

    public Vector3 min;
    public Vector3 max;
    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0; i < cubesCount; i++)
        {
            int sped = 0;
            if (Random.Range(0, 20) > 10) {
                sped = Random.Range(-10, -5);
            }
            else
            {
                sped = Random.Range(5, 10);
            }
             
            instanceCubePos.position = new Vector3(Random.Range(min.x, max.x), 1.5f, Random.Range(min.z, max.z));
            tempObstacle = Instantiate(cubePref, instanceCubePos.position, Quaternion.identity, this.transform);
            tempObstacle.GetComponent<PlatformMoverForwardBack>().speedStart = Random.Range(10, 30);
            tempObstacle.GetComponent<PlatformMoverLeftRight>().speedStart = sped;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        foreach(Transform child in this.transform)
        {
            count++;
        }
        if(count < cubesCount)
        {
            int sped = 0;
            if (Random.Range(0, 20) > 10)
            {
                sped = Random.Range(-10, -5);
            }
            else
            {
                sped = Random.Range(5, 10);
            }

            instanceCubePos.position = new Vector3(Random.Range(min.x, max.x), 1.5f, 330);
            tempObstacle = Instantiate(cubePref, instanceCubePos.position, Quaternion.identity, this.transform);
            tempObstacle.GetComponent<PlatformMoverForwardBack>().speedStart = Random.Range(10, 30);
            tempObstacle.GetComponent<PlatformMoverLeftRight>().speedStart = sped;
        }
    }
}
