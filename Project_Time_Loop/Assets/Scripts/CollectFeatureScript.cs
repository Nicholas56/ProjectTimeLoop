using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFeatureScript : FeatureScript
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        PuzzleMaster.AddToScore();
    }
}
