using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdditionalHeightSetter : MonoBehaviour
{
    public Slider heightSlider;
    public Text heightText;
    // Start is called before the first frame update
    void Start()
    {
        heightSlider.value = PlayerPrefs.GetFloat("additionalHeight");
        bool temp = (Random.Range(0, 200) > 100) ;
        Debug.Log("------------ " + temp);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("additionalHeight", heightSlider.value);
        PlayerPrefs.Save();
        heightText.text = Mathf.Round(heightSlider.value * 10000)/100 + " centimetres | " + (Mathf.Round(heightSlider.value * 100 * 393701 / 10000) / 100) + " inches";
    }
}
