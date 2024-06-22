using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public GameObject light;
    public int odds;

    public float timer = 1;
    public float RandVal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RandVal = Random.value;
        timer -= Time.deltaTime;
        if(RandVal > 0.8  && timer < 0.8)
        {
            light.GetComponent<Light>().intensity = 0;
            timer = 1;
        }
        else
        {
            light.GetComponent<Light>().intensity = 5;
        }
    }
}
