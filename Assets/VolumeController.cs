using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    private AudioSource mainAudio;
    public bool halfVolume = false;
    // Start is called before the first frame update
    void Start()
    {
        if(this.GetComponent<AudioSource>())
        mainAudio = this.GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("volume"))
        {
            int vol = ((PlayerPrefs.GetInt("volume")));
            Debug.Log(vol);
            if (halfVolume) mainAudio.volume = (float)(vol * 0.005); else mainAudio.volume = (float)(vol * 0.01);
            Debug.Log(mainAudio.volume);
        }
        else
        {
            PlayerPrefs.SetInt("volume", 100);
            PlayerPrefs.Save();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
