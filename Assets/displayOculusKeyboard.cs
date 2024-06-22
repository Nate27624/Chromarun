using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayOculusKeyboard : MonoBehaviour
{
    public Text levelID;
    private TouchScreenKeyboard keyboard;
    // Start is called before the first frame update
    void Start()
    {
        showKeyboard();
    }

    private void Update()
    {
        if(keyboard.text == "")
        {
            levelID.text = "0";
        }
        else
        {
            levelID.text = keyboard.text;
        }
    }

    public void showKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.DecimalPad);
    }
}
