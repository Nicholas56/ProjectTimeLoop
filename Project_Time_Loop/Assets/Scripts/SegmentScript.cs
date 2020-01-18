using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentScript : MonoBehaviour
{
    public bool staticPlaced;

    public Segment segmentData;
    public Material[] segmentMaterials = new Material[3];

    [Range(0, 5)]
    public int timeBeforeMove = 1;
    [Range(0,90)]
    public int timeToMove;
    [Range(-10,10)]
    public float tileHeight;
    float segmentMovementTime = 5f;
    float heightMove;

    //Add as later feature to record the segments next to this one
    //public List<Segment> adjacentSegments;

    private void Start()
    {
        if (staticPlaced)
        {
            heightMove = tileHeight;
        }
        else
        {
            heightMove = segmentData.timesForMoving[segmentData.posAtTime];
            timeToMove = segmentData.posAtTime;
        }
    }

    public void RandomizeValues()
    {
        tileHeight = Random.Range(-10, 10);
        timeToMove = Random.Range(0, 90);
    }

    private void Update()
    {
        if (Mathf.FloorToInt(GameManager.gameTimer)>timeToMove-timeBeforeMove&& Mathf.FloorToInt(GameManager.gameTimer) < timeToMove)
        {
            gameObject.GetComponent<Renderer>().material = segmentMaterials[1];
        }
        else if(Mathf.FloorToInt(GameManager.gameTimer)>= timeToMove&& Mathf.FloorToInt(GameManager.gameTimer) < timeToMove + segmentMovementTime)
        {
            gameObject.GetComponent<Renderer>().material = segmentMaterials[2];
            transform.position = Vector3.Slerp(transform.position, new Vector3(transform.position.x, heightMove, transform.position.z), Time.deltaTime);
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = segmentMaterials[0];
        }
    }        
    
}
