using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        Destroy(gameObject);
        PuzzleMaster.AddToScore();
    }

    public override void Effect()
    {
        base.Effect();
        FindNewParent();
        isCarry = !isCarry;
        lastParentSegment = transform.parent.gameObject;
        if (isCarry)
        {
            transform.SetParent(player);
        }
        else transform.SetParent(lastParentSegment.transform);
        CheckForPortal();
    }
}
