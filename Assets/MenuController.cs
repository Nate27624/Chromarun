using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject[] menuOne;
    public GameObject[] menuTwo;
    public GameObject[] menuThree;

    public int currentMenu;

    public bool hasBeatenGame;
    public int defaultMenu;

    public Material menuOneSky;
    public Material menuTwoSky;
    public Material menuThreeSky;

    public bool changeMenu;
    public bool testingRun;

    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        changeMenu = false;
        currentMenu = PlayerPrefs.GetInt("defaultMenu");
        if(PlayerPrefs.GetInt("hasBeatenGame") == 1)
        {
            hasBeatenGame = true;
        }
        if (!hasBeatenGame)
        {
            for (var i = 0; i < menuTwo.Length; i++)
            {
                menuTwo[i].SetActive(false);
            }

            for (var i = 0; i < menuThree.Length; i++)
            {
                menuThree[i].SetActive(false);
            }

            for (var i = 0; i < menuOne.Length; i++)
            {
                menuOne[i].SetActive(true);
            }
            RenderSettings.skybox = menuOneSky;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (hasBeatenGame)
        {
            if(currentMenu == 0)
            {
                currentMenu = 2;
            }
            if (OVRInput.GetDown(OVRInput.Button.Four) && timer < 0.5 || OVRInput.GetDown(OVRInput.Button.Two) && timer < 0.5 || changeMenu && timer < 0.5)
            {
                timer = 1;
                currentMenu++;
                changeMenu = false;
            }

            if (currentMenu > 3)
            {
                currentMenu = 1;
            }

            if (currentMenu == 1)
            {
                for (var i = 0; i < menuTwo.Length; i++)
                {
                    menuTwo[i].SetActive(false);
                }

                for (var i = 0; i < menuThree.Length; i++)
                {
                    menuThree[i].SetActive(false);
                }

                for (var i = 0; i < menuOne.Length; i++)
                {
                    menuOne[i].SetActive(true);
                }
                RenderSettings.skybox = menuOneSky;
               if(!testingRun) OVRManager.SetSpaceWarp(false);
                if (!testingRun) OVRManager.display.displayFrequency = 120;
            }
            else if(currentMenu == 2)
            {
                for (var i = 0; i < menuTwo.Length; i++)
                {
                    menuTwo[i].SetActive(true);
                }

                for(var i = 0; i < menuOne.Length; i++)
                {
                    menuOne[i].SetActive(false);
                }

                for (var i = 0; i < menuThree.Length; i++)
                {
                    menuThree[i].SetActive(false);
                }
                RenderSettings.skybox = menuTwoSky;
               if(!testingRun) OVRManager.SetSpaceWarp(true);
                if (!testingRun) OVRManager.display.displayFrequency = 90;
            }else if(currentMenu == 3)
            {
                for (var i = 0; i < menuThree.Length; i++)
                {
                    menuThree[i].SetActive(true);
                }

                for (var i = 0; i < menuTwo.Length; i++)
                {
                    menuTwo[i].SetActive(false);
                }

                for (var i = 0; i < menuThree.Length; i++)
                {
                    menuOne[i].SetActive(false);
                }
                RenderSettings.skybox = menuThreeSky;
                if (!testingRun) OVRManager.SetSpaceWarp(false);
                if (!testingRun) OVRManager.display.displayFrequency = 120;
            }

            PlayerPrefs.SetInt("defaultMenu", currentMenu);
            PlayerPrefs.Save();
        }
        
        

    }
}
