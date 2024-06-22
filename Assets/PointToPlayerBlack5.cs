using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPlayerBlack5 : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;

    private bool hasBeenNear = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, this.transform.position) > 20f && !hasBeenNear)
        {
            transform.LookAt(player);
        }
        else
        {
            hasBeenNear = true;
        }
        
    }
}
