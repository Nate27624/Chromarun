using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargyCharacter : MonoBehaviour
{

    public GameObject cubeSpawnIn;

    public Transform randomLocation;
    public Vector3 minScale;
    public Vector3 maxScale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        randomLocation.position = (0.25f * Random.insideUnitSphere) + this.transform.position ;

        GameObject temp;
        temp = Instantiate(cubeSpawnIn,randomLocation.position,Quaternion.identity,Camera.main.transform);
        temp.gameObject.transform.localScale = new Vector3(Random.Range(minScale.x, maxScale.x), Random.Range(minScale.y, maxScale.y), Random.Range(minScale.z, maxScale.z));
        temp.name = "Not the main dude";
    }
}
