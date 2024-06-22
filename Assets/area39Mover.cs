using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class area39Mover : MonoBehaviour
{
    public GameObject[] platforms;
    public float[] speed;
    public float[] maxVal;
    public float[] minVal;
    public float[] speedStart;

    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for(var i = 0; i <= 6; i++)
        {
            platforms[i].transform.Translate(Vector2.left * speed[i] * Time.fixedDeltaTime);

            if (platforms[i].transform.localPosition.x >= maxVal[i])
            {
                speed[i] = speedStart[i];
            }
            if (platforms[i].transform.localPosition.x <= minVal[i])
            {
                speed[i] = -speedStart[i];
            }

            if ((speed[0] == speedStart[0]) && (speed[platforms.Length - 1] == speedStart[platforms.Length - 1] && speedStart[3] == speed[3]))
            {
                if(i+1 < 7) platforms[i].transform.localPosition = new Vector3(platforms[i + 1].transform.localPosition.x + offset, platforms[i].transform.localPosition.y, platforms[i].transform.localPosition.z);
            }
        }
    }
}
