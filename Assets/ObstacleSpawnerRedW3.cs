using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerRedW3 : MonoBehaviour
{
    public GameObject lazerPointStarter;
    public GameObject rotatePlatform;
    public LayerMask lazerLayerMask;

    public int amountToSpawn;
    public Vector3 minSpawn;
    public Vector3 maxSpawn;
    public float offsetY;

    public bool regen = true;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    private void Update()
    {
        generate();
    }

    public void generate()
    {
        if (regen)
        {
            regen = false;
            for (var i = 0; i < amountToSpawn; i++)
            {
                lazerPointStarter.transform.position = new Vector3(Random.Range(minSpawn.x, maxSpawn.x), 100, Random.Range(minSpawn.z, maxSpawn.z));
                RaycastHit hit;
                if (Physics.Raycast(lazerPointStarter.transform.position, Vector3.down, out hit, 999, lazerLayerMask))
                {
                    GameObject tempRotationObject = Instantiate(rotatePlatform, new Vector3(hit.point.x, hit.point.y + offsetY, hit.point.z), Quaternion.identity, this.transform);
                    tempRotationObject.transform.up = hit.normal;
                }
            }
        }
    }
}
