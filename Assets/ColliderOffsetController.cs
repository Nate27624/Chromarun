using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderOffsetController : MonoBehaviour
{
    private SphereCollider thisSphereCollider;
    // Start is called before the first frame update
    void Start()
    {
        thisSphereCollider = this.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetActiveController() == OVRInput.Controller.LHand || OVRInput.GetActiveController() == OVRInput.Controller.RHand || OVRInput.GetActiveController() == OVRInput.Controller.None || OVRInput.GetActiveController() == OVRInput.Controller.Hands || OVRInput.GetActiveController() == OVRInput.Controller.Gamepad || OVRInput.GetActiveController() == OVRInput.Controller.Remote)
        {
            thisSphereCollider.center = new Vector3(0, 0, 0.05f);
            thisSphereCollider.radius = 0.15f;
        }
        else
        {
            thisSphereCollider.center = new Vector3(0, 0, 0f);
        }
    }
}
