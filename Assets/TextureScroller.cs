using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroller : MonoBehaviour
{

    public Vector2 scrollingSpeed;
    private Vector2 offsetVect = new Vector2(0,0);

    private Material thisMat;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        thisMat = this.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        offsetVect = new Vector2(timer * scrollingSpeed.x, timer * scrollingSpeed.y);
        thisMat.SetTextureOffset("_BaseMap", offsetVect);
    }
}
