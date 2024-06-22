using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowColorSystemBlack5 : MonoBehaviour
{
    public Material ringMat;

    public Color[] colors;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ringMat.SetColor("_TintColor", colors[Random.Range(0, colors.Length)]);
    }
}
