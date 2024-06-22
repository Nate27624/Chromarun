using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area71Controller : MonoBehaviour
{
    public GameObject[] areas;
    public Material material;

    private int temp;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < areas.Length; i++)
        {
            areas[i].SetActive(false);
        }

        temp = Random.Range(0, areas.Length - 1);
        areas[temp].SetActive(true);
        foreach (Transform child in areas[temp].transform)
        {
            if (child.GetComponent<MeshRenderer>() && child.transform.gameObject.layer == 9)
            {
                child.GetComponent<MeshRenderer>().material = material;
            }
        }

        }
    }
