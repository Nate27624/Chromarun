using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayStatisticsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.GetInt("displayStatistics") == 1)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }

    }
}
