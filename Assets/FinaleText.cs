using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinaleText : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public float timer = 20;
    public float timerVal;
    public float timerVal2;
    public Material Black;

    private bool imBadAtCoding = false;
    //public GameObject sphere;
    
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < timerVal)
        {
            text1.transform.gameObject.SetActive(false);
            text2.transform.gameObject.SetActive(true);
            OVRInput.SetControllerVibration(2/10, 2/10);
        }

        if (!imBadAtCoding)
        {
            if (timer < timerVal2)
            {
                imBadAtCoding = true;
                RenderSettings.skybox = Black;
                SceneManager.LoadSceneAsync(sceneName);
                OVRInput.SetControllerVibration(1, 1);
            }
        }
        
    }
}
