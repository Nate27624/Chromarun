using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyMenuController : MonoBehaviour
{
    public GameObject Purple;
    public GameObject Orange;
    public GameObject Bread;
    public GameObject Green;
    public GameObject Red;

    private int currentLevel = 0;
    private bool hasBeatenGame;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("currentLevel");
        hasBeatenGame = false;
        if (PlayerPrefs.GetInt("hasBeatenGame") == 1) hasBeatenGame = true;

        if (currentLevel >= 20 || hasBeatenGame)
        {
            Purple.SetActive(true);
        }
        if (currentLevel >= 35 || hasBeatenGame)
        {
            Bread.SetActive(true);
        }
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
