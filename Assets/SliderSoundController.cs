using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSoundController : MonoBehaviour
{
    public Slider[] sliders;
    public GameObject[] audioLocation;
    public Vector2[] sliderMinMax;

    public AudioSource mainBeep;
    public AudioSource wallContactMax;
    public AudioSource wallContactMin;

    private float quickAndDirty = 1;
    private bool doneStart = false;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < sliders.Length; i++)
        {
            sliderMinMax[i] = new Vector2(sliders[i].minValue, sliders[i].maxValue);
        }
    }

    private void Update()
    {
        if (quickAndDirty > 0.9f)
        {
            quickAndDirty -= Time.deltaTime;
            doneStart = false;
        }
        else
        {
            doneStart = true;
        }
    }

    public void PlaySound(int curSliderIndex)
    {
        if (doneStart)
        {
            float pitch = 0;
            Debug.Log(audioLocation[curSliderIndex].transform.position);
            this.gameObject.transform.localPosition = new Vector3(audioLocation[curSliderIndex].transform.position.x, audioLocation[curSliderIndex].transform.position.y, audioLocation[curSliderIndex].transform.position.z);
            pitch = 1.75f + (sliders[curSliderIndex].value / sliderMinMax[curSliderIndex].y);
            mainBeep.pitch = pitch;
            if (!(sliders[curSliderIndex].value == sliderMinMax[curSliderIndex].y)) mainBeep.Play();
            if (sliders[curSliderIndex].value == sliderMinMax[curSliderIndex].y) wallContactMax.Play();
            if (sliders[curSliderIndex].value == sliderMinMax[curSliderIndex].x) wallContactMin.Play();
        }
    }
}
