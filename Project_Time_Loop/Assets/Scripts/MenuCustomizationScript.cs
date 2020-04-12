using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//Nicholas Easterby - EAS12337350
//Handles the Customize screen options using Unity events
public class MenuCustomizationScript : MonoBehaviour
{
    public Settings settings;
    public Slider roomSizeSlider;
    public Slider featureNumSlider;
    public Slider minHghtSlider;
    public Slider maxHghtSlider;
    public Slider beginTimeSlider;
    public Slider specialFeatureSlider;

    public TMP_Text rsName;
    public TMP_Text fnName;
    public TMP_Text minName;
    public TMP_Text maxName;
    public TMP_Text btName;
    public TMP_Text sfName;
    public void Start()
    {
        ChangeSettings();
    }
    public void ChangeGameMode(int gameMode)
    {
        settings.mode = (Settings.gameMode)gameMode;
    }

    public void ChangeRoomSize()
    {
        //Checks that the room isn't too small for the number of features
        if (roomSizeSlider.value * roomSizeSlider.value < featureNumSlider.value)
        {
            settings.roomSize = (int)Mathf.Ceil(Mathf.Sqrt(featureNumSlider.value));
            roomSizeSlider.value = settings.roomSize;
        }
        else
        {
            settings.roomSize = (int)roomSizeSlider.value;
        }
        rsName.text = "Room Size: " + roomSizeSlider.value;
    }
    public void ChangeNumberOfFeatures()
    {
        //Checks that there aren't too many features for the map size
        if (featureNumSlider.value > roomSizeSlider.value * roomSizeSlider.value || featureNumSlider.value < settings.numOfFeatures - specialFeatureSlider.value)
        {
            settings.numOfFeatures = Mathf.Min((int)(roomSizeSlider.value * roomSizeSlider.value), settings.numOfFeatures - (int)specialFeatureSlider.value);
            featureNumSlider.value = settings.numOfFeatures;
        }
        else
        {
            settings.numOfFeatures = (int)featureNumSlider.value;
        }
        fnName.text = "Number of Features: " + featureNumSlider.value;
    }
    public void ChangeMinHeight()
    {
        settings.minHeight = (int)minHghtSlider.value;
        minName.text = "Min height for tiles: " + minHghtSlider.value;
    }
    public void ChangeMaxHeight()
    {
        settings.maxHeight = (int)maxHghtSlider.value;
        maxName.text = "Max height for tiles: " + maxHghtSlider.value;
    }
    public void ChangeBeginMovingTime()
    {
        settings.beginMovingTime = (int)beginTimeSlider.value;
        btName.text = "Begin time for Tiles to move: " + beginTimeSlider.value;
    }
    public void ChangeSpecialFeatures()
    {
        //Depending on the special features required for the game mode, sets accordingly
        switch (settings.mode)
        {
            case Settings.gameMode.LightGame:
                settings.specialFeatures[0] = (int)specialFeatureSlider.value;
                specialFeatureSlider.value = settings.specialFeatures[0];
                break;
            case Settings.gameMode.CollectionGame:
                settings.specialFeatures[1] = (int)specialFeatureSlider.value;
                specialFeatureSlider.value = settings.specialFeatures[1];
                break;
            case Settings.gameMode.Portal:
                if (specialFeatureSlider.value < 2)
                {
                    settings.specialFeatures[2] = 2;
                    specialFeatureSlider.value = settings.specialFeatures[2];
                }
                else
                {
                    settings.specialFeatures[2] = (int)specialFeatureSlider.value;
                    specialFeatureSlider.value = settings.specialFeatures[2];
                }
                break;
        }
        sfName.text = "Number of special features: " + (specialFeatureSlider.value -1);
    }
    public void ChangeSettings()
    {
        //Calls each function for total refresh
        ChangeRoomSize();
        ChangeNumberOfFeatures();
        ChangeMinHeight();
        ChangeMaxHeight();
        ChangeBeginMovingTime();
        ChangeSpecialFeatures();
    }
}
