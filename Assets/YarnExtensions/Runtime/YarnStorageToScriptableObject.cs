using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

namespace YarnExtensions
{
[AddComponentMenu(menuName: "Сustom Components/Yarn Spinner/Variable Storage to Scriptable Object")]
public class YarnStorageToScriptableObject : VariableStorageBehaviour
{
    [SerializeField] private YarnStorageSO scriptableObjectStorage;

    private void Awake()
    {
        if (TryGetComponent(out DialogueRunner dialogueRunner)) dialogueRunner.VariableStorage = this;
        else Debug.LogWarning("Scriptable Object Variable Storage could not register with dialogue runner, please assign manually");
    }

    public override bool TryGetValue<T>(string variableName, out T result) where T : default => 
        scriptableObjectStorage.TryGetValue(variableName, out result);

    public override void SetValue(string variableName, string stringValue) => 
        scriptableObjectStorage.SetValue(variableName, stringValue);

    public override void SetValue(string variableName, float floatValue) => 
        scriptableObjectStorage.SetValue(variableName, floatValue);

    public override void SetValue(string variableName, bool boolValue) => 
        scriptableObjectStorage.SetValue(variableName, boolValue);

    public override void Clear() => scriptableObjectStorage.Clear();

    public override bool Contains(string variableName) => 
        scriptableObjectStorage.Contains(variableName);

    public override void SetAllVariables(Dictionary<string, float> floats, Dictionary<string, string> strings, Dictionary<string, bool> bools, bool clear = true) => 
        scriptableObjectStorage.SetAllVariables(floats, strings, bools, clear);

    public override (Dictionary<string, float> FloatVariables, Dictionary<string, string> StringVariables, Dictionary<string, bool> BoolVariables) GetAllVariables() => 
        scriptableObjectStorage.GetAllVariables();
}
}