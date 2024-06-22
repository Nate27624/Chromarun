using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxCamera : MonoBehaviour
{
    public float speed = 0f;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float curFloat = RenderSettings.skybox.GetFloat("_Rotation");
        curFloat += Time.deltaTime * speed;
        RenderSettings.skybox.SetFloat("_Rotation", curFloat);

    }
}
