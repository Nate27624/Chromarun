using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSendSongController : MonoBehaviour
{
    public AudioSource shoppingMusic;
    public AudioSource mainTheme;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("hasHeardMainTheme") == 1)
        {
            mainTheme.volume = 0;
        }
        else
        {
            shoppingMusic.volume = 0;
            mainTheme.time = 17.1f;
            PlayerPrefs.SetInt("hasHeardMainTheme", 0);
            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("hasHeardMainTheme", 0);
        Debug.Log(mainTheme.time);
    }
}
