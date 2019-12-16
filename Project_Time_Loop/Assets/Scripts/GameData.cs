using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public List<Segment> segments;

    [Range(3,9)]
    public int roomSize = 4;

    [Range(0,10)]
    public int maxHeightShifts = 3;

    List<Vector3> segmentPositions;
    public static List<float> timedYPos;
    List<float> heights;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        CreateMap();
        CreateTimedPositionHeight();
        timedYPos = heights;

        segments = new List<Segment>();

        for(int i = 0; i < roomSize * roomSize; i++)
        {
            int randValue = Random.Range(0, Mathf.FloorToInt(GameManager.resetTime));

            Segment newSegment = new Segment(segmentPositions[i], i, randValue);
            segments.Add(newSegment);
        }

        FindObjectOfType<RoomMaker>().MakeRoom();
    }  

    void CreateTimedPositionHeight()
    {
        heights = new List<float>();
        for(int i = 0; i<GameManager.resetTime; i++)
        {
            float randHeight = Random.Range(-9f, 10f);
            heights.Add(randHeight);
        }
    }

    void CreateMap()
    {
        segmentPositions = new List<Vector3>();

        for(int x = 0; x < roomSize; x++)
        {
            for (int y = 0; y < roomSize; y++)
            {
                Vector3 pos = new Vector3(x * 5, 0, y * 5);
                segmentPositions.Add(pos);
            }
        }
    }
    
}

struct SaveData
{
    List<Segment> savedSegments;
    
}
