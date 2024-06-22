using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XtoYLegit : MonoBehaviour
{
    public GameObject thisMoves;
    public GameObject thisIsParent;

    public bool changeYval;
    public Vector3 offset;
    public bool rotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thisMoves.transform.position = new Vector3(thisIsParent.transform.position.x + offset.x, thisIsParent.transform.position.y + offset.y, thisIsParent.transform.position.z + offset.z);
        if(changeYval) thisMoves.transform.rotation = new Quaternion(0, thisIsParent.transform.rotation.y, 0, thisIsParent.transform.rotation.w);
        if (rotate)
        {
            thisMoves.transform.rotation = new Quaternion(thisIsParent.transform.rotation.x,thisIsParent.transform.rotation.y,thisIsParent.transform.rotation.z,thisIsParent.transform.rotation.w);
        }
    }
}
