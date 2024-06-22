using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepyBlackWorldController : MonoBehaviour
{
    public AudioSource[] audioSources;
    private float timer = 0;
    public Vector2 pitchRange;
    public Vector2 volumeRange;
    public Vector2 spatialBlend;
    private Vector3 spawnPos;
    public Transform OVRPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);
        if (CheckPlaying())
        {
            timer = Random.Range(20, 35);
        }

        if(timer < 0)
        {
            timer = 10;
            int curPlay = Random.Range(0, audioSources.Length);
            audioSources[curPlay].pitch = Random.Range(pitchRange.x, pitchRange.y);
            audioSources[curPlay].volume = Random.Range(volumeRange.x, volumeRange.y);
            audioSources[curPlay].spatialBlend = Random.Range(spatialBlend.x, spatialBlend.y);
            audioSources[curPlay].transform.position = new Vector3(OVRPos.position.x, OVRPos.position.y, OVRPos.position.z);
            audioSources[curPlay].Play();
            Debug.Log("PLaying Song");
        }
    }

    public bool CheckPlaying()
    {
        bool isPlaying = false;
        for(int i = 0; i < audioSources.Length -1; i++)
        {
            isPlaying = (isPlaying || audioSources[i].isPlaying);
        }
        Debug.Log(isPlaying);
        return isPlaying;
    }
}
