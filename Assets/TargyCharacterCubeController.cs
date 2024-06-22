using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargyCharacterCubeController : MonoBehaviour
{
    // Start is called before the first frame update

    public Material[] mats;

    private MeshRenderer meshRend;

    private float timerP1;

    public Vector2 timerBoundsP1;
    void Start()
    {
        meshRend = this.GetComponent<MeshRenderer>();
        meshRend.material = mats[Random.Range(0, mats.Length)];

        timerP1 = Random.Range(timerBoundsP1.x, timerBoundsP1.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.name != "ModelBody")
        {
            timerP1 -= Time.deltaTime;
            if (timerP1 < 0)
            {
               Destroy(this.transform.gameObject);
            }
        }
    }
}
