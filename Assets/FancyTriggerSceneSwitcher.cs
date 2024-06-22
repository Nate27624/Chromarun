using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyTriggerSceneSwitcher : MonoBehaviour
{
    public bool loadNextLevel = false;
    public bool beginConfirmation;

    public float timer = 3f;

    public MeshRenderer miniSphere;
    public MeshRenderer minierSphere;
    public AudioSource sphereSounds;

    private bool[] playSounds = new bool[3];
    public GameObject[] falseObjs;
    public GameObject[] trueObjs;
    private bool startLoad = false;

    public bool invertSound = false;
    // Start is called before the first frame update
    void Start()
    {
        loadNextLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startLoad && !sphereSounds.isPlaying)
        {
            Debug.Log("!!!!");
            loadNextLevel = true;
        }

        if (beginConfirmation)
        {
            timer -= Time.deltaTime;
            this.GetComponent<MeshRenderer>().enabled = false;
            if (playSounds[0])
            {
                playSounds[0] = false;
                if (!invertSound)
                {
                    sphereSounds.pitch = 1f;
                }
                else
                {
                    sphereSounds.pitch = 1.25f;
                }
                sphereSounds.Play();
            }
            if (timer < 2.5f)
            {
                miniSphere.enabled = false;
                if (playSounds[1])
                {
                    playSounds[1] = false;
                    sphereSounds.pitch = 1.1f;
                    
                    sphereSounds.Play();
                }

                if (timer < 2f)
                {                   
                    if (playSounds[2])
                    {
                        playSounds[2] = false;
                        if (!invertSound)
                        {
                            sphereSounds.pitch = 1.25f;
                        }
                        else
                        {
                            sphereSounds.pitch = 1;
                        }
                       
                        sphereSounds.Play();
                        startLoad = true;
                        minierSphere.enabled = false;

                        for (var i = 0; i < falseObjs.Length; i++)
                        {
                            falseObjs[i].SetActive(false);
                        }

                        for (var i = 0; i < trueObjs.Length; i++)
                        {
                            trueObjs[i].SetActive(true);
                        }
                    }
                    Debug.Log(startLoad + " " + !sphereSounds.isPlaying);
                }
            }
        }
        else if(!startLoad)
        {
            
            if(timer < 3)
            {
                timer += 1.5f*Time.deltaTime;
                if (timer > 2f)
                {
                    miniSphere.enabled = true;
                }
                else if (timer > 1.25f)
                {
                    minierSphere.enabled = true;
                }
            }
            else
            {
                this.GetComponent<MeshRenderer>().enabled = true;
                loadNextLevel = false;
            }
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 10 || other.gameObject.layer == 3)
        {
            if (sphereSounds.GetComponent<MenuAudioController>())
            {
                sphereSounds.GetComponent<MenuAudioController>().curMenuSphere = this.gameObject;
            }

            for (int i = 0; i < playSounds.Length; i++)
            {
                playSounds[i] = true;
            }
            beginConfirmation = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 10 || other.gameObject.layer == 3)
        {
            beginConfirmation = false;
        }
    }
}
