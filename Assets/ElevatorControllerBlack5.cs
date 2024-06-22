using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorControllerBlack5 : MonoBehaviour
{
    public OnTriggerEnterBool detectionCube;
    public GameObject player;
    public GameObject targyLight;

    public GameObject arch;

    public float delayTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (detectionCube.trigger)
        {
            closeDoors();
            delayTimer -= Time.deltaTime;
            if(delayTimer < 0)
            { 
                targyLight.SetActive(false);
                if (player.transform.position.z < -62)
                player.GetComponent<ContinuousMovementBlack5>().startGame = 0;
            }
        }
    }

    public void closeDoors()
    {
        if(arch.transform.position.y > 0) arch.transform.Translate(Vector2.down * 50 * Time.deltaTime);
    }
}
