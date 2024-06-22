using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBlackPortalController : MonoBehaviour
{
    public GameObject[] fireObstacles;
    public int wave;

    public GameObject OVRCam;

    private int hitCount;

    private float timer;

    public bool ultimateShoot = false;

    private float curWait;

    public AudioSource scream;
    // Start is called before the first frame update
    void Start()
    {
        wave = 0;
        timer = 110;
        curWait = Random.Range(95, 98);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if((timer < curWait) && ultimateShoot)
        {
            timer = 100;
            Instantiate(fireObstacles[wave], this.transform.position, Quaternion.identity, this.transform);
            scream.Play();
            curWait = Random.Range(95, 98);
        }
    }
}
