using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerPrefMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text levelID;
    public Text title;
    private TouchScreenKeyboard keyboard;
    public int buttonClicks;

    public string prefName;
    public string prefValue;

    public string sceneName;

    public int curPartPass = 0;

    public Canvas canvas;

    public bool[] testingPress;

    public bool testUpdate;
    // Start is called before the first frame update
    void Start()
    {
        buttonClicks = 0;
    }

   void Update()
    {

        if (OVRInput.GetDown(OVRInput.Button.Any) || testUpdate)
        {
            testUpdate = false;
            if (curPartPass == 0)
            {
                if (OVRInput.GetDown(OVRInput.Button.Four) || testingPress[0])
                {
                    curPartPass = 1;
                }
                else
                {
                    curPartPass = 0;
                }
            }else        

            if(curPartPass == 1)
            {
                if (OVRInput.GetDown(OVRInput.Button.One) || testingPress[1])
                {
                    curPartPass = 2;
                }
                else
                {
                    curPartPass = 0;
                }
            }else
            
            if(curPartPass == 2)
            {
                if (OVRInput.GetDown(OVRInput.Button.Two) ||  testingPress[2])
                {
                    curPartPass = 3;
                }
                else
                {
                    curPartPass = 0;
                }
            }else
         

            if(curPartPass == 3)
            {
                if (OVRInput.GetDown(OVRInput.Button.Three) || testingPress[3])
                {
                    curPartPass = 4;
                }
                else
                {
                    curPartPass = 0;
                }
            }else
            
            if(curPartPass == 4)
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || testingPress[4])
                {
                    curPartPass = 5;
                }
                else
                {
                    curPartPass = 0;
                }
            }else

            if (curPartPass == 5)
            {
                if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || testingPress[5])
                {
                    canvas.enabled = true;
                }
                else
                {
                    curPartPass = 0;
                }
            }
        }
        levelID.text = keyboard.text;
    }

    public void showKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.ASCIICapable);
    }

    public void setPref()
    {

        if (buttonClicks == 0)
        {
            prefName = keyboard.text;
        } else if (buttonClicks == 1)
        {
            if (keyboard.text.Contains("0") || keyboard.text.Contains("1") || keyboard.text.Contains("2") || keyboard.text.Contains("3") || keyboard.text.Contains("4") || keyboard.text.Contains("5") || keyboard.text.Contains("6") || keyboard.text.Contains("7") || keyboard.text.Contains("8") || keyboard.text.Contains("9"))
            {
                PlayerPrefs.SetInt(prefName, int.Parse(keyboard.text)); 
                PlayerPrefs.Save();
            }
            else
            {
                PlayerPrefs.SetString(prefName, keyboard.text);
                PlayerPrefs.Save();
            }
            SceneManager.LoadScene("MenuSend");
            
        }
        buttonClicks++;
    }

    public void loadScene()
    {
        SceneManager.LoadScene(keyboard.text);
    }

    public void DisplayAverageTimes()
    {
        float count = 0;
        int totalLevels = 0;
        float tempFloat = 0;
        for(int i = 0; i < 50; i++)
        {
            tempFloat = PlayerPrefs.GetFloat("bestTime" + i);
            if (tempFloat != 0) totalLevels++;
            count += tempFloat;
        }

        title.text = "Total Sum of Time: " + count + " Total Levels Beaten: " + totalLevels;
    }

    public void ResetALL()
    {
        PlayerPrefs.DeleteAll();
    }
}
