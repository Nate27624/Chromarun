using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleCubeW3Destroyer : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.z < 12 || this.transform.position.x < -50 || this.transform.position.x > 50)
        {
            Destroy(this.transform.gameObject);
        }
    }
}
