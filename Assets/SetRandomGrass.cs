using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRandomGrass : MonoBehaviour
{
    public GameObject grassObject;
    public Transform minLocation;
    public Transform maxLocation;
    public int grassNumber;
    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0; i < grassNumber; i++)
        {
            Instantiate(grassObject, new Vector3(Random.Range(minLocation.position.x, maxLocation.position.x), 0, Random.Range(minLocation.position.z, maxLocation.position.z)), Quaternion.EulerAngles(0,Random.Range(0,180),0));
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
