using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureScript : MonoBehaviour
{
    public enum element { Color, Light};
    public element type;

    void Start()
    {
        gameObject.AddComponent<Light>();
    }

    public void Effect()
    {
        GetComponent<Light>().color = Color.red;
        GetComponent<Light>().intensity = 150f;
    }

}
