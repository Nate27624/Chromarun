using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioController : MonoBehaviour
{
    public GameObject curMenuSphere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(curMenuSphere.transform.localPosition.x, curMenuSphere.transform.localPosition.y,curMenuSphere.transform.localPosition.z);
    }
}
