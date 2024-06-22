using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStars : MonoBehaviour
{
    public Vector2 minSpeed;
    public Vector2 maxSpeed;
    public Vector2 actSpeed;

    public TrailRenderer trailRenderer;

    public Vector3 spawnMinRadius;

    public Vector3 spawnMaxRadius;

    public Gradient[] colorGradients;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, new Vector3(0,0,0)) > 700)
        {
            if(this.transform.localScale.x > 0.0001 && trailRenderer.time > 0.01  && trailRenderer.widthMultiplier > 0.075f)
            {
                this.transform.localScale /= 1.01f;
                trailRenderer.time /= 1.01f;
                trailRenderer.widthMultiplier /= 1.01f;
            }
            else
            {
                this.transform.position = new Vector3(Random.Range(spawnMinRadius.x, spawnMaxRadius.x), Random.Range(spawnMinRadius.y, spawnMaxRadius.y), Random.Range(spawnMinRadius.z, spawnMaxRadius.z));
                actSpeed = new Vector2(Random.Range(minSpeed.x, maxSpeed.x), Random.Range(minSpeed.y, maxSpeed.y));
                trailRenderer.Clear();
                trailRenderer.colorGradient = colorGradients[Random.Range(0, colorGradients.Length - 1)];
            }
        }
        else
        {
            if(this.transform.localScale.x < 1.5f)
            {
                this.transform.localScale *= 2;
            }

            if(trailRenderer.time < 0.75f)
            {
                trailRenderer.time *= 1.5f;
            }

            if (trailRenderer.widthMultiplier < 0.25f) trailRenderer.widthMultiplier *= 1.5f;
        }

        this.transform.position = new Vector3(this.transform.position.x + actSpeed.x, this.transform.position.y, this.transform.position.z + actSpeed.y);
    }
}
