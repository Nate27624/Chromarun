using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targyController : MonoBehaviour
{
    public GameObject targy;
    public GameObject OVRCam;
    public GameObject OVRFuture;

    public float timer = 4;
    private float timerStart;
    public bool attackBool = false;
    public bool fireBool = false;
    public bool fireStill = false;
    private bool fireInstantiate = false;
    public float[] speed;
    public float[] objectSpeed;

    public GameObject[] objects;
    public GameObject obstacle;

    public float tweakAmount;

    public Texture normalMouth;
    public Texture fireMouth;
    public Material mouthMaterial;

    public int wave;

    public float distanceToShoot;
    public bool ultimateShoot;
    public bool moveObstacles = true;
    // Start is called before the first frame update
    void Start()
    {
        timerStart = timer;
    }

    // Update is called once per frame
    void Update()
    {
        rotateTargy();
        timer -= Time.deltaTime;
       if(timer < 0)
        {
            fireInstantiate = true;
            fight();
            timer = timerStart + (Random.Range(0, 150) / 50);
        }
        else
        {
            fireInstantiate = false;
        }

        if (moveObstacles)
        {
            foreach (Transform cube in this.transform)
            {
                cube.transform.Translate(Vector3.forward * (objectSpeed[wave] + (Vector3.Distance(OVRCam.transform.position, targy.transform.position)) / 5) * Time.deltaTime);
            }
        }


    }

    public void rotateTargy()
    {
        tweakAmount = (30 / Vector3.Distance(targy.transform.position, OVRCam.transform.position));
        if(!attackBool) targy.transform.LookAt(OVRCam.transform); targy.transform.eulerAngles = new Vector3 (0, targy.transform.rotation.eulerAngles.y, 0) + new Vector3(0, Random.Range(-15,15), 0); 

        if (attackBool) targy.transform.LookAt(OVRCam.transform); targy.transform.eulerAngles = new Vector3(0,180+targy.transform.rotation.eulerAngles.y, 0) + new Vector3(0, Random.Range(-tweakAmount, tweakAmount), 0); 
    }

    public void fight()
    {
        if (ultimateShoot)
        {
            if (Vector3.Distance(OVRCam.transform.position, targy.transform.position) < distanceToShoot)
            {
                if (fireInstantiate)
                {

                    targy.GetComponent<AudioSource>().Play();
                    obstacle = Instantiate(objects[wave], new Vector3(targy.transform.position.x, targy.transform.position.y - (3 / 2), targy.transform.position.z), Quaternion.identity, this.transform);
                    Vector3 tempCamPos = new Vector3(OVRFuture.transform.position.x, targy.transform.position.y - (3 / 2), OVRFuture.transform.position.z);

                    obstacle.transform.LookAt(tempCamPos);

                }
                fireStill = false;


                if (Vector3.Distance(obstacle.transform.position, targy.transform.position) > 20) fireBool = false;
                if (Vector3.Distance(obstacle.transform.position, targy.transform.position) > 7)
                {
                    this.GetComponent<AudioSource>().Stop();
                    mouthMaterial.SetTexture("_BaseMap", normalMouth);
                }
            }
            else
            {
                this.GetComponent<AudioSource>().Stop();
                mouthMaterial.SetTexture("_BaseMap", normalMouth);
            }
        }
        
    }
     
}
