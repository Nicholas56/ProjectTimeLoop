using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFeatureScript : FeatureScript
{
    public override void Effect()
    {
        if (!isInteracted)
        {
            base.Effect();
            Light light = GetComponentInChildren<Light>();
            light.color = Color.red;
            light.intensity = 10f;
            PuzzleMaster.AddToScore();
        }
    }
}
