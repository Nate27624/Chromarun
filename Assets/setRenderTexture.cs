using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setRenderTexture : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform OVRCam;
    public Camera portalCam;
    public Material portalMat;

    public Transform portal;
    public Transform otherPortal;

    void Start()
    {
        if(portalCam.targetTexture != null)
        {
            portalCam.targetTexture.Release();
        }

        portalCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        portalMat.mainTexture = portalCam.targetTexture;
    }

    private void LateUpdate()
    {
        portalCam.transform.rotation = Quaternion.Euler(OVRCam.eulerAngles.x, OVRCam.eulerAngles.y, OVRCam.eulerAngles.z);
        //portalCam.transform.position = new Vector3(portalCam.transform.position.x, OVRCam.position.y, portalCam.transform.position.z);
        Vector3 playerOffsetFromPortal = OVRCam.position - otherPortal.position;
        portalCam.transform.position = portal.position + playerOffsetFromPortal;

        float angularDifference = Quaternion.Angle(portal.rotation, otherPortal.rotation);

       //Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifference, Vector3.up);
       //Vector3 newCameraDirection = portalRotationalDifference * OVRCam.forward;

        //portalCam.transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);

        //portalCam.transform.rotation = Quaternion.Euler(portalCam.transform.eulerAngles.x, portalCam.transform.eulerAngles.y + 180, portalCam.transform.eulerAngles.z);


    }
}
