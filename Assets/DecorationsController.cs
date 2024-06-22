using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationsController : MonoBehaviour
{
    // Start is called before the first frame update
    public Color[] colors;

    private Color curColor;

    private float timer = 0;

    public LineRenderer line;

    public Transform[] linePos;

    private Vector3[] vectPos = new Vector3[2];
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < linePos.Length; i++)
        {
            vectPos[i] = new Vector3(linePos[i].transform.position.x, linePos[i].transform.position.y, linePos[i].transform.position.z);
        }
        line.SetPositions(vectPos);
    }


}
