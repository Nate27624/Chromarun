using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startSpawner : MonoBehaviour
{

    public GameObject minXYZ;
    public GameObject maxXYZ;

    public GameObject cubeToSpawn;
    public int amountToSpawn;

    public float minScale;
    public float maxScale;

    public string[] levelNames;
    public GameObject mainCamera;
    private Vector3 direction;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0; i < amountToSpawn; i++)
        {
            Vector3 cubePos = new Vector3(Random.Range(minXYZ.transform.position.x, maxXYZ.transform.position.x), Random.Range(minXYZ.transform.position.y, maxXYZ.transform.position.y), Random.Range(minXYZ.transform.position.z, maxXYZ.transform.position.z));
            GameObject temp = Instantiate(cubeToSpawn, cubePos, Quaternion.identity, this.transform);
            float tempFloat = Random.Range(minScale, maxScale);
            temp.transform.localScale = new Vector3(tempFloat, tempFloat, tempFloat);
        }
        SceneManager.LoadSceneAsync(levelNames[PlayerPrefs.GetInt("currentLevel")]);

        
    }

    // Update is called once per frame
    void Update()
    {
        direction = mainCamera.transform.forward;
        player.transform.position += direction * Time.deltaTime * 35;
    }
}
