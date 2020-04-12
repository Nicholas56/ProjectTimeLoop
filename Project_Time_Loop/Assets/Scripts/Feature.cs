using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Nicholas Easterby - EAS12337350
//Provides feature information for other scripts to use
public class Feature
{
    public enum element { None, Light, Collect, Unlock, Carry, Basket };
    public element type;


    public Feature(element element)
    {
        type = element;
    }
}
