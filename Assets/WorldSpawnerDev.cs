using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Android;

public class WorldSpawnerDev : MonoBehaviour
{
    public string[] textArray;

    public Material[] materials;

    private string[] tempArrayStringBlock;

    public GameObject[] BlockArraysMade;

    private Vector3 tempBlockPosition;

    private GameObject tempBlockGameObject;

    //Universal one time set items
    public Text difficultyText;

    public Text dateCreatedText;

    public Text levelCreatorText;

    public Text levelNameText;

    public Material[] skyBoxMaterials;

    public AudioClip[] audioClips;

    public Text debugText;

    //private TextAsset textAsset;
    private string textAsset;
    // Start is called before the first frame update
    void Start()
    {
        debugText.text = "TargyLevelCode.txt file has been created at: " + Application.persistentDataPath;
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
            Permission.RequestUserPermission(Permission.ExternalStorageRead);

        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
   
        if(File.Exists(Application.persistentDataPath + "TargyLevelCode.txt"))
        {
            if(File.ReadAllText(Application.persistentDataPath + "TargyLevelCode.txt").Length > 0)
            {
                textAsset = File.ReadAllText(Application.persistentDataPath + "TargyLevelCode.txt");
                debugText.gameObject.SetActive(false);
                readTextFile();
            }
            else
            {
                debugText.text = "The file exists at " + Application.persistentDataPath + " but does not contain any data";
            }
            
        }
        else
        {
            new StreamWriter(Application.persistentDataPath + "TargyLevelCode.txt");
        }

        readTextFile();
    }

    public void readTextFile()
    {
        //textArray is a text document that converts numbers For Example: 0 (Block Type),0 (Pos X), 0 (Pos Z), 180 (Rotation), etc...
        textArray = textAsset.Split('+').ToArray();
        for (int i = 0; i < textArray.Length; i++)
        {
            string[] sections = new string[3];
            sections = textArray[i].Split(':');

            string[] pos = new string[9];
            pos = sections[0].Split(',');

            //Make sure we dont have the global values
            {
                if (pos[0].Contains("EEEEE.mkv"))
                {
                    WorldValues(pos);
                    return;
                }
            }

            tempBlockPosition = new Vector3(float.Parse(pos[1]), float.Parse(pos[2]), float.Parse(pos[3]));
            tempBlockGameObject = Instantiate(BlockArraysMade[int.Parse(pos[0])], tempBlockPosition, Quaternion.identity, this.transform);
            tempBlockGameObject.transform.eulerAngles = new Vector3(float.Parse(pos[4]), float.Parse(pos[5]), float.Parse(pos[6]));
            tempBlockGameObject.transform.localScale = new Vector3(float.Parse(pos[7]), float.Parse(pos[8]), float.Parse(pos[9]));

            //This section checks for the two outliers of areas.  Every other area should function the exact same besides these!
            {

                if (pos[0] == "39" || pos[0] == "30")
                {
                    ApplyMats(sections[1], sections[2], tempBlockGameObject, true, false);
                }

                if (pos[0] == "73")
                {
                    ApplyMats(sections[1], sections[2], tempBlockGameObject, false, true);
                }
            }

            ApplyMats(sections[1], sections[2], tempBlockGameObject, false, false);

            //Now check if its the omni moving cube
            {
                if (pos[0] == "79")
                {
                    string[] allVals = new string[10];
                    allVals = sections[3].Split(',');
                    tempBlockGameObject.GetComponentInChildren<PlatformMoverLeftRight>().minVal = float.Parse(allVals[0]);
                    tempBlockGameObject.GetComponentInChildren<PlatformMover>().minVal = float.Parse(allVals[1]);
                    tempBlockGameObject.GetComponentInChildren<PlatformMoverForwardBack>().minVal = float.Parse(allVals[2]);
                    tempBlockGameObject.GetComponentInChildren<PlatformMoverLeftRight>().maxVal = float.Parse(allVals[3]);
                    tempBlockGameObject.GetComponentInChildren<PlatformMover>().maxVal = float.Parse(allVals[4]);
                    tempBlockGameObject.GetComponentInChildren<PlatformMoverForwardBack>().maxVal = float.Parse(allVals[5]);
                    tempBlockGameObject.GetComponentInChildren<PlatformMoverLeftRight>().speedStart = float.Parse(allVals[6]);
                    tempBlockGameObject.GetComponentInChildren<PlatformMover>().speedStart = float.Parse(allVals[7]);
                    tempBlockGameObject.GetComponentInChildren<PlatformMoverForwardBack>().speedStart = float.Parse(allVals[8]);
                }
            }
        }


    }

    public void ApplyMats(string materialDataWalls, string materialDataObstacles, GameObject tempObj, bool checkChildren, bool checkLayer)
    {
        string[] wallsList = new string[5];
        wallsList = materialDataWalls.Split(',');

        string[] obstaclesList = new string[5];
        if (obstaclesList[0] == "NULL") return;
        obstaclesList = materialDataObstacles.Split(',');
        foreach (Transform child in tempObj.transform)
        {
            if (child.transform.gameObject.layer == 7 || checkLayer)
            {
                if (checkChildren)
                {
                    ApplyMats(materialDataWalls, materialDataObstacles, child.gameObject, false, false);
                }

                if (child.GetComponent<MeshRenderer>()) child.GetComponent<MeshRenderer>().material = materials[int.Parse(wallsList[0])];
                if (wallsList[0] == "0" || wallsList[0] == "9" || wallsList[0] == "11")
                {
                    if (child.GetComponent<MeshRenderer>()) child.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", new Vector4(float.Parse(wallsList[1]), float.Parse(wallsList[2]), float.Parse(wallsList[3]), float.Parse(wallsList[4])));
                }
                if (wallsList[0] == "12") MatTwelve(child);
            }

            if (child.transform.gameObject.layer == 9)
            {
                if (obstaclesList[0] == "NULL") return;
                if (checkChildren)
                {
                    ApplyMats(materialDataWalls, materialDataObstacles, child.gameObject, false, false);
                }

                if (child.GetComponent<MeshRenderer>()) child.GetComponent<MeshRenderer>().material = materials[int.Parse(obstaclesList[0])];
                if (obstaclesList[0] == "0" || obstaclesList[0] == "9" || obstaclesList[0] == "11")
                {
                    if (child.GetComponent<MeshRenderer>()) child.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", new Vector4(float.Parse(obstaclesList[1]), float.Parse(obstaclesList[2]), float.Parse(obstaclesList[3]), float.Parse(obstaclesList[4])));
                }
                if (obstaclesList[0] == "12") MatTwelve(child);
            }
        }


    }

    public void WorldValues(string[] worldData)
    {

        PlayerPrefs.SetInt("speed", int.Parse(worldData[1]));
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("speed"));

        levelNameText.text = "Level Name: " + worldData[4];

        levelCreatorText.text = "Created By: " + worldData[5];

        difficultyText.text = "Difficulty: " + worldData[6];

        dateCreatedText.text = "Date Created: " + worldData[7];

        RenderSettings.skybox = skyBoxMaterials[int.Parse(worldData[3])];

        this.GetComponent<AudioSource>().clip = audioClips[int.Parse(worldData[2])];
        this.GetComponent<AudioSource>().Play();

    }

    public void MatTwelve(Transform child)
    {
        if (child.GetComponent<MeshRenderer>()) child.gameObject.AddComponent<rapidColor>(); else return;
        rapidColor temp = child.gameObject.GetComponent<rapidColor>();
        temp.mats = materials; temp.mats = new Material[] { materials[1], materials[2], materials[3], materials[4], materials[5], materials[6], materials[7], materials[8] };
        temp.sphere = child.gameObject;
        temp.timer = 0.5f;
    }
}
