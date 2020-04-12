using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Nicholas Easterby - EAS12337350
//Inherits from feature script. Provides unique functionality for unlocking
public class UnlockFeatureScript : FeatureScript
{
    protected override void Start()
    {
        //Make this and any children invisible
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void Unlock()
    {
        //Makes all visible
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<MeshRenderer>().enabled = true;
        }
    }

    public override void Effect()
    {
        base.Effect();
        Destroy(gameObject);
        PuzzleMaster.AddToScore();
    }
}
