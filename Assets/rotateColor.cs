using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateColor : MonoBehaviour
{
    public GameObject colorSpin;
    public float rotateAmount;

    private float rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation += rotateAmount;
        colorSpin.transform.rotation = Quaternion.Euler(90, rotation, 0);
    }
}
