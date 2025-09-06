using UnityEngine;

namespace UnityEventsAndComponents.Counters
{
[AddComponentMenu("Custom Components/Counters/Float Counter")]
public class FloatCounter : CounterComponent<float>
{
    public void AdjustValue(float adjustment) => SetValue(Value + adjustment);
}
}