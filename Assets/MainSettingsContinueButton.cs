using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainSettingsContinueButton : MonoBehaviour
{
    public string prefSceneName;
    public GameObject[] falseObjs;
    public GameObject[] falseObjsMenuSend;
    public GameObject[] adjustPos;
    public GameObject[] trueObjs;

    public bool fancyLoad = false;
    // Start is called before the first frame update
    void Start()
    {
        prefSceneName = PlayerPrefs.GetString("currentSettingsMenu");

        if(prefSceneName == "MenuSend")
        {
            for (var i = 0; i < falseObjsMenuSend.Length; i++)
            {
                falseObjsMenuSend[i].SetActive(false);
            }
            for (var i = 0; i < adjustPos.Length; i++)
            {
                adjustPos[i].transform.position = new Vector3(0, adjustPos[i].transform.position.y, adjustPos[i].transform.position.z);
            }

        }

        if(prefSceneName == "")
        {
            prefSceneName = "MenuSend";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<FancyTriggerSceneSwitcher>().loadNextLevel)
        {
            loadNextScene();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            if (!fancyLoad)
            {
                loadNextScene();
            }
               
        }
    }

    public void loadNextScene()
    {
        for (var i = 0; i < falseObjs.Length; i++)
        {
            falseObjs[i].SetActive(false);
        }

        for (var i = 0; i < trueObjs.Length; i++)
        {
            trueObjs[i].SetActive(true);
        }

        if (prefSceneName == "StoryMode") SceneManager.LoadScene("PortalTransition");
        if (prefSceneName == "Endless") SceneManager.LoadSceneAsync("VRWalkingGame");
        if (prefSceneName == "CustomLevel") SceneManager.LoadSceneAsync("CustomDataScene");
        if (prefSceneName == "NewEndless") SceneManager.LoadSceneAsync("NewEndless");
        if (prefSceneName == "MenuSend") SceneManager.LoadSceneAsync("MenuSend");
        if (prefSceneName == "LevelSelect") SceneManager.LoadSceneAsync("LevelSelect");


    }
}
