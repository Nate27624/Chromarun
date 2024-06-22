using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceFromOriginHeightSetter : MonoBehaviour
{

    private float height = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Mathf.Pow(((Mathf.Pow((this.transform.localPosition.x), 2)) + (Mathf.Pow((this.transform.localPosition.z), 2))), 1/2);
        height = Mathf.Pow(Mathf.Abs((5625 - Mathf.Pow(dist, 2))), 0.5f);
        this.transform.position = new Vector3(this.transform.position.x, height, this.transform.position.z);

    }
}
