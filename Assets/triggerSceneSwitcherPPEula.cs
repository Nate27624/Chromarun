using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.UI;
public class triggerSceneSwitcherPPEula : MonoBehaviour
{
    public string sceneName;

    public string introSceneName;

    public bool playIntroScene;
    public bool hasTouchedContinue = false;

    public AudioSource audioClip;

    public bool fancyLoad = false;

    public bool TOSScene;

    public int TOSInt;
    public void Start()
    {
        if(PlayerPrefs.GetInt("introScene") != 1)
        {
            playIntroScene = true;
        }
        else
        {
            playIntroScene = false;
        }
    }

    public void Update()
    {
        if (this.GetComponent<FancyTriggerSceneSwitcher>().loadNextLevel)
        {
            loadNext();
        }
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 8 || other.gameObject.layer == 6 || other.gameObject.layer == 3)
        {
            if (!fancyLoad)
            {
                loadNext();
            }
        }

    }

    public void loadNext()
    {
        if (TOSScene)
        {
            PlayerPrefs.SetInt("TOSVersion", TOSInt);
            PlayerPrefs.Save();
        }

        hasTouchedContinue = true;
        if (playIntroScene)
        {
            SceneManager.LoadScene(introSceneName);
        }
        else

        {

            SceneManager.LoadScene(sceneName);


        }
    }
}
