using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressSoundController : MonoBehaviour
{
    public AudioSource[] buttonClick;
    public GameObject[] buttonClickTransform;

    private float timer = 1;
    private bool playNow = false;

    public bool testPress = false;
    public int testPressInt = 0;
    void Start()
    {

    }

    private void Update()
    {
        if(timer > 0.9f)
        {
            timer -= Time.deltaTime;
            playNow = false;
        }
        else
        {
            playNow = true;
        }

        if (testPress)
        {
            PlaySound(testPressInt);
            testPress = false;
        }
    }
    // Start is called before the first frame update
    public void PlaySound(int buttonIndex)
    {
        buttonClick[buttonIndex].gameObject.transform.position = new Vector3(buttonClickTransform[buttonIndex].transform.position.x, buttonClickTransform[buttonIndex].transform.position.y, buttonClickTransform[buttonIndex].transform.position.z);
        buttonClick[buttonIndex].Play();
    }
}
