using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyEffectController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject baseObj;
    public GameObject maxDistObj;
    public GameObject minDistObj;
    public TrailRenderer trailRend;
    public Gradient[] colors;

    public float vertSpeed;
    public float vertSpeedStart;

    public float rotSpeed;
    public float rot2Speed;

    public float startTimer = 1;

    void Start()
    {
        rotSpeed = Random.Range(-360, 360);
        rot2Speed = Random.Range(-360, 360);
        trailRend.colorGradient = colors[Random.Range(0, colors.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer > 0)
        {
            startTimer -= Time.deltaTime;
            trailRend.Clear();
        }
        baseObj.transform.Translate(Vector2.up * vertSpeed * Time.deltaTime);
        if (baseObj.transform.localPosition.y >= 1)
        {
            vertSpeed = -vertSpeedStart;
        }
        if (baseObj.transform.localPosition.y <= -5)
        {
            vertSpeed = vertSpeedStart;
        }

        minDistObj.transform.RotateAround(maxDistObj.transform.position, Vector3.up, rotSpeed * Time.deltaTime);
        baseObj.transform.Rotate(Vector2.up, rot2Speed * Time.deltaTime);
    }
}
