using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsTrailRenderer : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle effectToggle;

    public void Start()
    {
        if (!PlayerPrefs.HasKey("trailEffect")){
            PlayerPrefs.SetInt("trailEffect", 1);
            PlayerPrefs.Save();
        }
        else if(PlayerPrefs.GetInt("trailEffect") == 1)
        {
            effectToggle.isOn = true;
        }
        else
        {
            effectToggle.isOn = false;
        }

        UpdatePref();


    }
    public void UpdatePref()
    {
        if (effectToggle.isOn)
        {
            PlayerPrefs.SetInt("trailEffect", 1);
        }else if (!effectToggle.isOn)
        {
            PlayerPrefs.SetInt("trailEffect", 0);
        }
        PlayerPrefs.Save();
    }
}
