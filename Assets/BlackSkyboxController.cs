using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSkyboxController : MonoBehaviour
{
    public Material lightSource;

    public int rVal;
    public int gVal;
    public int bVal;

    public int intensity;
    // Start is called before the first frame update
    void Start()
    {
        rVal = 255;
        gVal = 0;
        bVal = 255;
    }


    // Update is called once per frame
    void Update()
    {
        lightSource.SetColor("_Tint", new Vector4(rVal, gVal, bVal, 255)); 


        if (gVal >= 255)
        {
            gVal = 255;
        }
        if (bVal >= 255)
        {
            bVal = 255;
        }
        if (rVal > 255)
        {
            rVal = 255;
        }


        if (rVal <= 0) rVal = 0;
        if (gVal <= 0) gVal = 0;
        if (bVal <= 0) bVal = 0;

        if (rVal <= 0 && gVal >= 255 && bVal > 0)
        {
            bVal -= intensity;
        }
        else if (bVal <= 0 && gVal >= 255 && rVal < 255)
        {
            rVal += intensity;
        }
        else if (rVal >= 255 && bVal <= 0 && gVal > 0)
        {
            gVal -= intensity;
        }
        else if (gVal <= 0 && rVal >= 255 && bVal < 255)
        {
            bVal += intensity;
        }
        else if (gVal <= 0 && bVal >= 255 && rVal > 0)
        {
            rVal -= intensity;
        }
        else if (rVal <= 0 && bVal >= 255 && gVal < 255)
        {
            gVal += intensity;
        }
    }
}
