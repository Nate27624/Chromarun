using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionCubesFinale : MonoBehaviour
{
    public GameObject OVRCam;
    public NewBlackPortalController targyController;
    public int waveNumber;

    public bool straightLine;
    public bool freeMovement;

    public bool left;
    public bool right;
    public bool forward;
    public bool down;

    public GameObject sliderDoor;
    public bool startShootin;
    public bool disableCubes;
    public GameObject cubeParent;
    public GameObject[] raiseCubes;

    public bool deactivateObstacles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponentInParent<StraightLineMover>())
        {
            Debug.Log("Trigger");
            OVRCam.transform.GetComponent<StraightLineMover>().forward = false;
            OVRCam.transform.GetComponent<StraightLineMover>().down = false;
            OVRCam.transform.GetComponent<StraightLineMover>().left = false;
            OVRCam.transform.GetComponent<StraightLineMover>().right = false;

            if (forward) OVRCam.transform.GetComponent<StraightLineMover>().forward = true;
            if (down) OVRCam.transform.GetComponent<StraightLineMover>().down = true;
            if (left) OVRCam.transform.GetComponent<StraightLineMover>().left = true;
            if (right) OVRCam.transform.GetComponent<StraightLineMover>().right = true;

            if (straightLine)
            {
                OVRCam.GetComponent<ContinuousMovement>().enabled = false;
                OVRCam.GetComponent<StraightLineMover>().enabled = true;
            }
            else if (freeMovement)
            {
                OVRCam.GetComponent<StraightLineMover>().enabled = false;
                OVRCam.GetComponent<ContinuousMovement>().enabled = true;
            }

            sliderDoor.GetComponent<DoorLowerer>().lower = true;
            targyController.wave = waveNumber;
            if (startShootin) targyController.ultimateShoot = true;
            if (!startShootin) targyController.ultimateShoot = false;
            for(var i = 0; i < raiseCubes.Length; i++)
            {
                raiseCubes[i].GetComponent<DoorLowerer>().raise = true;
            }
            if (disableCubes) cubeParent.SetActive(false);
            if (deactivateObstacles)
            {
                MeshRenderer[] createdGameObjects = targyController.gameObject.GetComponentsInChildren<MeshRenderer>();
                for (var i = 0; i < createdGameObjects.Length - 1; i++)
                {
                    Debug.Log("CollisioDetectionCubesFinale is Disabling");
                    targyController.gameObject.GetComponentsInChildren<PlatformMoverAdvanced>()[i].gameObject.SetActive(false);
                    targyController.gameObject.SetActive(true);
                }

            }

        }


       
    }

}
