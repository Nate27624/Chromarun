using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TOSUpdate : MonoBehaviour
{
    public int currentTosInt;

    private bool hasStartedPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        hasStartedPlaying = !(PlayerPrefs.GetInt("currentLevel") == 0);
        Debug.Log(hasStartedPlaying);
        Debug.Log(PlayerPrefs.GetInt("currentLevel"));
        if (hasStartedPlaying && !(PlayerPrefs.GetInt("TOSVersion") == currentTosInt))
        {
            SceneManager.LoadScene("TOSUpdate");
        }

        if (!hasStartedPlaying)
        {
            PlayerPrefs.SetInt("TOSVersion", currentTosInt);
            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
