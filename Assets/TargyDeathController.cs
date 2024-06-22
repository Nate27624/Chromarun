using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargyDeathController : MonoBehaviour
{
    public bool resetHits;
    public int hitCount;
    public string finalSceneName;

    public GameObject lightSource;
    private float timer;
    public GameObject OVR;
    public GameObject otherLightSource;

    public Material skybox;

    public GameObject targy;
    public GameObject targyParent;

    private bool loadNewScene = false;
    private bool currentlyLevelSelect;
    private bool hasLoadedScene = false;

    public GameObject centerSphere;
    public ParticleSystem sphereStartSize;
    // Start is called before the first frame update
    void Start()
    {
        timer = 5;
        hitCount = 0;
        if (PlayerPrefs.GetInt("curLevelSelect") == 1) currentlyLevelSelect = true; else currentlyLevelSelect = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (resetHits)
        {
            hitCount = 0;
            resetHits = false;
        }

        centerSphere.transform.localScale = new Vector3(2*(10 - hitCount), 2 * (10 - hitCount), 2 * (10 - hitCount));
        var ps = sphereStartSize.main;
        ps.startSizeX = 3 * (10 - hitCount);
        ps.startSizeY = 3 * (10 - hitCount);
        ps.startSizeZ = 3 * (10 - hitCount);

        //Once dead load next scene
        if(hitCount >= 9)
        {
            OVR.transform.position = new Vector3(0, -100, 0);
            OVR.GetComponent<ContinuousMovement>().enabled = false;
            OVR.GetComponent<StraightLineMover>().enabled = false;
            timer -= Time.deltaTime;
            otherLightSource.SetActive(true);
            RenderSettings.skybox = skybox;
            RenderSettings.fog = false;
            if(lightSource.GetComponent<Light>().intensity < 100)
            {
                lightSource.GetComponent<Light>().intensity += 1;
                lightSource.GetComponent<Light>().intensity *= 10/9;
                otherLightSource.GetComponent<Light>().intensity += 1;
                otherLightSource.GetComponent<Light>().intensity *= 10 / 9;
                targy.GetComponent<NewBlackPortalController>().ultimateShoot = false;
            }
            else
            {
                targyParent.SetActive(false);
                loadNewScene = true;
            }


            if (loadNewScene && currentlyLevelSelect && !hasLoadedScene)
            {
                
                    SceneManager.LoadSceneAsync("LevelSelect");
                    hasLoadedScene = true;
            }
            if(loadNewScene && !currentlyLevelSelect && !hasLoadedScene)
            {
                SceneManager.LoadSceneAsync(finalSceneName);
                hasLoadedScene = true;
            }
            
        }
    }
}
