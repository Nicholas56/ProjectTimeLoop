using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    Transform featureInteract;

    private void Start()
    {
        featureInteract = GameObject.FindGameObjectWithTag("Interact").transform;
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, featureInteract.position) < 2f)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GetComponent<FeatureScript>().Effect(transform);
            }
        }
    }

}
