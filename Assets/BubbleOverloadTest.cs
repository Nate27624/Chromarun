using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleOverloadTest : MonoBehaviour
{
    public GameObject instantiateThis;
    public Text mainText;
    public bool changeValue;

    public int bubbles = 0;
    // Start is called before the first frame update
    void Start()
    {
        changeValue = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(changeValue || OVRInput.GetDown(OVRInput.Button.Any))
        {
            changeValue = false;
            bubbles++;
            Instantiate(instantiateThis, new Vector3(0, 1, 1), Quaternion.identity, this.transform);
            mainText.text = bubbles.ToString();
        }
    }
}
