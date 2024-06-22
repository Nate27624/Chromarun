using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargyControllerv2 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject entity;

    private Vector3 startRot;

    public GameObject OVRCam;

    public Vector2 tweakAmount;

    public GameObject shootObstacle;

    public ContinuousMovement contMove;

    private float timer = 100;

    public AudioSource scream;
    void Start()
    {
        startRot = entity.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < Random.Range(85, 95))
        {
            timer = 100;
            if (OVRCam.transform.position.z < -64 &&  OVRCam.transform.position.z > -130f)
            {
                Instantiate(shootObstacle, entity.transform.position, Quaternion.identity, this.transform);
                scream.Play();
            }
        }
        Tweak();

        if(contMove.startGame == 0)
        {
            foreach(Transform child in this.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    public void Tweak()
    {
        entity.transform.eulerAngles = new Vector3(startRot.x, startRot.y + Random.Range(tweakAmount.x, tweakAmount.y), startRot.z);
    }
}
