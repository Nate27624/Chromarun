using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XtoY : MonoBehaviour
{

    public GameObject main;
    public GameObject centerEye;
    public GameObject thisObjectMoves;

    public bool rotate;
    public bool rotateY = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thisObjectMoves.transform.position = new Vector3(main.transform.position.x + 5, main.transform.position.y - 5, main.transform.position.z + 95);
        if (rotate)
        {
            thisObjectMoves.transform.rotation = new Quaternion(0, main.transform.rotation.y + 45, 0, main.transform.rotation.w);
        }

        if (rotateY)
        {
            thisObjectMoves.transform.rotation = new Quaternion(0, centerEye.transform.rotation.y, 0, centerEye.transform.rotation.w);
        }
    }
}
