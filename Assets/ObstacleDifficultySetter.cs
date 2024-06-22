using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleDifficultySetter : MonoBehaviour
{
    public Slider difficultySlider;
    public Text difficultyValue;
    // Start is called before the first frame update
    void Start()
    {
        difficultySlider.value = PlayerPrefs.GetInt("obstacleDifficulty");
        if(PlayerPrefs.GetInt("obstacleDifficulty") == 0)
        {
            difficultySlider.value = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("obstacleDifficulty", (int)difficultySlider.value);
        PlayerPrefs.Save();

        if (difficultySlider.value <= 2)
        {
            difficultyValue.text = "Easy";
        }

        if (difficultySlider.value > 2)
        {
            if (difficultySlider.value <= 4)
            {
                difficultyValue.text = "Medium";
            }
        }

        if (difficultySlider.value > 4)
        {
            if (difficultySlider.value <= 6)
            {
                difficultyValue.text = "Hard";
            }
        }

        if (difficultySlider.value > 6)
        {
            if (difficultySlider.value <= 8)
            {
                difficultyValue.text = "Extremly Hard";
            }
        }

        if (difficultySlider.value > 8)
        {
            difficultyValue.text = "Probably Impossible";
        }
    }
}
