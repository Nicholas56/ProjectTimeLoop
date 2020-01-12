using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    public void AlterSound()
    {
        sound.volume = MenuOptions.soundVolume / 100f;
        if (MenuOptions.soundOn) { sound.mute = false; } else { sound.mute = true; }
    }
}
