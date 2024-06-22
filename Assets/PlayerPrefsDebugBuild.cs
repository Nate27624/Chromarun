using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDebugBuild : MonoBehaviour
{
    public string[] intName;
    public int[] intVal;
    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0; i < intName.Length; i++)
        {
            PlayerPrefs.SetInt(intName[i], intVal[i]);
        }

        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
