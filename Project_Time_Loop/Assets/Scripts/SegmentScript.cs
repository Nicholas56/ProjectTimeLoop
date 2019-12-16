using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentScript : MonoBehaviour
{
    public Segment segmentData;
    public Material[] segmentMaterials = new Material[3];

    [Range(0, 5)]
    public int timeBeforeMove = 1;
    public int timeToMove;
    float segmentMovementTime = 5f;

    private void Start()
    {
        timeToMove = segmentData.posAtTime;
    }

    private void Update()
    {
        if (segmentData.willMove)
        {
            if (Mathf.FloorToInt(GameManager.gameTimer)>timeToMove-timeBeforeMove&& Mathf.FloorToInt(GameManager.gameTimer) < timeToMove)
            {
                gameObject.GetComponent<Renderer>().material = segmentMaterials[1];
            }
            else if(Mathf.FloorToInt(GameManager.gameTimer)>= timeToMove&& Mathf.FloorToInt(GameManager.gameTimer) < timeToMove + segmentMovementTime)
            {
                gameObject.GetComponent<Renderer>().material = segmentMaterials[2];
                transform.position = Vector3.Slerp(transform.position, new Vector3(transform.position.x, GameData.timedYPos[segmentData.posAtTime], transform.position.z), Time.deltaTime);
            }
            else
            {
                gameObject.GetComponent<Renderer>().material = segmentMaterials[0];
            }
        }        
    }

    void MoveTo()
    {
        Vector3 currentPos = transform.position;
        transform.position = Vector3.Slerp(currentPos, new Vector3(transform.position.x, GameData.timedYPos[segmentData.posAtTime], transform.position.z), 10);
        //transform.Translate(new Vector3(0,GameData.timedYPos[segmentData.posAtTime], 0));

        segmentData.willMove = true;
    }
}
