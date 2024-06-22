using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessDelete : MonoBehaviour
{
    private GameObject player;
    float timer = 85/10;
    public bool updateDistance = true;
    public bool playerOnArea = false;
    public bool deleteWhenNotRender = true;

    public bool startArea = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("OVRCameraRig");
    }

    // Update is called once per frame
    void Update()
    {
        if (deleteWhenNotRender)
        {
            if (anyObjRender() && Vector3.Distance(player.transform.position, this.transform.position) > 6)
            {
                updateDistance = true;
                Destroy(this.gameObject);
            }
        }
        moreThanTen();
        if (!deleteWhenNotRender) updateDistance = false;
    }

    public bool anyObjRender()
    {
        MeshRenderer[] gameObjectsInArea;
        gameObjectsInArea = GetComponentsInChildren<MeshRenderer>();


        for(var i = 0; i < gameObjectsInArea.Length; i++)
        {
            if(gameObjectsInArea[i].isVisible == true)
            {
                return false;
            }
        }

        return true;
    }

    public void moreThanTen()
    {
        updateDistance = true;
        if (playerOnArea)
        {
            Debug.Log("PlayerOnArea");
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                updateDistance = false;
            }
        }
        

    }
}
