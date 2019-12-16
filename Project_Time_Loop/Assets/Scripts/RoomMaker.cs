using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMaker : MonoBehaviour
{
    GameData data;
    public GameObject segmentPrefab;
    public GameObject playerPrefab;

    private void Start()
    {
        data = FindObjectOfType<GameData>();
    }

    public void MakeRoom()
    {
        Debug.Log(data.segments);
        foreach(Segment segment in data.segments)
        {
            GameObject newObject = Instantiate(segmentPrefab, segment.pos, Quaternion.identity);
            newObject.transform.SetParent(transform);
            newObject.GetComponent<SegmentScript>().segmentData = segment;
        }

        Instantiate(playerPrefab, new Vector3(0, 1, 0), Quaternion.identity);
    }
}
