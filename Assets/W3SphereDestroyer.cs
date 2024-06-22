using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W3SphereDestroyer : MonoBehaviour
{
    public float despawnSpeed;
    public float alpha = 1/1000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        float speed = this.GetComponent<Rigidbody>().velocity.magnitude;
        if (this.transform.position.y < 5 || speed < 0.1)
        {
            this.GetComponent<SphereCollider>().enabled = false;
            //this.GetComponent<rapidColor>().enabled = false;
            this.transform.localScale = new Vector3(this.transform.localScale.x / despawnSpeed, this.transform.localScale.y / despawnSpeed, this.transform.localScale.z / despawnSpeed);
            if(this.transform.localScale.x < 0.1)
            {
                Destroy(this.gameObject);
            }
            Debug.Log("Destroying");
        }
    }
}
