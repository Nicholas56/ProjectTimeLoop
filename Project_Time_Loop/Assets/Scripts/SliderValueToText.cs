using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
//Nicholas Easterby - EAS12337350
//Script for sliders to display value, when slider is altered
public class SliderValueToText : MonoBehaviour
{
    Slider sliderUI;
    public string sliderName;
    public TMP_Text textSliderValue;

    void Start()
    {
        sliderUI = gameObject.GetComponent<Slider>();
        ShowSliderValue();
    }

    public void ShowSliderValue()
    {
        string sliderMessage = sliderName + sliderUI.value;
        textSliderValue.text = sliderMessage;
    }
}
