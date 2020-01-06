using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallDeath : MonoBehaviour
{
    public Image whiteScreen;
    bool fell = false;
    float colorTime;

    private void OnTriggerEnter(Collider other)
    {
        fell = true;
        whiteScreen.gameObject.SetActive(true);
        Invoke("NextScene", 1f);
    }

    private void Update()
    {
        if (fell)
        {
            whiteScreen.color = Color.Lerp(Color.black, Color.white, colorTime);
            colorTime += Time.deltaTime;
        }
    }

    void NextScene()
    {

        GetComponentInParent<GameManager>().ResetTime();
    }
}
