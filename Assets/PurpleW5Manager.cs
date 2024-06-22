using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleW5Manager : MonoBehaviour
{
    public GameObject detectionCube;
    public GameObject obstacleCube;
    public AudioSource audioClip;

    public ContinuousMovement OVRCam;
    // Start is called before the first frame update
    void Start()
    {
        detectionCube.SetActive(true);
        obstacleCube.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRCam.startGame == 0)
        {
            detectionCube.SetActive(true);
            obstacleCube.SetActive(true);
        }
    }

    public void UpdateBlocks()
    {
        audioClip.Play();
        obstacleCube.SetActive(false);
        detectionCube.SetActive(false);
    }
}
