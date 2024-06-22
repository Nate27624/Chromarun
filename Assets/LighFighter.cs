using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighFighter : MonoBehaviour
{
    public float timeToDissappear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.gameObject.layer == 9)
        {
            collision.GetComponent<PlatformMoverAdvanced>().lightHit = true;
        }
        
    }
}
