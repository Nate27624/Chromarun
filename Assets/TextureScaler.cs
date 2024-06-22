using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScaler : MonoBehaviour
{
    public bool flipAxis = false;
    public string first = "x";
    // Start is called before the first frame update
    void Start()
    {
        Vector2 curScale = this.GetComponent<MeshRenderer>().material.GetTextureScale("_BaseMap");
        if (!flipAxis)
        {
            this.gameObject.GetComponent<MeshRenderer>().material.SetTextureScale("_BaseMap", new Vector2(curScale.x * this.gameObject.transform.localScale.x, curScale.y * this.transform.localScale.y));
        }
        else
        {
            this.gameObject.GetComponent<MeshRenderer>().material.SetTextureScale("_BaseMap", new Vector2(curScale.x * this.gameObject.transform.localScale.z, curScale.y * this.transform.localScale.x));
        }
    }
}
