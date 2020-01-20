using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockFeatureScript : FeatureScript
{
    public override void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void Unlock()
    {
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
