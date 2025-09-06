using UnityEngine;

namespace UnityEventsAndComponents.Counters
{
[AddComponentMenu("Custom Components/Counters/Int Counter")]
public class IntCounter : CounterComponent<int>
{
    public void AdjustValue(int adjustment) => SetValue(Value + adjustment);
}
}