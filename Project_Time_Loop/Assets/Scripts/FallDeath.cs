using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<GameManager>().ResetTime();
    }
}
