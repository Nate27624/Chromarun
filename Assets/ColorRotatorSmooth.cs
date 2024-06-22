using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRotatorSmooth : MonoBehaviour
{
    public MeshRenderer lightSource;

    public Color[] colors;

    private float timer = 1;
    // Start is called before the first frame update
    void Start()
    {
      
    }


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            timer = 2f;
            lightSource.material.color = colors[Random.Range(0, colors.Length - 1)];
        }
    }
}
