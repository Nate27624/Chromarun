using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRCamTrail : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject OVRCam;
    public CollisionGameReset CollisionCollider;
    public float offset;
    public TrailRenderer trailRender;
    public TrailRenderer trailRenderTwo;
    public int count;

    public bool reset;
    public Material clear;
    private Material normal;

    public bool render;
    private bool prefValue;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        reset = false;
        normal = trailRender.material;

        if (!PlayerPrefs.HasKey("trailEffect"))
        {
            PlayerPrefs.SetInt("trailEffect", 1);
            PlayerPrefs.Save();
        }
        else if(PlayerPrefs.GetInt("trailEffect") == 1)
        {
            prefValue = true;
        }
        else
        {
            prefValue = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (prefValue)
        {
            if (this.GetComponent<ContinuousMovement>())
            {
                render = (this.GetComponent<ContinuousMovement>().startGame == 1);
            }

            if (count == 0)
            {
                if (render)
                {
                    trailRender.transform.position = new Vector3(mainCam.transform.position.x, OVRCam.transform.position.y - offset, mainCam.transform.position.z);
                }

                trailRenderTwo.material = normal;
                trailRender.material = clear;
            }
            if (count == 1)
            {
                if (render)
                {
                    trailRenderTwo.transform.position = new Vector3(mainCam.transform.position.x, OVRCam.transform.position.y - offset, mainCam.transform.position.z);
                }

                trailRender.material = normal;
                trailRenderTwo.material = clear;
            }


            if (reset)
            {

                reset = false;

                if (count == 0)
                {
                    trailRenderTwo.transform.position = new Vector3(mainCam.transform.position.x, OVRCam.transform.position.y - offset, mainCam.transform.position.z);
                    trailRenderTwo.Clear();
                }
                else if (count == 1)
                {
                    trailRender.transform.position = new Vector3(mainCam.transform.position.x, OVRCam.transform.position.y - offset, mainCam.transform.position.z);
                    trailRender.Clear();
                }

                count++;

                if (count > 1)
                {
                    count = 0;
                }

            }

        }
    }
}
