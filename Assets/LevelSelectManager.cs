using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public string[] levels;
    public Sprite[] images;

    public Color[] colors;

    public int currentScreen;
    public int currentLevel;
    public Transform worldSpin;
    public GameObject loadingText;

    public Text[] textToChange;
    public GameObject[] setFalse;

    public int buttonHit;
    public Image[] mainImage;

    public bool testForwardPress = false;
    public bool testBackPress = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("currentSettingsMenu", "LevelSelect");
        PlayerPrefs.Save();
        currentScreen = (int)Mathf.Floor(PlayerPrefs.GetInt("currentScreenLevelSelect") / 5);
        currentLevel = (PlayerPrefs.GetInt("currentScreenLevelSelect") % 5);
        updateScreen();
    }
    public void nextScreen()
    {
        currentScreen += 1;
        if(currentScreen > 7)
        {
            currentScreen = 0;
        }

        updateScreen();
    }

    public void backScreen()
    {
        currentScreen -= 1;

        if(currentScreen < 0)
        {
            currentScreen = 7;
        }

        updateScreen();
    }

    public void NextLevel()
    {
        currentLevel++;
        if(currentLevel > 4)
        {
            currentLevel = 0;
            currentScreen++;
            if(currentScreen > 7)
            {
                currentScreen = 0;
            }
        }

        updateScreen();
    }

    public void BackLevel()
    {
        currentLevel--;
        if(currentLevel < 0)
        {
            currentLevel = 4;
            currentScreen--;
            if (currentScreen < 0)
            {
                currentScreen = 7;
            }
        }

        updateScreen();
    }

    public void updateScreen()
    {
        for(var i = 0; i < textToChange.Length; i++)
        {
            textToChange[i].color = colors[currentScreen];
        }
        
        worldSpin.rotation = Quaternion.Euler(0, (-45 * currentScreen), 0);
        for(int i = 0; i < mainImage.Length; i++)
        {
            mainImage[i].sprite = images[(currentScreen * 5) + currentLevel];
        }
        
    }

    public void loadLevel()
    {
        int levelVal;

        levelVal = (currentScreen * 5) + currentLevel;

        PlayerPrefs.SetInt("currentScreenLevelSelect", levelVal);
        PlayerPrefs.Save();

        for (int i = 0; i < setFalse.Length; i++) setFalse[i].SetActive(false);
        loadingText.SetActive(true);

        SceneManager.LoadSceneAsync(levels[levelVal]);

        
    }

    public void Update()
    {
        if (testForwardPress)
        {
            NextLevel();
            testForwardPress = false;
        }

        if (testBackPress)
        {
            BackLevel();
            testBackPress = false;
        }
    }
}
