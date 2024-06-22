using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongStartTimeChanger : MonoBehaviour
{
    public AudioSource mainClip;
    public float startTime;
    public float fadeInDuration;
    // Start is called before the first frame update
    void Start()
    {
        mainClip.time = startTime;
        mainClip.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(mainClip.volume < 1)
        {
            mainClip.volume += Time.deltaTime / fadeInDuration;
        }
    }
}
