using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureScript : MonoBehaviour
{
    public Feature feature;

    bool isCarry = false;
    Transform player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Interact").transform;
        switch (feature.type)
        {
            case Feature.element.Light:
                gameObject.AddComponent<Light>();
                break;
            case Feature.element.Collect:
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                break;
            case Feature.element.Unlock:
                gameObject.SetActive(false);
                break;
        }
    }

    private void Update()
    {
        if (isCarry)
        {
            transform.SetParent(player);
        }
    }

    public void Effect(Transform playerTransform)
    {
        switch (feature.type)
        {
            case Feature.element.Light:
                GetComponent<Light>().color = Color.red;
                GetComponent<Light>().intensity = 10f;
                break;
            case Feature.element.Collect:

                break;
            case Feature.element.Unlock:

                break;
            case Feature.element.Carry:
                isCarry = !isCarry;
                break;
            case Feature.element.Basket:

                break;
        }
    }

}
