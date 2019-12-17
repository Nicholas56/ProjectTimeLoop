using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment
{
    public Vector3 pos;
    public int segmentID;
    public bool willMove = true;
    public int posAtTime;
    public List<float> timesForMoving;
    public bool featureHold;

    public Segment(Vector3 newPos, int newID, int timedPos, List<float> listOfTimes, bool haveFeature)
    {
        pos = newPos;
        segmentID = newID;
        posAtTime = timedPos;
        timesForMoving = listOfTimes;
        featureHold = haveFeature;
    }
}
