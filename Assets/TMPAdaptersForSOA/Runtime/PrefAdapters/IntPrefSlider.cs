using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjectArchitecture.MonobehaviourAdapters
{
public class IntPrefSlider : MonoBehaviour
{
    [SerializeField] private IntPref pref;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI numberDisplay;

    private void Awake()
    {
        slider.onValueChanged.AddListener(UpdateValue);
        slider.wholeNumbers = true;
        slider.minValue = pref.MinValue;
        slider.maxValue = pref.MaxValue;
        pref.Link(UpdateSlider);
    }

    private void UpdateSlider(int value)
    {
        slider.value = value;
        if (numberDisplay) numberDisplay.text = value.ToString();
    }

    private void UpdateValue(float value)
    {
        pref.Value = Mathf.RoundToInt(value);
        pref.SaveCurrentValue();
        if (numberDisplay) numberDisplay.text =  pref.Value.ToString();
    }

    private void OnDestroy()
    {
        slider.onValueChanged.RemoveListener(UpdateValue); //not sure if this is needed
        pref.Unlink(UpdateSlider);
    }
}
}