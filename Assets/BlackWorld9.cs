using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackWorld9 : MonoBehaviour
{
    public float timer;
    public Text mainText;
    public int deathNumber;
    public GameObject lightSource;
    public bool loadingNextLevel;


    // Start is called before the first frame update
    void Start()
    {
        deathNumber = 0;
        for(var i = 0; i < 50; i++)
        {
            deathNumber += PlayerPrefs.GetInt("totalDeaths" + i);
        }
        timer = 195;
        lightSource.SetActive(false);
        loadingNextLevel = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer < 200)
        {
            mainText.text = "Escaping the evil entity a sense of accomplishment fufills the hero";
        }else if(timer < 203)
        {
            mainText.text = "A strange light shines from our hero...a sort of power";
        }else if(timer < 206)
        {
            mainText.text = "A power that has been obtained through trial and error";
        }else if(timer < 209)
        {
            mainText.text = "Through success and failure";
        }else if(timer < 212)
        {
            mainText.text = "Through " + deathNumber + " deaths";
        }else if(timer < 215)
        {
            mainText.text = "The color has been inside this hero and has finally shown";
            lightSource.SetActive(true);
        }else if(timer < 218)
        {
            mainText.text = "A hero that is ready to defeat the entity and save the Chromas";
        }else if(timer < 221)
        {
            mainText.text = "Good luck on your final journey";
            if (loadingNextLevel)
            {
                SceneManager.LoadSceneAsync("BlackWorld10");
                loadingNextLevel = false;
            }
        }
    }
}
