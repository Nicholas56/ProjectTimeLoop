using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feature
{
    public enum element { None, Light, Collect, Unlock, Carry, Basket };
    public element type;


    public Feature(element element)
    {
        type = element;
    }
}
