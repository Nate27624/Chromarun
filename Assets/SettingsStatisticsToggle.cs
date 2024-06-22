using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsStatisticsToggle : MonoBehaviour
{
    // Start is called before the first frame update

    public Toggle statsToggle;
    void Start()
    {
        if (PlayerPrefs.GetInt("displayStatistics") == 1)
        {
            statsToggle.isOn = true;
        }
        else
        {
            statsToggle.isOn = false;
        }

        UpdatePref();


    }
    public void UpdatePref()
    {
        if (statsToggle.isOn)
        {
            PlayerPrefs.SetInt("displayStatistics", 1);
        }
        else if (!statsToggle.isOn)
        {
            PlayerPrefs.SetInt("displayStatistics", 0);
        }
        PlayerPrefs.Save();

        Debug.Log(PlayerPrefs.GetInt("displayStatistics"));
    }
}

