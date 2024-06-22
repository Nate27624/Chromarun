using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OVR;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class introSceneController : MonoBehaviour
{
    public Text mainText;
    public Text secondText;

    public float startTime = 100;
    public float[] timeChanges;

    public Transform sphereTransform;
    public Transform VRRig;
    public float speed;

    public GameObject mainLight;
    public GameObject directionalLight;

    public int lightCount;
    public GameObject targyObject;

    private int once = 0;
    private int donce = 0;
    private int tonce = 0;

    public GameObject colorSphere;
    public ParticleSystem mainParticleSystem;
    public ParticleSystem secondParticleStstem;

    public GameObject[] destroyThem;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        startTime -= Time.deltaTime;


        if (startTime > timeChanges[0])
        {
            mainText.text = "Color Consumes the" + "\n" + "World of the targys";
        }else if (startTime > timeChanges[1])
        {
            mainText.text = "A playful world," + "\n" + "and a happy one";
        }else if (startTime > timeChanges[2])
        {
            mainText.text = "All targys are vibrant" + "\n" + "with color and life";
        }else{
            changeScene();
        }

    }

    private void changeScene()
    {
        if(once == 0)
        {
            once = 999;
            OVRInput.SetControllerVibration(1, (1/2), OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(1, (1/2), OVRInput.Controller.LTouch);
        }
        sphereTransform.gameObject.GetComponentInChildren<Transform>().gameObject.SetActive(true);
        
        Vector3 scale = sphereTransform.transform.localScale;
        scale.Set((sphereTransform.localScale.x / speed), (sphereTransform.localScale.y / speed), (sphereTransform.localScale.z / speed));
        sphereTransform.localScale = scale;

        sphereTransform.position = new Vector3(VRRig.position.x + (sphereTransform.localScale.x / 2), VRRig.position.y, VRRig.position.z);

        if (sphereTransform.localScale.x < 5)
        {
            directionalLight.SetActive(false);
            sphereTransform.gameObject.SetActive(false);
            VRRig.transform.position = new Vector3(0, -20, -3505);

            if (lightCount == 0)
            {
                mainLight.SetActive(false);
            }
            //mainLight.SetActive(false);
            if (lightCount <= 40)
            {

                if (Random.Range(0, 100) < 15)
                {
                    mainLight.SetActive(false);
                    lightCount += 1;
                    targyObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
                    OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);

                }
                else
                {
                    mainLight.SetActive(true);
                    targyObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }
            else
            {
                mainLight.SetActive(true);
                targyObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

           


        }

        if(startTime > timeChanges[4])
        {
            secondText.text = "Or at least they were...";
        }
        else if (startTime > timeChanges[5])
        {
            secondText.text = "Until one day, a Targy with no color decided" + "\n" + "it all had to change";
        }else if(startTime > timeChanges[6]){
            secondText.text = "Steeling all color and happiness, the evil targy" + "\n" + "thought that they would control the world";
            colorSphere.GetComponent<Renderer>().material.SetColor("_Color", HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.time * 8, 1), 1, 1))); 
        }else if(startTime > timeChanges[7])
        {
            secondText.text = "But the power was too much...";
            colorSphere.SetActive(false);
            if(donce == 0)
            {
                mainParticleSystem.Play();
                secondParticleStstem.Stop();
                donce = 1;
            }
            mainLight.SetActive(false);
        }else if(startTime > timeChanges[8])
        {
            if(tonce == 0)
            {
                for (var i = 0; i < destroyThem.Length; i++)
                {
                    destroyThem[i].transform.position = new Vector3(0, 0, 0);
                }
            }
            tonce = 1;
            mainLight.SetActive(false);
            
            secondText.text = "Defeated, the targys searched for a legend.";
            
        }else if(startTime > timeChanges[9])
        {
            mainLight.SetActive(false);
            secondText.text = "This legend is said to have the powers needed to save the world";
        }else if(startTime > timeChanges[10])
        {
            mainLight.SetActive(false);
            secondText.text = "Good luck on your journey...";
        }else if(startTime > timeChanges[11])
        {
            SceneManager.LoadSceneAsync("MenuSend");
        }
    }

    public void Scene3()
    {
       
    }
}
