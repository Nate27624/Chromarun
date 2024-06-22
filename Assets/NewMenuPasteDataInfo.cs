using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HtmlAgilityPack;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewMenuPasteDataInfo : MonoBehaviour
{
    public string levelsData;
    public string[] levelNames;

    public int screenIndex = 0;
    
    public Text mainText;
    public int maxScreenIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = web.Load("https://sites.google.com/view/eeeeemkv/targy-custom-maps/UserInfo");
        levelsData = doc.DocumentNode.SelectSingleNode("//*[@id='h.3d456bfdd45afcd3_13']/div/div").InnerText;
        levelNames = levelsData.Split('+');

        maxScreenIndex = Mathf.CeilToInt(levelNames.Length / 5);
        updateScreen();

    }

    public void updateScreen()
    {
        mainText.text = "";
        for(var i = 5*screenIndex; i < (5 + 5*screenIndex); i++)
        {
         if(i<levelNames.Length) mainText.text += levelNames[i].Replace(",", " | ") + "\n";  
        }
    }

    public void upScreenIndex()
    {
        if (screenIndex < maxScreenIndex)
        {
            screenIndex++;
            updateScreen();
        }
    }

    public void downScreenIndex()
    {
        if (screenIndex > 0)
        {
            screenIndex--;
            updateScreen();
        }
    }
}
