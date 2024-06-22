using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaAndDestroy : MonoBehaviour
{
    public bool destroy;
    public float timeToDissappear;
    public float alphaVal = 255;
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        destroy = false;
        mat = this.GetComponent<MeshRenderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        if (destroy)
        {
                 
            alphaVal -= timeToDissappear;
            if (alphaVal < 0) this.gameObject.SetActive(false);
            this.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", new Vector4(0,1,0, 20));
            Debug.Log(Mathf.CeilToInt(alphaVal));
        }  
    }
}
