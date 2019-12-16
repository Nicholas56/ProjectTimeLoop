using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMaker : MonoBehaviour
{
    GameData data;
    public GameObject segmentPrefab;

    private void Start()
    {
        data = FindObjectOfType<GameData>();
    }

    public void MakeRoom()
    {
        Debug.Log(data);
        foreach(Segment segment in FindObjectOfType<GameData>().segments)
        {
            GameObject newObject = Instantiate(segmentPrefab, segment.pos, Quaternion.identity);
            newObject.GetComponent<SegmentScript>().segmentData = segment;
        }
    }
}
