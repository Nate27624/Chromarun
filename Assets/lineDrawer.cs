using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineDrawer : MonoBehaviour
{
    public GameObject targy;
    public GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<LineRenderer>().SetPosition(0, sphere.transform.position);
        this.GetComponent<LineRenderer>().SetPosition(1, targy.transform.position);
    }
}
