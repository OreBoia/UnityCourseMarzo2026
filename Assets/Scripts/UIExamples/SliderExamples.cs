using UnityEngine;
using UnityEngine.UI;

public class SliderExamples : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();

        slider.maxValue = 100;
        slider.minValue = 0;
        slider.wholeNumbers = true;
        slider.onValueChanged.AddListener(OnSliderChanged);
    }

    private void OnSliderChanged(float value)
    {
        Debug.Log($"Il valore dello slider è {value}");
    }
}
