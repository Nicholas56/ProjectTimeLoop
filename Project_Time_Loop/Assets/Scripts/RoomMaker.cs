using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMaker : MonoBehaviour
{
    int tileNum;

    public void MakeRoom(GameObject segmentPrefab, GameObject playerPrefab, List<Segment> listOfSegments, GameObject featurePrefab,GameObject wallPrefab, GameData.gameMode mode)
    {
        Debug.Log(listOfSegments);
        foreach(Segment segment in listOfSegments)
        {
            tileNum++;
            GameObject newObject = Instantiate(segmentPrefab, segment.pos, Quaternion.identity);
            newObject.transform.SetParent(transform);
            newObject.GetComponent<SegmentScript>().segmentData = segment;
            newObject.transform.Rotate(-90, 0, 0);
            if (segment.type!=Segment.featureType.None)
            {
                GameObject newFeature = Instantiate(featurePrefab, segment.pos + Vector3.up, Quaternion.identity);
                newFeature.transform.SetParent(newObject.transform);
                switch (mode)
                {
                    case GameData.gameMode.LightGame:

                        break;
                    case GameData.gameMode.CollectionGame:

                        break;
                }
            }
        }

        //The room walls
        GameObject roomWall = Instantiate(wallPrefab, new Vector3(0, 0, -3f), Quaternion.identity);
        GameObject roomWall2 = Instantiate(wallPrefab, new Vector3(-3f, 0, 0), Quaternion.Euler(new Vector3(0,90,0)));
        float width = Mathf.Sqrt(tileNum) * 5;
        GameObject roomWall3 = Instantiate(wallPrefab, new Vector3(0, 0,width - 2f), Quaternion.identity);
        GameObject roomWall4 = Instantiate(wallPrefab, new Vector3(width - 2f, 0, 0), Quaternion.Euler(new Vector3(0, 90, 0)));
        GameObject ceiling = Instantiate(wallPrefab, new Vector3(0, 50, 0), Quaternion.Euler(new Vector3(90, 0, 0)));
        GameObject underFloor = Instantiate(wallPrefab, new Vector3(0, -50, 0), Quaternion.Euler(new Vector3(90, 0, 0)));


        Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
        Time.timeScale = 1;
    }
}
