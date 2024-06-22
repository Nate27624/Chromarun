using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsuleGenerator : MonoBehaviour
{
    public GameObject cube;

    public float minX;
    public float maxX;

    public float minZ;
    public float maxZ;

    public int amountOfCubesToSpawn;

    public Transform placeCubeTransform;

    public Transform cubeParent;

    public GameObject tempCube;

    // Start is called before the first frame update
    void Start()
    {

        for (var i = 0; i < amountOfCubesToSpawn; i++)
        {
            placeCubeTransform.position = new Vector3(Random.Range(minX, maxX), 2, Random.Range(minZ, maxZ));
            //placeCubeTransform.position = new Vector3(0, 0, 0);
            Debug.Log(placeCubeTransform);
            tempCube = Instantiate(cube, placeCubeTransform.position, Quaternion.Euler(Random.Range(0,361),Random.Range(0,361),Random.Range(0,361)), cubeParent);
            tempCube.GetComponent<RotateAroundObject>().rotationSpeed = Random.Range(75, 255);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
