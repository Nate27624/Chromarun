using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalHeight : MonoBehaviour
{
    public bool update = false;
    public bool start = true;
    // Start is called before the first frame update
    void Start()
    {
        if(start) this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + PlayerPrefs.GetFloat("additionalHeight"), this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(update) this.transform.position = new Vector3(this.transform.position.x, PlayerPrefs.GetFloat("additionalHeight") + 1, this.transform.position.z);
    }
}
