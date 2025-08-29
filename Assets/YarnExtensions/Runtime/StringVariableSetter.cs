using UnityEngine;

namespace YarnExtensions
{
[AddComponentMenu("Custom Components/Yarn Spinner/String Variable Setter")]
public class StringVariableSetter : YarnValueSetter<string>
{
    public override void SetValue(string value) => variableStorage.SetValue(variableName, value);
}
}