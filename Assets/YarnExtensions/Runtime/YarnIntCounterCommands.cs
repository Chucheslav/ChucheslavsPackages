using UnityEngine;
using UnityEventsAndComponents.Counters;
using Yarn.Unity;

namespace YarnExtensions
{
[AddComponentMenu("Custom Components/Yarn Spinner/Int Counter Commands")]
[RequireComponent(typeof(IntCounter))]
public class YarnIntCounterCommands : MonoBehaviour
{
    private IntCounter _counter;

    private void Awake()
    {
        _counter = GetComponent<IntCounter>();
    }
    
    [YarnCommand("adjustCounterI")]
    public void AdjustCounter(int adjustment) => _counter.AdjustValue(adjustment);
    
    [YarnCommand("SetCounterI")]
    public void SetCounter(int value) => _counter.SetValue(value);
    
    [YarnCommand("ResetCounterI")]
    public void ResetCounter() => _counter.Reset();
}
}