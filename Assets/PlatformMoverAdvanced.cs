using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformMoverAdvanced : MonoBehaviour
{
    public float speed;
    public float velocity;
    public bool lightHit;
    public GameObject OVR;

    private float velocityStart;
    private float speedStart;
    private Vector3 dir;

    public GameObject returnToObject;
    public bool restartSceneOnHit = false;
    public ParticleSystem[] particleSystems;

    public TargyDeathController targyDeathController;
    // Start is called before the first frame update
    void Start()
    {
        speedStart = speed;
        velocityStart = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (lightHit)
        {
            speed = speedStart * 3;
            this.gameObject.transform.LookAt(returnToObject.transform.position);
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            if (Vector3.Distance(this.transform.position, returnToObject.transform.position) < 4)
            {
                for (var i = 0; i < particleSystems.Length; i++)
                {
                    particleSystems[i].Play();
                }
                targyDeathController.hitCount++;
                Debug.Log("PlatformMoverAdvanced is Disabling");
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            this.gameObject.transform.LookAt(OVR.transform.position);
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
