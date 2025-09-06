using UnityEngine;

[CreateAssetMenu(fileName = "IntCounter", menuName = "Scriptable Objects/Int Counter")]
public class IntCounterScriptableObject : ScriptableObjectCounter<int>
{
    public void AdjustValue(int adjustment) => SetValue(value + adjustment);
}