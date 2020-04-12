using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Nicholas Easterby - EAS12337350
//Causes the scene to reset when player falls off the map
public class FallDeath : MonoBehaviour
{
    public Image whiteScreen;
    public bool fell = false;
    float colorTime;

    private void OnTriggerEnter(Collider other)
    {
        //Makes the white screen appear and a 1 second delay for the reset to occur
        fell = true;
        whiteScreen.gameObject.SetActive(true);
        Invoke("NextScene", 1f);
    }

    private void Update()
    {
        if (fell)
        {
            //For the duration of the delay, the screen changes color
            whiteScreen.color = Color.Lerp(Color.black, Color.white, colorTime);
            colorTime += Time.deltaTime;
        }
    }

    void NextScene()
    {

        GetComponentInParent<GameManager>().ResetTime();
    }
}
