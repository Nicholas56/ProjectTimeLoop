using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Nicholas Easterby - EAS12337350
//Allows the plater to interact with features
public class InteractScript : MonoBehaviour
{
    Transform featureInteract;

    private void Start()
    {
        featureInteract = GameObject.FindGameObjectWithTag("Interact").transform;
    }
    private void Update()
    {
        //Uses distance check to allow interaction
        if (Vector3.Distance(transform.position, featureInteract.position) < 2f)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GetComponent<FeatureScript>().Effect();
            }
        }
    }

}
