using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introSphereSpawner : MonoBehaviour
{
    public GameObject sphere;
    public GameObject colliderSphere;
    public Material[] materials;

    public Vector3 minVect;
    public Vector3 maxVect;

    public float minScale;
    public float maxScale;

    public int sphereNum;
    public GameObject sphereParent;
    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0; i < sphereNum; i++)
        {
            GameObject tempSphere;
            float rand = Random.Range(minScale, maxScale);
            tempSphere = Instantiate(sphere, new Vector3(Random.Range(minVect.x, maxVect.x), Random.Range(minVect.y, maxVect.y), Random.Range(minVect.z, maxVect.z)), new Quaternion(0, 0, 0, 0), sphereParent.transform);
            tempSphere.transform.localScale = new Vector3(rand, rand, rand);
            tempSphere.transform.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length - 1)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
