using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueRendererDisabler : MonoBehaviour
{
    public GameObject colliderParent;
    // Start is called before the first frame update
    private void Start()
    {
        foreach(Transform child in colliderParent.transform)
        {
            child.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
