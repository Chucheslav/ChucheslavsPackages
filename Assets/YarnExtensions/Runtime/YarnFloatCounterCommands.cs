//#if BASE_COMPONENTS

using UnityEngine;
using UnityEventsAndComponents.Counters;
using Yarn.Unity;

namespace YarnExtensions
{
[RequireComponent(typeof(FloatCounter))]
[AddComponentMenu("Custom Components/Yarn Spinner/Float Counter Commands")]
[DisallowMultipleComponent]
public class YarnFloatCounterCommands : MonoBehaviour
{
    private FloatCounter _counter;

    private void Awake()
    {
        _counter = GetComponent<FloatCounter>();
    }

    [YarnCommand("adjustCounterF")]
    public void AdjustCounter(float adjustment) => _counter.AdjustValue(adjustment);

    [YarnCommand("setCounterF")]
    public void SetCounter(float value) => _counter.SetValue(value);
    
    [YarnCommand("resetCounterF")]
    public void ResetCounter() => _counter.Reset();
}
}

//#endif