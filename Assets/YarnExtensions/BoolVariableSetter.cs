using UnityEngine;

namespace YarnExtensions
{
[AddComponentMenu("Custom Components/Yarn Spinner/Bool Variable Setter")]
public class BoolVariableSetter : YarnValueSetter<bool>
{
    public override void SetValue(bool value)
    {
        variableStorage.SetValue(variableName, value);
    }
}
}