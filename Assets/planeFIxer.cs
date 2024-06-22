using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeFIxer : MonoBehaviour
{
    private Material mat;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        mat = this.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float scaleX = this.transform.localScale.x;
        float scaleY = this.transform.localScale.z;

        mat.SetTextureScale("_MainTex", new Vector2(scaleX * offset, scaleY * offset));
    }
}
