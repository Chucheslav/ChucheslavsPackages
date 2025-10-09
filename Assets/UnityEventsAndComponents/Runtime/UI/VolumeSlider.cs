using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))][AddComponentMenu("Custom Components/UI/Volume Slider")]
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string parameterName;
    [SerializeField] private float maxDecibels = 0f;
    [SerializeField] private float minDecibels = -80f;
    
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        
        _slider.onValueChanged.AddListener((f) => SetVolume(f));
    }

    private void SetVolume(float value)
    {
        float db =minDecibels +  (value - _slider.minValue)/ (_slider.maxValue - _slider.minValue) * (maxDecibels - minDecibels);
        mixer.SetFloat(parameterName, db);
    }
}
