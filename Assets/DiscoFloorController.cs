using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoFloorController : MonoBehaviour
{
    //Universal Variables
    public GameObject[] Rows;
    public Material[] Mats;
    int curColor = 0;
    public float speed;
    private float timer = 1;
    public bool update = false;
    //All Floor Options
    public bool xPattern;
    public bool straightLinePattern;
    public bool randomDown;
    public bool sphereBounce;
    public bool bigSphereBounce;
    public bool planeBounce;
    public bool bigPlaneBounce;
    public bool rotateColorSpheres;
    //X Pattern Variables
    private Material main;
    private Material sub;
    //RandomDown variables
    public Material[] currentMat;
    public Material[] futureMat;
    //SphereBounce
    public GameObject sphere;
    public GameObject bigSphere;
    public GameObject smallPlane;
    public GameObject bigPlane;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < speed)
        {
            timer = 1;
            //Types of floor patterns
            if (xPattern)
            {
                XPattern();
            }
            else if (straightLinePattern)
            {
                StraightLinePattern();
            }
            else if (randomDown)
            {
                RandomDown();
            }

            //Types of overlays
            if (sphereBounce)
            {
                sphere.SetActive(true);
            }
            else
            {
                sphere.SetActive(false);
            }

            if (bigSphereBounce)
            {
                bigSphere.SetActive(true);
            }
            else
            {
                bigSphere.SetActive(false);
            }

            if (planeBounce)
            {
                smallPlane.SetActive(true);
            }
            else
            {
                smallPlane.SetActive(false);
            }

            if (bigPlaneBounce)
            {
                bigPlane.SetActive(true);
            }
            else
            {
                bigPlane.SetActive(false);
            }

            //Mess with the color of the overlays
            if (rotateColorSpheres)
            {
                RotateColorSpheres();
            }
        }
       

    }

    public void StraightLinePattern()
    {
            if (curColor > Rows.Length-3)
            {
                curColor = 0;
            }

           
            curColor++;
            for (var i = 0; i < Rows.Length; i++)
            {
                int colorIndex = 0;
                colorIndex = i + curColor;
                while (colorIndex > Mats.Length - 1)
                {
                    colorIndex -= (Mats.Length);
                }
                foreach (Transform child in Rows[i].transform)
                {
                    //Debug.Log(colorIndex);
                    child.GetComponent<MeshRenderer>().material = Mats[colorIndex];
                }
            
        }
        
        
       
        
    }
    public void XPattern()
    {
        
         
            main = Mats[Random.Range(0, Mats.Length - 1)];
            sub = Mats[Random.Range(0, Mats.Length - 1)];

            while (main.name == sub.name)
            {
                main = Mats[Random.Range(0, Mats.Length - 1)];
                sub = Mats[Random.Range(0, Mats.Length - 1)];
            }


            for (var i = 0; i < Rows.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    foreach (Transform child in Rows[i].transform)
                    {
                        if (int.Parse(child.name) % 2 == 0 || child.name == "0")
                        {
                            child.GetComponent<MeshRenderer>().material = main;
                        }
                        else
                        {
                            child.GetComponent<MeshRenderer>().material = sub;
                        }
                    }
                }

                if ((i + 1) % 2 == 1)
                {
                    foreach (Transform child in Rows[i].transform)
                    {
                        if (int.Parse(child.name) % 2 == 1)
                        {
                            child.GetComponent<MeshRenderer>().material = main;
                        }
                        else
                        {
                            child.GetComponent<MeshRenderer>().material = sub;
                        }
                    }
                }
            
        }
    }
    public void Diagonal() { 

    }

    public void RandomDown()
    {
        
            for (var i = 0; i < 9; i++)
            {
            

                int oCount = 0;
                if (i + 1 < Rows.Length)
                {
                    foreach (Transform child in Rows[i + 1].transform)
                    {
                        futureMat[oCount] = child.GetComponent<MeshRenderer>().material;
                        oCount++;
                    }
                }
               
                int ooCount = 0;
                if (i + 1 < Rows.Length)
                {
                    foreach (Transform child in Rows[i + 1].transform)
                    {
                        child.GetComponent<MeshRenderer>().material = currentMat[ooCount];
                       ooCount++;
                    }
                }

                for (var c = 0; c < currentMat.Length; c++)
                {
                    currentMat[c] = futureMat[c];
                }

         
                if (i == 0)
                {
                    int count = 0;
                    foreach (Transform child in Rows[i].transform)
                    {
                        int temp = Random.Range(0, Mats.Length - 1);
                        child.GetComponent<MeshRenderer>().material = Mats[temp];
                        currentMat[count] = Mats[temp];
                        count++;
                    }
                }

            
        } 
    }

    public void RotateColorSpheres()
    {
            sphere.GetComponent<MeshRenderer>().material = Mats[Random.Range(0, Mats.Length - 1)];
            bigSphere.GetComponent<MeshRenderer>().material = Mats[Random.Range(0, Mats.Length - 1)];
        smallPlane.GetComponent<MeshRenderer>().material = Mats[Random.Range(0, Mats.Length - 1)];
        bigPlane.GetComponent<MeshRenderer>().material = Mats[Random.Range(0, Mats.Length - 1)];
    }
}
