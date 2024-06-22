using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform;


public class newEndlessLeaderBoardController : MonoBehaviour
{

    public EndlessScoreAndDist endScore;
    public bool updateOnDeath;

    public GameObject OVRCam;
    public LeaderBoardManager lbm;

    public bool yourScore;

    public bool highScore;

    private float timer = 20;

    private bool gotEntry = false;
    public void Start()
    {
        
    }
    public void Update()
    {
        if (Core.IsInitialized())
        {
            if (!gotEntry)
            {
                if (highScore) lbm.GetHighestEntry("leaderboardDistanceScore");
                if (yourScore) lbm.GetPlayerEntry("leaderboardDistanceScore");
                gotEntry = true;
            }
        }

        timer -= Time.deltaTime;
        if (endScore.updateLeaderboards)
        {
            updateOnDeath = true;
        }

        if((OVRCam.GetComponent<ContinuousMovement>().startGame == 0 && updateOnDeath) || timer < 0)
        {
            timer = 20;
            updateOnDeath = false;
            if(highScore) lbm.GetHighestEntry("leaderboardDistanceScore");
            if(yourScore) lbm.GetPlayerEntry("leaderboardDistanceScore");

            Debug.Log("Fetching Leaderboards ... ");
        }
       
    }
}
