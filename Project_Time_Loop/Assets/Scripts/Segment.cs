using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Nicholas Easterby - EAS12337350
//Provides information structure for a segment object
public class Segment
{
    public Vector3 pos;
    public int segmentID;
    public int posAtTime;
    public List<float> timesForMoving;
    public Feature.element featureHold;

    //Constructor for segment
    public Segment(Vector3 newPos, int newID, int timedPos, List<float> listOfTimes, Feature.element feature)
    {
        pos = newPos;
        segmentID = newID;
        posAtTime = timedPos;
        timesForMoving = listOfTimes;
        featureHold = feature;
    }
}
