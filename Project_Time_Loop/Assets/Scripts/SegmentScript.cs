using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentScript : MonoBehaviour
{
    public Segment segmentData;
    public Material[] segmentMaterials = new Material[3];

    [Range(0, 5)]
    public int timeBeforeMove = 1;
    List<int> times = new List<int>();

    private void Start()
    {

    }

    private void Update()
    {
        if (segmentData.willMove)
        {
            foreach(int check in times)
            {
                if(Mathf.FloorToInt(GameManager.gameTimer)>check-timeBeforeMove&& Mathf.FloorToInt(GameManager.gameTimer) < check)
                {
                    gameObject.GetComponent<Renderer>().material = segmentMaterials[1];
                }
                else if(Mathf.FloorToInt(GameManager.gameTimer) == check)
                {
                    gameObject.GetComponent<Renderer>().material = segmentMaterials[2];
                    segmentData.willMove = false;
                    Invoke("MoveTo", 1);
                }
                else
                {
                    gameObject.GetComponent<Renderer>().material = segmentMaterials[0];
                }
            }
        }
    }

    void MoveTo()
    {
        transform.Translate(new Vector3(0,GameData.timedYPos[segmentData.posAtTime], 0));

        segmentData.willMove = true;
    }
}
