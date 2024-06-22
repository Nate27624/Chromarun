using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forwardMovement : MonoBehaviour
{
    public float zVal;
    public float speed;

    public bool move;
    public bool die;
    // Start is called before the first frame update
    void Start()
    {
       zVal = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            zVal += speed;
            this.transform.position = new Vector3(zVal, this.transform.position.y, this.transform.position.z);
        }

        if (die)
        {
            move = false;
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
