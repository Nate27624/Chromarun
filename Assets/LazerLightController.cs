using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerLightController : MonoBehaviour
{
    public bool rotateColor;
    public GameObject lazer;
    public bool rotateY;
    public bool rotateX;
    public bool rotateZ;

    public Vector2 limX;
    public Vector2 limY;
    public Vector2 limZ;

    private float xVal;
    private float yVal;
    private float zVal;

    public float xValSpeed;
    public float yValSpeed;
    public float zValSpeed;

    public bool incXVal;
    public bool incYVal;
    public bool incZVal;

    private float timer;
    public Material[] Mats;
    public Material startMat;
    // Start is called before the first frame update
    void Start()
    {
        xVal = 0;
        yVal = 0;
        zVal = 180;
        timer = 0;
        lazer.GetComponent<MeshRenderer>().material = startMat;
    }

    // Update is called once per frame
    void Update()
    {
        //RotateX and determine directions
        if (rotateX)
        {
            if (lazer.transform.localEulerAngles.x > limX.y)
            {
                incXVal = false;
            }
            else if (lazer.transform.localEulerAngles.x < limX.x)
            {
                incXVal = true;
            }
        }

        if (rotateY)
        {
            if (lazer.transform.localEulerAngles.y > limY.y)
            {
                incYVal = false;
            }
            else if (lazer.transform.localEulerAngles.y < limY.x)
            {
                incYVal = true;
            }

        }

        if (lazer.transform.localEulerAngles.z > limZ.y)
        {
            incZVal = false;
        }
        else if (lazer.transform.localEulerAngles.z < limZ.x)
        {
            incZVal = true;
        }

        if (incXVal)
        {
            xVal += Time.deltaTime * xValSpeed;
        }
        else
        {
            xVal -= Time.deltaTime * xValSpeed;
        }

        if (incYVal)
        {
            yVal += Time.deltaTime * yValSpeed;
        }
        else
        {
            yVal -= Time.deltaTime * yValSpeed;
        }

        if (incZVal)
        {
            zVal += Time.deltaTime * zValSpeed;
        }
        else
        {
            zVal -= Time.deltaTime * zValSpeed;
        }

        lazer.transform.localEulerAngles = new Vector3(xVal, yVal, zVal);

        if (rotateColor)
        {
            timer -= Time.deltaTime;
            if(timer < -0.25f)
            {
                timer = 0;
                lazer.GetComponent<MeshRenderer>().material = Mats[Random.Range(0, Mats.Length - 1)];
            }
        }

    }
}
