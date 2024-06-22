using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class introScene : MonoBehaviour
{
    public Material[] images;
    public string[] textList;
    public GameObject sphere;

    public float timer = 100;
    public GameObject quad;
    public GameObject quad1;
    public ParticleSystem particleSystem1;
    public ParticleSystem particleSystem2;
    public Text text;

    public AudioSource happy;
    public AudioSource sad;

    public Material black;
    public Material white;

    public GameObject sphereParent;

    public Color[] startColors;
    private ParticleSystemRenderer mod;
    private ParticleSystemRenderer mod2;

    public bool startAll = false;

    public Light mainLight;

    public GameObject[] deleteObjects;
    // Start is called before the first frame update
    void Start()
    {
        happy.SetScheduledStartTime(33);
        happy.Play();
       RenderSettings.skybox = white;
        RenderSettings.skybox.SetColor("_Tint", new Vector4(0.75f, 0.75f, 0.75f, 1));
        //text.color = Color.black;
        PlayerPrefs.SetInt("introScene", 1);
        mod = particleSystem1.GetComponent<ParticleSystemRenderer>();
        mod2 = particleSystem2.GetComponent<ParticleSystemRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 92.75)
        {
            text.text = "The Chromative Celestium is an ancient traditional" + '\n' + "ceremony held by the Chromas every 100 years.";
        }
        else if (timer > 84)
        {
            text.text = "It is a time when the skies are filled with endless vibrant hues" + '\n' + "believed to bring prosperity and good fortune to all Chromas";
        }
        else if (timer > 79)
        {
            text.text = "One year, the ceremony was more spectacular than ever.";
        }
        else if (timer > 73)
        {
            text.text = "The colors were so brilliant and beautiful that they seemed to dance in the sky" + '\n' + "bringing high hopes to all who witnessed it.";
        }
        else if (timer > 66)
        {
            text.text = "";
        }
        else if (timer > 60)
        {
            text.transform.position = new Vector3(0, 3f, 14);
            happy.Stop();
            sad.Play();
            //RenderSettings.skybox = black;
            //sphereParent.SetActive(false);
            //Start playing the other song
            text.text = "But just as the Chromas were celebrating, a malevolent force appeared.";
            sphere.SetActive(true);
        }
        else if (timer > 54)
        {
            text.text = "";
            startAll = true;
            if (timer < 59)
            {
                mainLight.intensity = 0.5f;
                RenderSettings.skybox.SetColor("_Tint", new Vector4(0.75f, 0.75f, 0.75f, 1));
            }

            if (timer < 58)
            {
                RenderSettings.skybox.SetColor("_Tint", new Vector4(0.5f, 0.5f, 0.5f, 1));
            }

            if (timer < 57)
            {
                mainLight.intensity = 0.125f;
                RenderSettings.skybox.SetColor("_Tint", new Vector4(0.25f, 0.25f, 0.25f, 1));
            }

            if (timer < 56)
            {
                mainLight.intensity = 0f;
                RenderSettings.ambientIntensity = 0f;
                RenderSettings.skybox.SetColor("_Tint", new Vector4(0f, 0f, 0f, 1));
            }

            if (timer < 55)
            {
                for (int i = 0; i < deleteObjects.Length; i++)
                {
                    Destroy(deleteObjects[i].gameObject);
                }
                RenderSettings.skybox.SetColor("_Tint", new Vector4(0.75f, 0.75f, 0.75f, 1));
                RenderSettings.skybox = black;

            }
        }
        else if (timer > 48)
        {
            text.transform.position = new Vector3(0, 3f, 14);
            text.text = "This darkness had consumed all the vibrant colors of the ceremony like a void" + '\n' + "leaving behind only emptiness and despair.";
        }
        else if (timer > 54)
        {
            text.text = "No one knew what this entity was or where it had come from" + '\n' + "but one thing was clear: it was a threat unlike any Chromas had faced before.";
        
            quad.SetActive(false);

            //sphere.transform.position = new Vector3(0, 0, 16);
        }
        else if (timer > 48)
        {

            text.text = "But even in the darkest of times, there is always hope." + '\n' + "And so, the Chromas set out on a quest to find someone who could defeat the terrible force and restore the color to their world.";
            sphere.SetActive(false);

        }
        else if (timer > 42)
        {
            text.text = "After many months of searching, the Chromas stumbled upon a hero";
            quad.SetActive(false);
        }
        else if (timer > 32)
        {
            text.text = "Your eyes shone bright with determination, and the Chromas knew immediately that you were" + '\n' + "their last hope in cleansing the ever spreading darkness from this world.";
        }
        else if (timer > 26)
        {

            text.text = "Good luck on your journey…";

        }
        else if (timer > 22)
        {
            SceneManager.LoadScene("MenuSend");
        }
    }
}
