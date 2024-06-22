using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomY : MonoBehaviour
{
    public GameObject cube;
    public float miny;
    public float maxy;
    // Start is called before the first frame update
    void Start()
    {
        cube.transform.position = new Vector3(cube.transform.position.x, Random.Range(miny, maxy),cube.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
