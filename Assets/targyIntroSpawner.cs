using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targyIntroSpawner : MonoBehaviour
{
    public GameObject targy;

    public GameObject min1;
    public GameObject min2;

    public GameObject instantiateCube;
    public Vector3 vectorCube;

    public GameObject tempInstantiateTargy;
    public GameObject targyParent;

    public Texture2D[] textures;
    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0; i < 90; i++)
        {
            vectorCube = new Vector3(Random.Range(min1.transform.position.x, min2.transform.position.x), Random.Range(min1.transform.position.y, min2.transform.position.y), Random.Range(min1.transform.position.z, min2.transform.position.z));

            tempInstantiateTargy = Instantiate(targy, vectorCube, Quaternion.Euler(0, 90, 0), targyParent.transform);
            tempInstantiateTargy.GetComponent<forwardMovement>().speed = -1 * Random.Range(1000, 5000) / 1000;
            tempInstantiateTargy.transform.rotation = Quaternion.Euler((tempInstantiateTargy.GetComponent<forwardMovement>().speed * 15), 90, 0);

            //tempInstantiateTargy.GetComponentInChildren<MeshRenderer>().material.SetTexture(Shader.PropertyToID("_MainTex"), textures[Random.Range(0, textures.Length)]);
            tempInstantiateTargy.GetComponentInChildren<MeshRenderer>().material.mainTexture = textures[Random.Range(0, textures.Length)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
