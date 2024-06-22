using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWorldPrefSetter : MonoBehaviour
{
    public int levelVal;
    // Start is called before the first frame update

 public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 8 || other.gameObject.layer == 6 || other.gameObject.layer == 3)
        {
            if(levelVal == 7)
            {
                PlayerPrefs.SetInt("finaleBlack7", 1);
            }else if(levelVal == 8)
            {
                PlayerPrefs.SetInt("finaleBlack8", 1);
            }else if(levelVal == 9)
            {
                PlayerPrefs.SetInt("finaleBlack9", 1);
            }
            PlayerPrefs.Save();
        }
    }
}

