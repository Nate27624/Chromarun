using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinaleWorldText : MonoBehaviour
{
    public Text mainText;
    public float timer = 100;
    public float beatingTime;

    public bool startLoadNextScene;
    // Start is called before the first frame update
    void Start()
    {
        startLoadNextScene = true;
        beatingTime = PlayerPrefs.GetFloat("globalTime"); 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("!!!" + beatingTime + "!!!");
        timer -= Time.deltaTime;
        if(timer > 96)
        {
            PlayerPrefs.SetInt("currentLevel", 0);
            PlayerPrefs.SetInt("hasBeatenGame", 1);
            mainText.text = "Finally, after a long and grueling battle, you emerged victorious.";
        }else if(timer > 92)
        {
            mainText.text = "The entity was defeated, and the colors were restored.";
        }else if(timer > 84)
        {
            mainText.text = "You take a deep breath as the game comes to an end," + '\n' + "feeling a sense of accomplishment and growth.";
        }else if(timer > 76)
        {
            mainText.text = "You've traveled through fields of green grass, experienced the disco," + '\n' + "flown through the clouds, and conquered deep fears.";
        }else if(timer > 68)
        {
            mainText.text = "Each color has brought its own set of challenges and emotions.";
        }
        else if(timer > 64)
        {
            mainText.text = "As you reflect on the journey, you realize that the game was about more than just colors.";
        }
        else if(timer > 60)
        {
            mainText.text = "It was about emotions and experiences, and how we can all overcome challenges.";
        }
        else if(timer > 54)
        {
            mainText.text = "But as you remove your virtual reality headset and step back into the real world," + '\n' + "you couldn't help but feel a sense of sadness and emptiness.";
        }
        else if (timer > 50)
        {
            mainText.text = "The vibrant colors of the virtual world had been a temporary escape from the dullness of your everyday life.";
        }
        else if (timer > 46)
        {
            mainText.text = "As you reflected on your journey, you realized that the thrill of victory was fleeting...";
        }
        else if (timer > 38)
        {
            mainText.text = "...and that the challenges and obstacles you had overcome in the game" + '\n' + "were nothing compared to the struggles and hardships of the real world.";
        }
        else if (timer > 30)
        {
            mainText.text = "You sigh and return the headset to its shelf, knowing that" +'\n' + "you may never again experience the joy and excitement of this virtual world.";
        }
        else if (timer > 26)
        {
            mainText.text = "This world has been saved, but what now?";
        }
        else if (timer > 20)
        {
            mainText.text = "";
        }
        else if(timer > 18)
        {
            if (startLoadNextScene)
            {
                PlayerPrefs.Save();
                SceneManager.LoadSceneAsync("Credits");
                startLoadNextScene = false;
            }
        }
    }
}
