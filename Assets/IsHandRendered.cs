using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHandRendered : MonoBehaviour
{
    private SkinnedMeshRenderer thisRend;

    public bool isRendered = false;
    // Start is called before the first frame update
    void Start()
    {
        thisRend = this.GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thisRend.isVisible) isRendered = true; else isRendered = false;
    }
}
