using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HtmlAgilityPack;

public class EndlessLeaderBoardController : MonoBehaviour
{
    // Start is called before the first frame update
    public EndlessScoreAndDist endScore;
    public bool updateOnDeath;

    public GameObject OVRCam;
    public LeaderBoardManager lbm;

    public bool yourScore;
    public bool highScore;

    private float timer = 20;
    void Start()
    {
        if (highScore) lbm.GetHighestEntry("endlessLeaderboard");

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (endScore.updateLeaderboards)
        {
            updateOnDeath = true;
        }

        if ((OVRCam.GetComponent<ContinuousMovement>().startGame == 0 && updateOnDeath) || timer < 0)
        {
            timer = 20;
            updateOnDeath = false;
            if (highScore) lbm.GetHighestEntry("endlessLeaderboard");
            if (yourScore) lbm.GetPlayerEntry("endlessLeaderboard");

            Debug.Log("Fetching Leaderboards ... ");
        }
    }
}
