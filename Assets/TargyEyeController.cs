using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargyEyeController : MonoBehaviour
{
    public float timer = 1 / 2;
    public Texture[] eyeTexture;
    public Material eyeMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            eyeMaterial.SetTexture("_BaseMap", eyeTexture[Random.Range(0, eyeTexture.Length)]);
            timer = 1 / 2;
        }
        
    }
}
