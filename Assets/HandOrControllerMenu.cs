using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandOrControllerMenu : MonoBehaviour
{
    public GameObject handsCanvas;
    public GameObject controllerCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetActiveController() == OVRInput.Controller.Hands && (!(OVRInput.GetActiveController() == OVRInput.Controller.Touch) && !(OVRInput.Controller.LTouch == OVRInput.GetActiveController()) && !(OVRInput.GetActiveController() == OVRInput.Controller.RTouch)))
        {
            handsCanvas.SetActive(true);
            controllerCanvas.SetActive(false);
        }
        else
        {
            handsCanvas.SetActive(false);
            controllerCanvas.SetActive(true);
        }
    }
}
