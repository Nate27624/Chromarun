using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targyDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.gameObject.layer == 9)
        {
            collision.gameObject.SetActive(false);
        }
    }
}
