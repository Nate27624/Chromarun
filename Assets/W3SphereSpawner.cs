using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W3SphereSpawner : MonoBehaviour
{
    public GameObject sphere;
    public Vector3 min;
    public Vector3 max;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        foreach(Transform child in this.transform)
        {
            count++;
        }

        if(count <= 40)
        {
            GameObject temp = Instantiate(sphere, new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z)), Quaternion.identity, this.transform);
            temp.GetComponent<W3SphereDestroyer>().enabled = true;
        }
    }
}
