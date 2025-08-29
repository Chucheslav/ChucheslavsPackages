using UnityEngine;

namespace YarnExtensions
{
[AddComponentMenu("Custom Components/Yarn Spinner/Float Variable Setter")]
public class FloatVariableSetter : YarnValueSetter<float>
{
    public override void SetValue(float value) => variableStorage.SetValue(variableName, value);
}
}