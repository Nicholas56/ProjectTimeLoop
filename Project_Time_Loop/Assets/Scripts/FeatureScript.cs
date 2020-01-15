using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureScript : MonoBehaviour
{
    public Feature feature = new Feature(Feature.element.None);

    public int featureID;

    bool isCarry = false;
    Transform player;
    bool isInteracted = false;


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
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3);
            for(int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].tag == "Portal")
                {
                    if (hitColliders[i].GetComponent<FeatureScript>().GetID() == featureID)
                    {
                        transform.transform.localScale += new Vector3(0.1F, .1f, .1f) * -3 * Time.deltaTime;
                    }
                }
            }
        }
        else transform.SetParent(null);
    }

    public bool Check()
    {
        return isInteracted;
    }

    public int GetID()
    {
        return featureID;
    }
    public void SetID(int newID)
    {
        featureID = newID;
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
        isInteracted = true;
    }
}
