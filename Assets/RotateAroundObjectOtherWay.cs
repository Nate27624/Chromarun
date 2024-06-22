using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundObjectOtherWay : MonoBehaviour
{
    public GameObject[] rotatingObjects;
    public GameObject centerPoint;

    public float rotationSpeed;

    public bool prefSpeed = true;
    // Start is called before the first frame update
    void Start()
    {
        int playerPrefVal = PlayerPrefs.GetInt("obstacleDifficulty");
        if (prefSpeed && playerPrefVal > 0) rotationSpeed = (rotationSpeed * playerPrefVal * 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < rotatingObjects.Length; i++)
        {
            rotatingObjects[i].transform.RotateAround(centerPoint.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}
