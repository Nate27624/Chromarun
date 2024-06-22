using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsController : MonoBehaviour
{
    public int levelID;
    public GameObject Area01;
    public bool otherArea01;
    public GameObject Area012;
   


    public GameObject player;
    private int state;

    public bool isMoving;
    public float timer = 0;

    private bool isMovingChange = false;

    public float startTime = 0;

    private float totalTime;
    private float globalStartTime;
    private float bestStartTime;

    public int localDeath = 0;

    private int startDeaths;
    private int globalStartDeaths;
    private int bestStartDeaths;
    public bool noBestDeath;
    //Time UI stuff
    public Text globalTimeText;
    public Text localTime;
    public Text bestTimeText;

    //Death UI stuff;
    public Text globalDeathsText;
    public Text localDeathsText;
    public Text fewestDeathsText;

    public bool readyToMoveToNextScene;
    private bool beatenTime = false;
    // Start is called before the first frame update
    void Start()
    {
        //startTime = PlayerPrefs.GetFloat("totalTime" + levelID);
        startTime = 0;
        totalTime = PlayerPrefs.GetFloat("totalTime" + levelID);
        globalStartTime = PlayerPrefs.GetFloat("globalTime");
        bestStartTime = PlayerPrefs.GetFloat("bestTime" + levelID);

        startDeaths = PlayerPrefs.GetInt("totalDeaths" + levelID);
        globalStartDeaths = PlayerPrefs.GetInt("globalDeaths");
        bestStartDeaths = PlayerPrefs.GetInt("fewestDeaths" + levelID);

        if(bestStartDeaths == 0)
        {
            noBestDeath = true;
        }

        bestStartDeaths -= 1;

        if (!noBestDeath) fewestDeathsText.text = "Fewest Deaths: " + bestStartDeaths; else fewestDeathsText.text = "Fewest Deaths: NA";
        if (bestStartTime != 0) bestTimeText.text = "Best Time: " + bestStartTime + " seconds"; else bestTimeText.text = "Best Time: NA";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.GetComponent<ContinuousMovementScriptted>())
        {
            state = player.GetComponent<ContinuousMovementScriptted>().startGame;
        }
        else if (player.GetComponent<continuousMovementGreen>())
        {
            state = player.GetComponent<continuousMovementGreen>().startGame;
        }
        else
        {
            state = player.GetComponent<ContinuousMovement>().startGame;
        }

        if (state == 1) isMoving = true; else isMoving = false;

        if (isMoving == false && isMovingChange == true)
        {
            localDeath += 1;
        }

        isMovingChange = isMoving;

        if (isMoving)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            timer = 0;
        }

        startTime = startTime + Time.deltaTime;
        //Update the UI Accordingly ;)
        localTime.text = "Total Time: " + Mathf.Round(TotalTime() * 100/60) / 100 + " Minutes";
        globalTimeText.text = "Global Time: " + Mathf.Round(globalTime() * 100/3600) / 100 + " hours";

        localDeathsText.text = "Total Deaths: " + totalDeaths();
        globalDeathsText.text = "Global Deaths: " + globalDeaths();

        PlayerPrefs.Save();
    }

    public void timeCalculator()
    {
        if(timer < bestStartTime)
        {
            PlayerPrefs.SetFloat("bestTime" + levelID, timer);
            beatenTime = true;
            PlayerPrefs.Save();
        }else if(bestStartTime == 0)
        {
            PlayerPrefs.SetFloat("bestTime" + levelID, timer);
            beatenTime = true;
            PlayerPrefs.Save();
        }
            
    }

    public float TotalTime()
    {
        PlayerPrefs.SetFloat("totalTime" + (levelID), totalTime + startTime);
        return totalTime + startTime;
    }

    public float globalTime()
    {
        globalStartTime = globalStartTime + Time.deltaTime;

        PlayerPrefs.SetFloat("globalTime", globalStartTime);
        
        return globalStartTime;
    }

    public void fewestDeathTotal()
    {
           int bestDeath = PlayerPrefs.GetInt("fewestDeaths" + levelID);

            if(localDeath < bestDeath)
            {
                PlayerPrefs.SetInt("fewestDeaths" + levelID, localDeath + 1);
                PlayerPrefs.Save();

        }
        else if(noBestDeath)
        {
            PlayerPrefs.SetInt("fewestDeaths" + levelID, localDeath + 1);
            PlayerPrefs.Save();
        }
    }

    public int totalDeaths()
    {
        int totalDeaths = startDeaths + localDeath;
        PlayerPrefs.SetInt("totalDeaths" + levelID, totalDeaths);

        return totalDeaths;
    }

    public int globalDeaths()
    {
        int globalDeaths = globalStartDeaths + localDeath;
        PlayerPrefs.SetInt("globalDeaths", globalDeaths);

        return globalDeaths;
    }

    public void UpdateSpeed()
    {
        int curSpeed = PlayerPrefs.GetInt("playerDifficulty");
        if (curSpeed > PlayerPrefs.GetInt("bestSpeed" + levelID))
        {
            PlayerPrefs.SetInt("bestSpeed" + levelID, curSpeed);
        }
        PlayerPrefs.Save();
    }

    public void UpdateObstacleSpeed()
    {
        int curObsSpeed = PlayerPrefs.GetInt("obstacleDifficulty");
        if(curObsSpeed > PlayerPrefs.GetInt("bestObsSpeed" + levelID))
        {
            PlayerPrefs.SetInt("bestObsSpeed" + levelID, curObsSpeed);
        }
        PlayerPrefs.Save();
    }

    public void SetLastRank()
    {
        float bestSpeed = 5 * (Mathf.Log(float.Parse((PlayerPrefs.GetInt("playerDifficulty") + 0.9f).ToString())));
        float bestObsSpeed = 5 * (Mathf.Log(float.Parse((PlayerPrefs.GetInt("obstacleDifficulty") + 0.9f).ToString())));
        float fewestDeaths = 1;
        float bestTime = 0;
       if(timer < PlayerPrefs.GetFloat("bestTime"+levelID) || beatenTime) bestTime = Mathf.Pow(2.71828f, (float)-(PlayerPrefs.GetFloat("bestTime"+levelID) - 90) / 45); else bestTime = Mathf.Pow(2.71828f, (float)-(timer - 90) / 45);
        int finalScore = Mathf.CeilToInt(bestSpeed * bestObsSpeed * fewestDeaths * bestTime);
        Debug.Log(bestSpeed + ", " + bestObsSpeed + ", " + fewestDeaths + ", " + bestTime + ", " + finalScore);
        PlayerPrefs.SetInt("lastRank" + (levelID), finalScore);
        PlayerPrefs.Save();
    }
}
