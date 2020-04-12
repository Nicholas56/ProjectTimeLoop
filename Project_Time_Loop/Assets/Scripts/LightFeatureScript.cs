using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Nicholas Easterby - EAS12337350
//Inherits from feature script and provides unique functionality
public class LightFeatureScript : FeatureScript
{
    public override void Effect()
    {
        //Allow the player to turn the light on only once
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
