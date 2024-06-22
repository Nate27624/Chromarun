using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RapidTextColor : MonoBehaviour
{
    public Text mainText;
    public Color[] colors;

    public float speed;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < speed)
        {
            timer = 1;
              
            mainText.color = colors[Random.Range(0, colors.Length)];
        }
        
    }
}
