using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWorldPrefController : MonoBehaviour
{
    public bool defeatedSeven;
    public bool defeatedEight;
    public bool defeatedNine;

    public GameObject wallSeven;
    public GameObject wallEight;
    public GameObject wallNine;

    public int completionVal = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("finaleBlack7") == 1) defeatedSeven = true;
        if (PlayerPrefs.GetInt("finaleBlack8") == 1) defeatedEight = true;
        if (PlayerPrefs.GetInt("finaleBlack9") == 1) defeatedNine = true;

        if (defeatedSeven)
        {
            wallSeven.SetActive(true); 
            completionVal++;
        }
        if (defeatedEight)
        {
            wallEight.SetActive(true); 
            completionVal++;
        }
        if (defeatedNine)
        {
            wallNine.SetActive(true);
            completionVal++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
