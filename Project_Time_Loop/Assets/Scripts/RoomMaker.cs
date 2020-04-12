using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Nicholas Easterby - EAS12337350
//When called, instantiates every game object to make the game level
public class RoomMaker : MonoBehaviour
{
    int tileNum;

    //Interprets the data given to set up the game level including segment positions and features properly distributed
    public void MakeRoom(GameObject segmentPrefab, GameObject playerPrefab, List<Segment> listOfSegments, Settings settings,GameObject wallPrefab)
    {
        Debug.Log(listOfSegments);
        Settings currentSettings = settings;
        foreach(Segment segment in listOfSegments)
        {
            tileNum++;
            GameObject newObject = Instantiate(segmentPrefab, segment.pos, Quaternion.identity);
            newObject.transform.SetParent(transform);
            newObject.GetComponent<SegmentScript>().segmentData = segment;
            newObject.transform.Rotate(-90, 0, 0);
            GameObject featureToAdd = null;
            switch (segment.featureHold)
            {
                case Feature.element.Light:
                    featureToAdd = settings.lightFeaturePrefab;                    
                    break;
                case Feature.element.Unlock:
                    featureToAdd = settings.unlockFeaturePrefab;
                    break;
                case Feature.element.Collect:
                    featureToAdd = settings.collectFeaturePrefab;
                    break;
                case Feature.element.Carry:
                    featureToAdd = settings.carryFeaturePrefab;
                    break;
                case Feature.element.Basket:
                    featureToAdd = settings.portalFeaturePrefab;
                    break;
                case Feature.element.None:
                    featureToAdd = null;
                    break;
            }
            if (featureToAdd != null)
            {
                GameObject newFeature = Instantiate(featureToAdd, segment.pos + Vector3.up, Quaternion.Euler(new Vector3(-90, 0, 0)));
                newFeature.transform.SetParent(newObject.transform);
            }
        }

        //The room walls, use the width of the map to calculate positions
        GameObject roomWall = Instantiate(wallPrefab, new Vector3(0, 0, -3f), Quaternion.identity);
        GameObject roomWall2 = Instantiate(wallPrefab, new Vector3(-3f, 0, 0), Quaternion.Euler(new Vector3(0,90,0)));
        float width = Mathf.Sqrt(tileNum) * 5;
        GameObject roomWall3 = Instantiate(wallPrefab, new Vector3(0, 0,width - 2f), Quaternion.identity);
        GameObject roomWall4 = Instantiate(wallPrefab, new Vector3(width - 2f, 0, 0), Quaternion.Euler(new Vector3(0, 90, 0)));
        GameObject ceiling = Instantiate(wallPrefab, new Vector3(0, 50, 0), Quaternion.Euler(new Vector3(90, 0, 0)));
        GameObject underFloor = Instantiate(wallPrefab, new Vector3(0, -50, 0), Quaternion.Euler(new Vector3(90, 0, 0)));

        //Places the player and begins game time
        Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
        Time.timeScale = 1;

        //Adds this script to game, once all objects are in place
        gameObject.AddComponent<PuzzleMaster>();
    }
}
