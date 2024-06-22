using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetter : MonoBehaviour
{
    public Slider volumeSlider;
    public Text volumeSliderText;

    public AudioSource mainAudio;
    public bool halfAudio;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            volumeSlider.value = PlayerPrefs.GetInt("volume");
        }
        else
        {
            volumeSlider.value = 100;
        }

        SetVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume()
    {
        PlayerPrefs.SetInt("volume", (int)volumeSlider.value);
        volumeSliderText.text = volumeSlider.value.ToString() + "%";
        PlayerPrefs.Save();

       if(halfAudio) mainAudio.volume = (volumeSlider.value * .005f); else mainAudio.volume = (volumeSlider.value * .01f);
    }
}
