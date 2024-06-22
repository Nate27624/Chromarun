using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LogoColorMover : MonoBehaviour
{

    public Color[] colors;
    public Color[] colorsNew;
    public Text[] texts;

    private float timer = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = 0.2f;
            for(int i = 0; i < colors.Length; i++)
            {
                if(i > 0)
                {
                    colorsNew[i] = colors[i - 1];
                }
                if (i == 0) colorsNew[0] = colors[colors.Length - 1];
                
            }

            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].color = colors[i];
                colors[i] = colorsNew[i];
            }


        }
    }
}
