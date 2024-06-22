using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsSetter : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider refreshRateSlider;
    public int refreshRateVal;
    public Text refreshRateText;
    public Toggle aswToggle;
    // Start is called before the first frame update
    void Start()
    {
        //OVRManager.display.RecenterPose();
        int refreshInt = PlayerPrefs.GetInt("playerRefreshRate");
        //Very few users will have the player pref be over 1, but there still may be some...
        if(refreshInt > 1)
        {
            refreshInt = 0;
        }


        if (refreshInt == 1)
        {
            refreshRateVal = 120;
        }
        else
        {
            refreshRateVal = 90;
        }

        refreshRateSlider.value = refreshInt;
        refreshRateText.text = refreshRateVal.ToString();
        
            if (PlayerPrefs.GetString("ASW") == "true")
            {
                aswToggle.isOn = true;
            }
            else
            {
                aswToggle.isOn = false;
            }
    }

    private void Update()
    {
        PlayerPrefs.SetInt("playerRefreshRate", (int)refreshRateSlider.value);
        PlayerPrefs.SetString("ASW", aswToggle.isOn.ToString());
        PlayerPrefs.Save();

        if ((int)refreshRateSlider.value == 1)
        {
            refreshRateVal = 120;
        }
        else
        {
            refreshRateVal = 90;
        }
        refreshRateText.text = refreshRateVal.ToString();
    }
}

       