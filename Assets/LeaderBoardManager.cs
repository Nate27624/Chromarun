using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform;
using Oculus.Platform.Models;
using UnityEngine.UI;

public class LeaderBoardManager : MonoBehaviour
{
    List<LeaderboardEntry> lbe;
    public int entriesToGet;

    public Text[] entryObjectsRankNumber;
    public Text[] oculusName;
    public Text[] score;

    public Text yourRankText;

    public bool yourRank = false;
    private string oculusID;

    public bool newEndless = true;

    public string rank = "0";
    public string value = "0";
    // Start is called before the first frame update
    private void Awake()
    {
       Core.Initialize();
       Users.GetLoggedInUser().OnComplete(GetLoggedInUser);
    }

    private void Update()
    {
        Debug.Log(oculusID);
    }
    public void WriteEntry(string leaderBoardName,  int currentScore)
    {
        if (currentScore <= 0)
        {
            return;
        }
        Leaderboards.WriteEntry(leaderBoardName, currentScore);
    }

    public void GetHighestEntry(string leaderBoardName)
    {
        lbe = new List<LeaderboardEntry>();
        Leaderboards.GetEntries(leaderBoardName, entriesToGet,LeaderboardFilterType.None,LeaderboardStartAt.Top).OnComplete(LeaderboardCallBack);
    }

    public void GetPlayerEntry(string leaderBoardName)
    {
        lbe = new List<LeaderboardEntry>();
        Leaderboards.GetEntries(leaderBoardName, entriesToGet, LeaderboardFilterType.None, LeaderboardStartAt.CenteredOnViewer).OnComplete(LeaderboardCallBack);
    }

    public void GetFriendEntry(string leaderBoardName)
    {
        lbe = new List<LeaderboardEntry>();
        Leaderboards.GetEntries(leaderBoardName, entriesToGet, LeaderboardFilterType.Friends, LeaderboardStartAt.CenteredOnViewer).OnComplete(LeaderboardCallBack);
    }

  void LeaderboardCallBack(Message<LeaderboardEntryList> msg)
    {
        if (!msg.IsError)
        {
            var entries = msg.Data;
            foreach(var entry in entries)
            {
                lbe.Add(entry);
            }


            if (newEndless)
            {
                UpdateUI();
            }
            else
            {
                UpdateUILevelSelect();
            }
        }
        else
        {
            Debug.LogError("Leaderboards Dude");
        }
    }

    public void UpdateUI()
    {
        for(int i = 0; i < entryObjectsRankNumber.Length; i++)
        {           
            if(i < lbe.Count)
            {
                entryObjectsRankNumber[i].text = "" + lbe[i].Rank;
                oculusName[i].text = "" + lbe[i].User.OculusID;
                score[i].text = "" + lbe[i].Score.ToString();
                Debug.Log(i + ": " + (lbe[i].User.OculusID == oculusID) + " " + lbe[i].User.OculusID + " " + oculusID + " " + "!!!!");
                if (lbe[i].User.OculusID == oculusID)
                {
                    value = lbe[i].Score.ToString();
                    if (yourRank)
                    {
                        yourRankText.text = "Your Rank: " + lbe[i].Rank.ToString();
                    }
                }
            }
        }
       
    }

    public void UpdateUILevelSelect()
    {
        rank = lbe[0].Rank.ToString();
    }

    public void GetLoggedInUser(Message msg)
    {
        if (!msg.IsError)
        {
            User user = msg.GetUser();
            oculusID = user.OculusID;
        }
    }
}
