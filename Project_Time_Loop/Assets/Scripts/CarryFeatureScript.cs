using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//Nicholas Easterby - EAS12337350
//This script inherits from the feature script. Implements functionality for features that can be carried
public class CarryFeatureScript : FeatureScript
{
    bool isCarry = false;
    Transform player;
    GameObject[] mapPortals;
    GameObject lastParentSegment;

    [Range(0,5)]
    public float portalThresholdDistance = 2;

    // Start is called before the first frame update
    protected override void Start()
    {
        //Finds the portals and player
        base.Start();
        mapPortals = GameObject.FindGameObjectsWithTag("Portal");
        player = GameObject.FindGameObjectWithTag("Interact").transform;
    }
    
    public void CheckForPortal()
    {
        foreach(GameObject portal in mapPortals)
        {//chacks to see if the portal is close enough
            if (Vector3.Distance(transform.position, portal.transform.position) < portalThresholdDistance)
            {//then checks to see if the id matches
                if (portal.GetComponent<FeatureScript>().featureID == featureID)
                {
                    DestroyFeature();
                }
            }
        }
    }

    public void DestroyFeature()
    {
        //When the feature is deposited in the correct portal, this removes the object and updates the score
        Destroy(gameObject);
        PuzzleMaster.AddToScore();
    }

    public override void Effect()
    {
        //The carry function is given to the inherited Effect function
        base.Effect();
        FindNewParent();
        isCarry = !isCarry;
        //Sets the last parent, so that if the player drops this, the old parent can be set
        lastParentSegment = transform.parent.gameObject;
        if (isCarry)
        {
            transform.SetParent(player);
        }
        else transform.SetParent(lastParentSegment.transform);
        //If deposited by a portal, the correct functions take place
        CheckForPortal();
    }
}
