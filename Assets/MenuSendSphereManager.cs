using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSendSphereManager : MonoBehaviour
{
    public GameObject[] disableIfNotBeatenGame;
    public GameObject[] disableIfBeatenGame;

    private bool hasBeatenGame = false;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("hasBeatenGame") == 1) hasBeatenGame = true;

        if(hasBeatenGame)
        {
            for(var i = 0; i < disableIfBeatenGame.Length; i++)
            {
                disableIfBeatenGame[i].SetActive(false);
            }

            for(var i = 0; i < disableIfNotBeatenGame.Length; i++)
            {
                disableIfNotBeatenGame[i].SetActive(true);
            }
        }
        else
        {
            for (var i = 0; i < disableIfBeatenGame.Length; i++)
            {
                disableIfBeatenGame[i].SetActive(true);
            }

            for (var i = 0; i < disableIfNotBeatenGame.Length; i++)
            {
                disableIfNotBeatenGame[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
