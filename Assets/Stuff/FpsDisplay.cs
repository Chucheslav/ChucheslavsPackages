using TMPro;
using UnityEngine;

namespace UITools
{
[RequireComponent(typeof(FpsCounter))]
public class FpsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lowestText;
    [SerializeField] private TextMeshProUGUI averageText;
    [SerializeField] private TextMeshProUGUI highestText;
    [SerializeField] [Min(1)] private int maxDisplayValue = 200; 

    private FpsCounter _fpsCounter;

    private string[] numberStrings;

    private void Awake()
    {
        _fpsCounter = GetComponent<FpsCounter>();
        numberStrings = new string[maxDisplayValue + 1];
        for (var i = 0; i < numberStrings.Length; i++)
        {
            numberStrings[i] = i.ToString();
        }
    }

    private void Update()
    {
        lowestText.text = numberStrings[Mathf.Clamp(_fpsCounter.LowestFPS, 0, maxDisplayValue)];
        averageText.text = numberStrings[Mathf.Clamp(_fpsCounter.AverageFPS, 0, maxDisplayValue)];
        highestText.text = numberStrings[Mathf.Clamp(_fpsCounter.HighestPFS, 0, maxDisplayValue)];
    }
}
}
