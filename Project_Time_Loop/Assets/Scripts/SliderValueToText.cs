using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

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
