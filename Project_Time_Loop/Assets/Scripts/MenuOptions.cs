using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{
    public GameObject controlsPanel;
    public GameObject optionsPanel;
    public GameObject loadPanel;
    public GameObject customizePanel;
    public GameObject achievementPanel;

    public GameObject SavePanel;

    public static bool soundOn = true;
    public static int soundVolume = 70;

    public void OpenLoadPanel()
    {
        SetFalse();
        loadPanel.GetComponent<Animator>().SetBool("OpenLoad", true);
    }

    public void OpenOptionsPanel()
    {
        SetFalse();
        optionsPanel.GetComponent<Animator>().SetBool("OpenOptions", true);
    }

    public void OpenControlsPanel()
    {
        SetFalse();
        controlsPanel.GetComponent<Animator>().SetBool("OpenControls", true);
    }

    public void OpenCustomizePanel()
    {
        SetFalse();
        customizePanel.GetComponent<Animator>().SetBool("OpenCustomize", true);
    }

    public void OpenAchievementPanel()
    {
        SetFalse();
        achievementPanel.GetComponent<Animator>().SetBool("OpenAchievement", true);
    }

    void SetFalse()
    {
        loadPanel.GetComponent<Animator>().SetBool("OpenLoad", false);
        optionsPanel.GetComponent<Animator>().SetBool("OpenOptions", false);
        controlsPanel.GetComponent<Animator>().SetBool("OpenControls", false);
        customizePanel.GetComponent<Animator>().SetBool("OpenCustomize", false);
        achievementPanel.GetComponent<Animator>().SetBool("OpenAchievement", false);
    }

    public void OpenSavePanel()
    {
        SavePanel.GetComponent<Animator>().SetBool("OpenSave", !SavePanel.GetComponent<Animator>().GetBool("OpenSave"));
    }

    public void SoundToggle()
    {
        soundOn = !soundOn;
    }

    public void SoundVolume(UnityEngine.UI.Slider slider)
    {
        soundVolume = Mathf.FloorToInt( slider.value);
    }

    public void MessageToggle()
    {
        OptionScript.showMessage = !OptionScript.showMessage;
    }    

    public void TimerToggle()
    {
        OptionScript.showTimer = !OptionScript.showTimer;
    }
}
