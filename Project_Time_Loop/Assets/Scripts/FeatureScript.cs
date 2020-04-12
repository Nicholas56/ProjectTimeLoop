using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Nicholas Easterby - EAS12337350
//Provides base functions for all features in the game
public class FeatureScript : MonoBehaviour
{
    public int featureID;

    public bool isInteracted = false;

    GameObject[] mapSegments;

    protected virtual void Start()
    {
        //Finds all map tiles
        mapSegments = GameObject.FindGameObjectsWithTag("Segment");
        FindNewParent();
    }

    //Uses map info to find the closest tile to set as the parent of this feature
    public void FindNewParent()
    {
        GameObject closestSegment = null;
        foreach (GameObject segment in mapSegments)
        {
            if (closestSegment == null) { closestSegment = segment; }
            else
            {//If the current segment is closer than the previous closest segment, then this segment becomes the closest one
                if (Vector3.Distance(transform.position, closestSegment.transform.position) > Vector3.Distance(transform.position, segment.transform.position))
                {
                    closestSegment = segment;
                }
            }
        }
        transform.SetParent(closestSegment.transform);
    }


    public bool Check()
    {
        return isInteracted;
    }

    public int GetSegmentID()
    {
        return transform.parent.GetComponent<SegmentScript>().segmentData.segmentID;
    }
    public void SetID(int newID)
    {
        featureID = newID;
    }

    //Virtual function inherited by other scripts, marks the feature as interacted
    public virtual void Effect()
    {
        isInteracted = true;
    }
}
