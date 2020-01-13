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
    public Feature.element featureHold;
    //public enum featureType { None, Light, Collectable, Unlockable, Portal, Carry};
    //public featureType type;

    public Segment(Vector3 newPos, int newID, int timedPos, List<float> listOfTimes, Feature.element feature)
    {
        pos = newPos;
        segmentID = newID;
        posAtTime = timedPos;
        timesForMoving = listOfTimes;
        featureHold = feature;
        //type = chosenType;
    }
}
