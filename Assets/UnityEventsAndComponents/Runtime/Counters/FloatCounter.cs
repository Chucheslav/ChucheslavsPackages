using UnityEngine;

namespace UnityEventsAndComponents.Counters
{
[AddComponentMenu("Custom Components/Counters/Float Counter")]
public class FloatCounter : CounterComponent<float>
{
    public void AdjustValue(int adjustment) => SetValue(value + adjustment);
}
}