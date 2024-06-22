using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Oculus.Platform;
using HtmlAgilityPack;

public class LevelSelectRankingController : MonoBehaviour
{

    public Text rankingText;
    private float bestSpeed;
    private float bestObsSpeed;

    private float bestTime;
    private float fewestDeaths;

    public int finalScore;

    private int sum;

    public LevelSelectManager LSM;

    public LeaderBoardManager LBM;

    private string data = "30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30:119,110,109,96,111,89,94,93,100,118,109,109,96,91,100,89,104,93,83,60,115,90,99,85,84,76,82,60,65,77,70,71,82,46,59,70,56,108,35:208,190,188,162,193,148,157,156,170,206,189,187,161,152,170,148,177,157,137,90,200,149,167,140,138,121,134,89,100,123,109,113,133,62,87,109,81,186,39:297,270,267,228,274,207,221,219,241,295,268,266,227,213,241,207,251,220,190,121,284,209,236,194,192,167,186,119,135,170,149,154,185,78,116,149,107,265,44:386,349,346,294,355,266,285,282,311,383,348,345,292,274,311,265,324,283,243,151,369,268,305,249,246,212,238,148,171,217,188,195,237,94,144,188,133,343,49:474,429,424,361,436,325,348,345,381,471,427,423,358,335,381,324,398,347,296,181,454,328,374,304,300,258,290,178,206,264,228,237,288,111,173,228,159,421,53:563,509,503,427,518,385,412,408,451,559,506,502,423,396,451,383,472,410,350,211,539,387,442,359,354,304,342,208,241,310,268,278,340,127,202,267,184,499,58:652,589,582,493,599,444,476,471,521,647,586,581,489,457,521,442,545,473,403,242,623,447,511,414,408,349,394,237,276,357,307,319,392,143,230,307,210,577,63:741,669,661,559,680,503,539,534,591,736,665,659,554,518,592,501,619,537,456,272,708,506,580,468,463,395,446,267,311,404,347,361,444,159,259,346,236,656,67:830,749,740,625,761,562,603,597,662,824,745,738,620,579,662,560,692,600,509,302,793,566,648,523,517,440,498,296,346,451,386,402,495,175,288,386,261,734,72:919,828,819,691,843,621,667,660,732,912,824,817,686,640,732,619,766,663,563,332,878,625,717,578,571,486,551,326,382,497,426,443,547,191,316,425,287,812,77:1019,928,919,791,943,721,767,760,832,1012,924,917,786,740,832,719,866,763,663,432,978,725,817,678,671,586,651,426,482,597,526,543,647,291,416,525,387,912,177:1119,1028,1019,891,1043,821,867,860,932,1112,1024,1017,886,840,932,819,966,863,763,532,1078,825,917,778,771,686,751,526,582,697,626,643,747,391,516,625,487,1012,277:1219,1128,1119,991,1143,921,967,960,1032,1212,1124,1117,986,940,1032,919,1066,963,863,632,1178,925,1017,878,871,786,851,626,682,797,726,743,847,491,616,725,587,1112,377";
    private int[,] dataInt = new int[14,40];
    private int[] scores = new int[39];

    private string worldRank = "NA";
    public string currentVersion;
    // Start is called before the first frame update
    public void Start()
    {
        worldRank = PlayerPrefs.GetString("lastDefRanking");
        string[] tempColumns = new string[14];
        string[] tempRow = new string[40];
        tempColumns = data.Split(":");

        for (int i = 0; i < tempColumns.Length; i++)
        {
            tempRow = tempColumns[i].Split(",");
            for (int j = 0; j < tempRow.Length; j++)
            {
                dataInt[i, j] = int.Parse(tempRow[j]);
            }
        }


        UpdateScore();
        OnClickUpdateRank(true);


        //Are we on the most recent version? If so write the entry.
        HtmlWeb web = new HtmlWeb();
        string url = "https://targy.org/NEEVC";

        HtmlDocument doc = web.Load(url);
        string versionNum = doc.DocumentNode.SelectSingleNode("//p[@class='CDt4Ke zfr3Q']").InnerText;
        versionNum = versionNum.Split(':')[1];
        versionNum = versionNum.Trim();
        if (currentVersion == versionNum)
        {
            if (Core.IsInitialized()) LBM.WriteEntry("overallRank", sum);
        }
        
    }
    public void UpdateScore()
    {
        for(int curLevel = 0; curLevel < 39; curLevel++)
        {
            bestSpeed = 5 * (Mathf.Log(float.Parse((PlayerPrefs.GetInt("bestSpeed" + curLevel) + 0.9f).ToString())));
            bestObsSpeed = 5 * (Mathf.Log(float.Parse((PlayerPrefs.GetInt("bestObsSpeed" + curLevel) + 0.9f).ToString())));
            fewestDeaths = 1;
            bestTime = Mathf.Pow(2.71828f, (float)-(PlayerPrefs.GetFloat("bestTime" + curLevel) - 90) / 45);
            finalScore = Mathf.CeilToInt(bestSpeed * bestObsSpeed * fewestDeaths * bestTime);

            Debug.Log(bestSpeed + ", " + bestObsSpeed + ", " + fewestDeaths + ", " + bestTime + ", " + finalScore);
            scores[curLevel] = finalScore;
        }

        
        sum = 0;
        for(int i = 0; i < scores.Length; i++)
        {
            sum += scores[i];
            Debug.Log(scores[i]);
        }
    }

    public void OnClickUpdateRank(bool start)
    {
        int levelID = 0;
        if (start) levelID = PlayerPrefs.GetInt("currentScreenLevelSelect"); else levelID = LSM.currentScreen * 5 + LSM.currentLevel;
        if(levelID != 39)
        {
            rankingText.text = "Last Rank: " + Rank(PlayerPrefs.GetInt("lastRank" + levelID), levelID) + " (" + PlayerPrefs.GetInt("lastRank" + levelID) + ")";
            rankingText.text += '\n' + "Best Rank: " + Rank(scores[levelID], levelID) + " (" + scores[levelID] + ")" + '\n';
            rankingText.text += '\n' + "Overall Rank: " + worldRank + " (" + sum + ")";
        }
        else
        {
            rankingText.text = "Last Rank: NA";
            rankingText.text += '\n' + "Best Rank: NA" + '\n';
            rankingText.text += '\n' + "Overall Rank: " + worldRank + " (" + sum + ")";
        }


    }

    public string Rank(int finalScore, int curLevel)
    {
        string finalGrade = "";
        int count = 0;
        for (int i = 0; i < 14; i++)
        {
            if (finalScore > dataInt[i, curLevel]) count++;
        }

        if (count == 0)
        {
            finalGrade = "F";
        }
        else if (count == 1)
        {
            finalGrade = "F+";
        }
        else if (count == 2)
        {
            finalGrade = "D";
        }
        else if (count == 3)
        {
            finalGrade = "D+";
        }
        else if (count == 4)
        {
            finalGrade = "C";
        }
        else if (count == 5)
        {
            finalGrade = "C+";
        }
        else if (count == 6)
        {
            finalGrade = "B";
        }
        else if (count == 7)
        {
            finalGrade = "B+";
        }
        else if (count == 8)
        {
            finalGrade = "A";
        }
        else if (count == 9)
        {
            finalGrade = "A+";
        }
        else if (count == 10)
        {
            finalGrade = "S";
        }
        else if (count == 11)
        {
            finalGrade = "S+";
        }
        else if (count == 12)
        {
            finalGrade = "SS";
        }
        else if (count >= 13)
        {
            finalGrade = "SS+";
        }

        return finalGrade;
    }

    private float timer = 1;
    public void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
           LBM.GetPlayerEntry("overallRank");
            timer = 5;
            
        }
        string temp = LBM.rank;
        if(temp == "1")
        {
            worldRank = "1st"; 
        }else if(temp == "2")
        {
            worldRank = "2nd";
        }else if(temp == "3")
        {
            worldRank = "3rd";
        }
        else if(temp != "0")
        {
            worldRank = temp.ToString() + "th";
        }
        else
        {
            worldRank = "NA";
        }

        PlayerPrefs.SetString("lastDefRanking", worldRank);
        PlayerPrefs.Save();
    }
}
