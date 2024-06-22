using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundObjectRedW3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] rotatingObjects;
    public GameObject centerPoint;
    public GameObject tipOfCylinder;
    public GameObject bottomOfCylinder;

    public float rotationSpeed;
    public bool prefSpeed = true;
    // Start is called before the first frame update
    void Start()
    {
        int playerPrefVal = PlayerPrefs.GetInt("obstacleDifficulty");
        rotationSpeed = Random.Range(10, 180);
        if (prefSpeed && playerPrefVal > 0) rotationSpeed *= PlayerPrefs.GetInt("obstacleDifficulty") * 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < rotatingObjects.Length; i++)
        {
            rotatingObjects[i].transform.RotateAround(centerPoint.transform.position, (tipOfCylinder.transform.position - bottomOfCylinder.transform.position).normalized, rotationSpeed * Time.deltaTime);
        }
    }
}
