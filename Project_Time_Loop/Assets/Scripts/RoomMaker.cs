using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMaker : MonoBehaviour
{

    public void MakeRoom(GameObject segmentPrefab, GameObject playerPrefab, List<Segment> listOfSegments, GameObject featurePrefab)
    {
        Debug.Log(listOfSegments);
        foreach(Segment segment in listOfSegments)
        {
            GameObject newObject = Instantiate(segmentPrefab, segment.pos, Quaternion.identity);
            newObject.transform.SetParent(transform);
            newObject.GetComponent<SegmentScript>().segmentData = segment;
            newObject.transform.Rotate(-90, 0, 0);
            if (segment.featureHold)
            {
                GameObject newFeature = Instantiate(featurePrefab, segment.pos + Vector3.up, Quaternion.identity);
                newFeature.transform.SetParent(newObject.transform);
            }
        }

        Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
        Time.timeScale = 1;
    }
}
