using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockFeatureScript : FeatureScript
{
    public override void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void Unlock()
    {
        GetComponent<MeshRenderer>().enabled = true;
    }

    public override void Effect()
    {
        base.Effect();
        Destroy(gameObject);
        PuzzleMaster.AddToScore();
    }
}
