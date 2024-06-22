using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBlack5Fixer : MonoBehaviour
{
    public GameObject OVR;
    public NewBlackPortalController targyController;
    public TargyDeathController targyDeathController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == 7 || collision.collider.gameObject.layer == 9)
        {
            OVR.GetComponent<ContinuousMovement>().enabled = true;
            OVR.GetComponent<StraightLineMover>().enabled = false;
            targyController.ultimateShoot = false;
            MeshRenderer[] createdGameObjects = targyController.gameObject.GetComponentsInChildren<MeshRenderer>();
            for (var i = 0; i < createdGameObjects.Length - 1; i++)
            {
                Debug.Log("CollisioBlack5Fixer is Disabling");
                targyController.gameObject.GetComponentsInChildren<PlatformMoverAdvanced>()[i].gameObject.SetActive(false);
                targyController.gameObject.SetActive(true);
            }
            targyDeathController.resetHits = true;
        }

    }
}

