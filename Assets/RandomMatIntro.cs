using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMatIntro : MonoBehaviour
{

    public Material[] mats;

    public introScene introScene;

    private float timer = 0f;
    private float time;

    private bool hasChanged = false;
    // Start is called before the first frame update
    void Start()
    {
      this.GetComponent<MeshRenderer>().material = mats[Random.Range(0, mats.Length)];
        time = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (introScene.startAll)
        {

            timer += Time.deltaTime;
            if (timer > time)
            {
                if (!hasChanged)
                {
                    this.GetComponent<MeshRenderer>().material.color = Color.black;
                    hasChanged = true;
                }
                
            }

            
        }
    }
}
