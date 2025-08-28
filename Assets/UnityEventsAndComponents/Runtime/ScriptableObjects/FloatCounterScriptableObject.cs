using UnityEngine;

[CreateAssetMenu(fileName = "FloatCounter", menuName = "Scriptable Objects/Float Counter")]
public class FloatCounterScriptableObject : ScriptableObjectCounter<float>
{
    public void AdjustValue(float adjustment) => SetValue(value + adjustment);
    public void AdjustValue(int adjustment) => SetValue(value + adjustment);
}