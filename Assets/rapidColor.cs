using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rapidColor : MonoBehaviour
{
    public Material[] mats;
    public GameObject sphere;
    private Material mat;

    public float timer = 1;
    private float startTimer;
    // Start is called before the first frame update
    void Start()
    {
        startTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = startTimer;
            sphere.GetComponent<MeshRenderer>().material = mats[Random.Range(0, mats.Length)];
        }
            
    }
}
