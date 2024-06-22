using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessGeneratorv2 : MonoBehaviour
{
    public GameObject XRRig;
    public GameObject XRRigCamera;
    public GameObject AreaDetectionCube;
    public GameObject OtherAreaDetectionCube;
    public int XRRigX;
    public int XRRigZ;

    public LayerMask layerMask;
    public LayerMask areaCubeLayerMask;

    private bool hasStartedGenerating = false;
    public GameObject[] straightAreas;
    public GameObject[] leftAreas;
    public GameObject[] rightAreas;
    public GameObject areasParent;
    public Material[] Materials;

    public string previousDirection = "U";
    public string otherPreviousDirection = "D";
    public int scanAmount = 8;

    public float scanRange;
    public string resultTag;
    public string otherResultTag;

    private bool otherAreaHit = false;
    private bool areaHit = false;

    public bool showScanLines = false;

    private GameObject otherTempArea;
    private GameObject tempArea;

    public GameObject distanceController;

    public bool randomColors;

    private int timer = 1;
    private int counter = 1;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        timer++;
        if(timer % 4 == 0)
        {
            counter++;
            if(counter % 2 == 0)
            {
                moveAreaCube();
            }
            else
            {
                moveOtherAreaCube();
            }
        }
            


        checkPlayerPos();
        //Debug.Log("Ray Hit: "+rayCayst());
        //Debug.Log(otherWhenToGenerate());
        if(showScanLines) Debug.Log(whenToGenerate() + " " + rayCayst());
        //Debug.Log(previousDirection);

        //Debug.Log(hasStartedGenerating);
    }
    public void checkPlayerPos()
    {
        XRRigZ = 10 * Mathf.RoundToInt(XRRig.transform.position.z / 10);
        XRRigX = 10 * Mathf.RoundToInt(XRRig.transform.position.x / 10);

    }
    public string rayCayst()
    {
        /*
        areaHit = false;
        otherAreaHit = false;
        for (var i = 0; i < scanAmount; i++)
        {
            Vector3 tempDirection = XRRigCamera.transform.TransformDirection(Vector3.forward);

            Vector3 finalDirectionToPoint = new Vector3(tempDirection.x + (scanRange / 20 * Random.value * Random.Range(-1, 2)), 0, tempDirection.z + (scanRange / 20 * Random.value * Random.Range(-1, 2)));

            RaycastHit hit;

            // Debug.Log("Final Direction To Point: " + finalDirectionToPoint + "Temp, No Mod:" + tempDirection);
            if(showScanLines) Debug.DrawLine(XRRig.transform.position, 200 * finalDirectionToPoint, Color.red, 1f);
            
            if (Physics.Raycast(XRRig.transform.position, finalDirectionToPoint, out hit, Mathf.Infinity, layerMask))
            {
                if (hit.transform.CompareTag("OutsideEndless"))
                {
                    return "A";
                }else if (hit.transform.CompareTag("AreaDetectionCube"))
                {
                    return "B";
                }else if (hit.transform.CompareTag("OtherAreaDetectionCube"))
                {
                    return "C";
                }
            }
        }
        */ 
        return "A";
    }
    public string whenToGenerate()
    {
        RaycastHit hit;
        if (Physics.Raycast(AreaDetectionCube.transform.position, Vector3.down, out hit, 100, areaCubeLayerMask))
        {
            //Detect if the area is straight and the resulting direction the cube should move in
            resultTag = hit.transform.gameObject.tag;
            if (resultTag == "U")
            {
                if (hit.transform.eulerAngles.y == 180 || hit.transform.eulerAngles.y == -180)
                {
                    previousDirection = "D";
                    return "D";
                }
                else if (hit.transform.eulerAngles.y == 0)
                {
                    previousDirection = "U";
                    return "U";
                } else if (hit.transform.eulerAngles.y == 270)
                {
                    previousDirection = "L";
                    return "L";
                }
                else if (hit.transform.eulerAngles.y == 90)
                {
                    previousDirection = "R";
                    return "R";
                }
                //Else the tag might be turning right
            } else if (resultTag == "R")
            {
                if (hit.transform.eulerAngles.y == 90)
                {
                    previousDirection = "D";
                    return "D";
                }
                else if (hit.transform.eulerAngles.y == 0)
                {
                    previousDirection = "R";
                    return "R";
                } else if (hit.transform.eulerAngles.y == 180 || hit.transform.eulerAngles.y == -180)
                {
                    previousDirection = "L";
                    return "L";
                } else if (hit.transform.eulerAngles.y == 270)
                {
                    previousDirection = "U";
                    return "U";
                }
                //Lets detect the left turn now
            } else if (resultTag == "L")
            {
                if (hit.transform.eulerAngles.y == 90)
                {
                    previousDirection = "L";
                    return "L";
                }
                else if (hit.transform.eulerAngles.y == 0)
                {
                    previousDirection = "D";
                    return "D";
                }
                else if (hit.transform.eulerAngles.y == 180 || hit.transform.eulerAngles.y == -180)
                {
                    previousDirection = "U";
                    return "U";
                }
                else if (hit.transform.eulerAngles.y == 270)
                {
                    previousDirection = "R";
                    return "R";
                }
            }

            if (resultTag == "Floor")
            {
                return "N";
            }
        }
        //If it detects nothing then we know that this is the spot we will be making our next area
        return "Error";

    }
    public string otherWhenToGenerate()
    {
        RaycastHit hit;
        if (Physics.Raycast(OtherAreaDetectionCube.transform.position, Vector3.down, out hit, 100, areaCubeLayerMask))
        {
            //Detect if the area is straight and the resulting direction the cube should move in
            otherResultTag = hit.transform.gameObject.tag;
            if (otherResultTag == "U")
            {
                if (hit.transform.eulerAngles.y == 180 || hit.transform.eulerAngles.y == -180)
                {
                    otherPreviousDirection = "U";
                    return "U";
                }
                else if (hit.transform.eulerAngles.y == 0)
                {
                    otherPreviousDirection = "D";
                    return "D";
                }
                else if (hit.transform.eulerAngles.y == 270)
                {
                    otherPreviousDirection = "R";
                    return "R";
                }
                else if (hit.transform.eulerAngles.y == 90)
                {
                    otherPreviousDirection = "L";
                    return "L";
                }
                //Else the tag might be turning right
            }
            else if (otherResultTag == "R")
            {
                if (hit.transform.eulerAngles.y == 90)
                {
                    otherPreviousDirection = "L";
                    return "L";
                }
                else if (hit.transform.eulerAngles.y == 0)
                {
                    otherPreviousDirection = "D";
                    return "D";
                }
                else if (hit.transform.eulerAngles.y == 180 || hit.transform.eulerAngles.y == -180)
                {
                    otherPreviousDirection = "U";
                    return "U";
                }
                else if (hit.transform.eulerAngles.y == 270)
                {
                    otherPreviousDirection = "R";
                    return "R";
                }
                //Lets detect the left turn now
            }
            else if (otherResultTag == "L")
            {
                if (hit.transform.eulerAngles.y == 90)
                {
                    otherPreviousDirection = "D";
                    return "D";
                }
                else if (hit.transform.eulerAngles.y == 0)
                {
                    otherPreviousDirection = "R";
                    return "R";
                }
                else if (hit.transform.eulerAngles.y == 180 || hit.transform.eulerAngles.y == -180)
                {
                    otherPreviousDirection = "L";
                    return "L";
                }
                else if (hit.transform.eulerAngles.y == 270)
                {
                    otherPreviousDirection = "U";
                    return "U";
                }
            }

            if(otherResultTag == "Floor")
            {
                return "N";
            }
        }

        return "Error";
        //If it detects nothing then we know that this is the spot we will be making our next area
        
        

    }
    public void moveAreaCube()
    {
        AreaDetectionCube.transform.position = new Vector3(XRRigX, 2, XRRigZ);
        for(int i = 0; i < 6; i++)
        {
            string whenGen = whenToGenerate();
            if (whenGen == "U")
            {
                AreaDetectionCube.transform.position = new Vector3(AreaDetectionCube.transform.position.x, 2, AreaDetectionCube.transform.position.z + 10);
            }
            else if (whenGen == "D")
            {
                AreaDetectionCube.transform.position = new Vector3(AreaDetectionCube.transform.position.x, 2, AreaDetectionCube.transform.position.z - 10);
            }


            if (whenGen == "L")
            {
                AreaDetectionCube.transform.position = new Vector3(AreaDetectionCube.transform.position.x - 10, 2, AreaDetectionCube.transform.position.z);
            }
            else if (whenGen == "R")
            {
                AreaDetectionCube.transform.position = new Vector3(AreaDetectionCube.transform.position.x + 10, 2, AreaDetectionCube.transform.position.z);
            }

            if (whenGen == "N") instantiateAreas();
        }

    }
    public void moveOtherAreaCube()
    {
        OtherAreaDetectionCube.transform.position = new Vector3(XRRigX, 2, XRRigZ);
        for(int i = 0; i < 6; i++)
        {
            string whenGen = otherWhenToGenerate();
            if (whenGen == "U")
            {
                OtherAreaDetectionCube.transform.position = new Vector3(OtherAreaDetectionCube.transform.position.x, 2, OtherAreaDetectionCube.transform.position.z + 10);
            }
            else if (whenGen == "D")
            {
                OtherAreaDetectionCube.transform.position = new Vector3(OtherAreaDetectionCube.transform.position.x, 2, OtherAreaDetectionCube.transform.position.z - 10);
            }


            if (whenGen == "L")
            {

                OtherAreaDetectionCube.transform.position = new Vector3(OtherAreaDetectionCube.transform.position.x - 10, 2, OtherAreaDetectionCube.transform.position.z);


            }
            else if (whenGen == "R")
            {
                OtherAreaDetectionCube.transform.position = new Vector3(OtherAreaDetectionCube.transform.position.x + 10, 2, OtherAreaDetectionCube.transform.position.z);
            }

            if (whenGen == "N") otherInstantiateArea();
        }

    }
    public void instantiateAreas()
    {
        Vector3 downDetectionCube = new Vector3(AreaDetectionCube.transform.position.x, AreaDetectionCube.transform.position.y - 2, AreaDetectionCube.transform.position.z);
        if (rayCayst() == "A" || rayCayst() == "B")
        {
            if (whenToGenerate() == "N")
            {
                bool shouldTurn = false;

                if(Random.Range(0,400) > 350)
                {
                    shouldTurn = true;
                }

                if (shouldTurn)
                {
                    if(Random.Range(0,51) > 25)
                    {
                        //Turn Right
                        int instArea;
                        if (Random.Range(0, 51) > 25) instArea = Random.Range(0, rightAreas.Length); else instArea = 0;
                        if (previousDirection == "U") tempArea = Instantiate(rightAreas[instArea], downDetectionCube, Quaternion.Euler(0,0,0), areasParent.transform);
                        if (previousDirection == "D") tempArea = Instantiate(rightAreas[instArea], downDetectionCube, Quaternion.Euler(0,180,0), areasParent.transform);
                        if (previousDirection == "L") tempArea = Instantiate(rightAreas[instArea], downDetectionCube, Quaternion.Euler(0,270,0), areasParent.transform);
                        if (previousDirection == "R") tempArea = Instantiate(rightAreas[instArea], downDetectionCube, Quaternion.Euler(0,90,0), areasParent.transform);
                    }
                    else
                    {
                        int instArea;
                        if (Random.Range(0, 51) > 25) instArea = Random.Range(0, leftAreas.Length); else instArea = 0;
                        //turn left
                        if (previousDirection == "U") tempArea = Instantiate(leftAreas[instArea], downDetectionCube, Quaternion.Euler(0, 90, 0), areasParent.transform);
                        if (previousDirection == "D") tempArea = Instantiate(leftAreas[instArea], downDetectionCube, Quaternion.Euler(0, 270,0), areasParent.transform);
                        if (previousDirection == "L") tempArea = Instantiate(leftAreas[instArea], downDetectionCube, Quaternion.Euler(0, 0, 0), areasParent.transform);
                        if (previousDirection == "R") tempArea = Instantiate(leftAreas[instArea], downDetectionCube, Quaternion.Euler(0, 180, 0), areasParent.transform);
                    }

                    foreach (Transform child in tempArea.transform)
                    {
                        if (child.gameObject.layer == 7 || child.gameObject.layer == 9)
                        {
                            if (randomColors)
                            {
                                child.GetComponent<MeshRenderer>().material = Materials[Random.Range(0, Materials.Length)];
                            }
                            else
                            {
                                child.GetComponent<MeshRenderer>().material = materialToRender();
                            }
                        }
                    }
                }
                else
                {
                    int instArea;
                    if (Random.Range(0, 51) > 25) instArea = Random.Range(0, straightAreas.Length); else instArea = 0;
                    //Go Straight
                    if (previousDirection == "U") tempArea = Instantiate(straightAreas[instArea], downDetectionCube, Quaternion.Euler(0, 0, 0), areasParent.transform);
                    if (previousDirection == "D") tempArea = Instantiate(straightAreas[instArea], downDetectionCube, Quaternion.Euler(0, 180, 0), areasParent.transform);
                    if (previousDirection == "L") tempArea = Instantiate(straightAreas[instArea], downDetectionCube, Quaternion.Euler(0, 270, 0), areasParent.transform);
                    if (previousDirection == "R") tempArea = Instantiate(straightAreas[instArea], downDetectionCube, Quaternion.Euler(0, 90, 0), areasParent.transform);

                    foreach (Transform child in tempArea.transform)
                    {
                        if (child.gameObject.layer == 7 || child.gameObject.layer == 9)
                        {
                            if (randomColors)
                            {
                                child.GetComponent<MeshRenderer>().material = Materials[Random.Range(0, Materials.Length)];
                            }
                            else
                            {
                                child.GetComponent<MeshRenderer>().material = materialToRender();
                            }
                        }
                    }
                }

            }
        }   
    }
    public void otherInstantiateArea()
    {
        Vector3 downDetectionCube = new Vector3(OtherAreaDetectionCube.transform.position.x, OtherAreaDetectionCube.transform.position.y - 2, OtherAreaDetectionCube.transform.position.z);
        if (rayCayst() == "A" || rayCayst() == "C")
        {
            if (otherWhenToGenerate() == "N")
            {
                bool shouldTurn = false;

                if (Random.Range(0, 400) > 350)
                {
                    shouldTurn = true;
                }

                if (shouldTurn)
                {
                    if (Random.Range(0, 51) > 25)
                    {
                        //Turn Right
                        int instArea;
                        if (Random.Range(0, 51) > 25) instArea = Random.Range(0, rightAreas.Length); else instArea = 0;
                        if (otherPreviousDirection == "U") otherTempArea = Instantiate(rightAreas[instArea], downDetectionCube, Quaternion.Euler(0, 90, 0), areasParent.transform);//
                        if (otherPreviousDirection == "D") otherTempArea = Instantiate(rightAreas[instArea], downDetectionCube, Quaternion.Euler(0, 270, 0), areasParent.transform);//
                        if (otherPreviousDirection == "L") otherTempArea = Instantiate(rightAreas[instArea], downDetectionCube, Quaternion.Euler(0, 0, 0), areasParent.transform);
                        if (otherPreviousDirection == "R") otherTempArea = Instantiate(rightAreas[instArea], downDetectionCube, Quaternion.Euler(0, 180, 0), areasParent.transform);//
                    }
                    else
                    {
                        //turn left
                        int instArea;
                        if (Random.Range(0, 51) > 25) instArea = Random.Range(0, leftAreas.Length); else instArea = 0;
                        if (otherPreviousDirection == "U") otherTempArea = Instantiate(leftAreas[instArea], downDetectionCube, Quaternion.Euler(0, 0, 0), areasParent.transform);
                        if (otherPreviousDirection == "D") otherTempArea = Instantiate(leftAreas[instArea], downDetectionCube, Quaternion.Euler(0, 180, 0), areasParent.transform);//
                        if (otherPreviousDirection == "L") otherTempArea = Instantiate(leftAreas[instArea], downDetectionCube, Quaternion.Euler(0, 270, 0), areasParent.transform);//
                        if (otherPreviousDirection == "R") otherTempArea = Instantiate(leftAreas[instArea], downDetectionCube, Quaternion.Euler(0, 90, 0), areasParent.transform);
                    }

                    foreach (Transform child in otherTempArea.transform)
                    {
                        if (child.gameObject.layer == 7 || child.gameObject.layer == 9)
                        {
                            if (randomColors)
                            {
                                child.GetComponent<MeshRenderer>().material = Materials[Random.Range(0, Materials.Length)];
                            }
                            else
                            {
                                child.GetComponent<MeshRenderer>().material = materialToRender();
                            }

                        }
                    }
                }
                else
                {
                    int instArea;
                    if (Random.Range(0, 51) > 25) instArea = Random.Range(0, straightAreas.Length); else instArea = 0;
                    //Go Straight
                    if (otherPreviousDirection == "U") otherTempArea = Instantiate(straightAreas[instArea], downDetectionCube, Quaternion.Euler(0, 180, 0), areasParent.transform);//
                    if (otherPreviousDirection == "D") otherTempArea = Instantiate(straightAreas[instArea], downDetectionCube, Quaternion.Euler(0, 0, 0), areasParent.transform);
                    if (otherPreviousDirection == "L") otherTempArea = Instantiate(straightAreas[instArea], downDetectionCube, Quaternion.Euler(0, 90, 0), areasParent.transform);
                    if (otherPreviousDirection == "R") otherTempArea = Instantiate(straightAreas[instArea], downDetectionCube, Quaternion.Euler(0, 270, 0), areasParent.transform);

                    foreach (Transform child in otherTempArea.transform)
                    {
                        if (child.gameObject.layer == 7 || child.gameObject.layer == 9)
                        {
                            if (randomColors)
                            {
                                child.GetComponent<MeshRenderer>().material = Materials[Random.Range(0, Materials.Length)];
                            }
                            else
                            {
                                child.GetComponent<MeshRenderer>().material = materialToRender();
                            }
                        }
                    }
                }
            }
        }
    }

    public Material materialToRender()
    {
        float distance = distanceController.GetComponent<PlayerPosition>().distance;

        if (distance < 500)
        {
            return Materials[0];
        }
        else if (distance < 1000)
        {
            return Materials[1];
        }
        else if (distance < 1500)
        {
            return Materials[2];
        }
        else if (distance < 2000)
        {
            return Materials[3];
        }
        else if (distance < 2500)
        {
            return Materials[4];
        }
        else if (distance < 3000)
        {
            return Materials[4];
        }
        else if (distance < 3500)
        {
            return Materials[5];
        }
        else if (distance < 4000)
        {
            return Materials[6];
        }
        return Materials[7];
    }
}