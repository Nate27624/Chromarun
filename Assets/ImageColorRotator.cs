using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageColorRotator : MonoBehaviour
{
    public Color[] colors;

    public float speed;
    private float timer = 0;

    private Image image;
    public Image handle;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1;
        image = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < speed)
        {
            timer = 1;
            Color tempColor = colors[Random.Range(0, colors.Length - 1)];
            image.color = tempColor;
            handle.color = tempColor;
        }
    }
}
