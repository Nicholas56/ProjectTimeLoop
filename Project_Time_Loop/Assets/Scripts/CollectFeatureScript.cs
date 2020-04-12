using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Nicholas Easterby - EAS12337350
//Inherits from the feature script and give unique function to this
public class CollectFeatureScript : FeatureScript
{
    private void OnTriggerEnter(Collider other)
    {
        //Removes object and updates score
        Destroy(gameObject);
        PuzzleMaster.AddToScore();
    }
}
