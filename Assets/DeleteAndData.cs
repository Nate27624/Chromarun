using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAndData : MonoBehaviour
{
    public GameObject target;
    public Camera cam;
    private bool IsVisible(Camera c, GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) > 0)
            {
                return false;
            }
            
        }
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!IsVisible(cam, target))
        {
            Debug.Log("is Vislsbkel;");
            target.SetActive(false);
        }
    }
}
