using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Nicholas Easterby - EAS12337350
//Allows other scripts to access and change sound settings
public class SoundControl : MonoBehaviour
{
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        //Sound Options
        sound = GetComponent<AudioSource>();
        sound.volume = MenuOptions.soundVolume / 100f;
        if (MenuOptions.soundOn) { sound.mute = false; } else { sound.mute = true; }

    }

    public void AlterSound()
    {
        sound.volume = MenuOptions.soundVolume / 100f;
        if (MenuOptions.soundOn) { sound.mute = false; } else { sound.mute = true; }
    }
}
