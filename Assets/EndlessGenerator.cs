using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessGenerator : MonoBehaviour
{
    public Vector3 generationCube;
    public GameObject straightArea;
    public GameObject turnArea;
    public GameObject[] instantiateGameObject = new GameObject[100];
    public GameObject generationAreasParent;

    private int randomMovement;
    public int rotation = 90;
    public int rotationArea = 90;
    public string directionChange = "XR";
    private string previousDirection = "XR";
    private bool hasChangedDirection;

    public int directionX;
    public int directionY;
    public int directionZ;

    public LayerMask layerMask;
    public GameObject VRPlayer;

    public int gameObjectsKeep = 0;
    public GameObject visibleArea;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        generateMaze();
        //deleteThem();
    }

    public void generateMaze()
    {
        hasChangedDirection = false;

        
        if(directionChange == "XR")
        {
            

            if(Random.Range(0,20) > 18)
            {
                if (!hasChangedDirection)
                {
                    previousDirection = directionChange;
                    directionChange = "YR";
                    rotation = 180;
                    hasChangedDirection = true;
                }
              
            }
            if(Random.Range(0,20) > 18)
            {
                if (!hasChangedDirection)
                {
                    previousDirection = directionChange;
                    directionChange = "YL";
                    rotation = 0;
                    hasChangedDirection = true;
                }
            }
        }

        if (directionChange == "XL")
        {
            
            if (Random.Range(0, 20) > 18)
            {
                if (!hasChangedDirection)
                {
                    previousDirection = directionChange;
                    directionChange = "YR";
                    rotation = 0;
                    hasChangedDirection = true;
                }
            }
            if (Random.Range(0, 20) > 18)
            {
                if (!hasChangedDirection)
                {
                    previousDirection = directionChange;
                    directionChange = "YL";
                    rotation = 180;
                    hasChangedDirection = true;
                }
            }
        }

        if (directionChange == "YR")
        {
            
            if (Random.Range(0, 20) > 15)
            {
                if (!hasChangedDirection)
                {
                    previousDirection = directionChange;
                    directionChange = "XR";
                    rotation = 90;
                    hasChangedDirection = true;
                }
            }
            if (Random.Range(0, 20) > 15)
            {
                if (!hasChangedDirection)
                {
                    previousDirection = directionChange;
                    directionChange = "XL";
                    rotation = 270;
                    hasChangedDirection = true;
                }
            }
        }

        if (directionChange == "YL")
        {
           
            if (Random.Range(0, 20) > 15)
            {
                if (!hasChangedDirection)
                {
                    previousDirection = directionChange;
                    directionChange = "XR";
                    rotation = 270;
                    hasChangedDirection = true;
                }
            }
            if (Random.Range(0, 20) > 15)
            {
                if (!hasChangedDirection)
                {
                    previousDirection = directionChange;
                    directionChange = "XL";
                    rotation = 90;
                    hasChangedDirection = true;
                }
            }
        }

        if (!hasChangedDirection)
        {
            if (directionChange == "XR")
            {
                directionX += 1;
            }
            if (directionChange == "XL")
            {
                directionX -= 1;
            }
            if (directionChange == "YR")
            {
                directionZ += 1;
            }
            if (directionChange == "YL")
            {
                directionZ -= 1;
            }
        }
       

       

        if (hasChangedDirection)
        {
            if (previousDirection + directionChange == "XRYL")
            {
                rotationArea = 90;
                directionX += 1;

            }

            if(previousDirection + directionChange == "XRYR")
            {
                rotationArea = 180;
                directionX += 1;
            }

            if(previousDirection + directionChange == "XLYL")
            {
                rotationArea = 0;
                directionX -= 1;
            }

            if(previousDirection + directionChange == "XLYR")
            {
                rotationArea = 270;
                directionX -= 1;
            }

            if(previousDirection + directionChange == "YRXL")
            {
                rotationArea = 90;
                directionZ += 1;
            }

            if(previousDirection + directionChange == "YRXR")
            {
                rotationArea = 0;
                directionZ += 1;
            }

            if(previousDirection + directionChange == "YLXL")
            {
                rotationArea = 180;
                directionZ -= 1;
            }

            if(previousDirection + directionChange == "YLXR")
            {
                rotationArea = 270;
                directionZ -= 1;
            }

            
                generationCube = new Vector3(10 * directionX, 0, 10 * directionZ);
                instantiateGameObject[gameObjectsKeep] = Instantiate(turnArea, generationCube, Quaternion.Euler(0, rotationArea, 0), generationAreasParent.transform);
                gameObjectsKeep += 1;
          
        }
        else
        {
           
            
                generationCube = new Vector3(10 * directionX, 0, 10 * directionZ);
                instantiateGameObject[gameObjectsKeep] = Instantiate(straightArea, generationCube, Quaternion.Euler(0, rotation, 0), generationAreasParent.transform);
                gameObjectsKeep += 1;
        }

    }

    public void deleteThem()
    {
        foreach(GameObject tempArea in instantiateGameObject)
        {
            if (!tempArea.GetComponent<MeshRenderer>().isVisible)
            {
                tempArea.SetActive(false);
            }
        }
    }
}
