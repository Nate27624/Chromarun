using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSphereController : MonoBehaviour
{
    public GameObject mainCam;
    public float offset;
    public float distance;

    public GameObject[] spheres;
    private int currentLevel;

    public int sphereNum;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("currentLevel");
        if(PlayerPrefs.GetInt("hasBeatenGame") == 1)
        {
            currentLevel = 999;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < spheres.Length; i++)
        {
            Vector2 offsetVect = new Vector2(0,0);
            float angle;
            if (!(sphereNum == 0)) angle = (2 * Mathf.PI) / sphereNum; else angle = 0;
            angle *= i;
            offsetVect = new Vector2(distance*Mathf.Cos(angle), distance*Mathf.Sin(angle));
            spheres[i].SetActive(false);
            spheres[i].transform.localPosition = new Vector3(mainCam.transform.localPosition.x + offsetVect.x, mainCam.transform.localPosition.y + offset, mainCam.transform.localPosition.z + offsetVect.y);
        }

        for (int i = 0; i < spheres.Length - (8-sphereNum); i++)
        {
            spheres[i].SetActive(true);
        }
    }
}
