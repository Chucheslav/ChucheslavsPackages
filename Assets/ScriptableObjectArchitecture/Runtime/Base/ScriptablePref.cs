using UnityEngine;

namespace ScriptableObjectArchitecture.Base
{
public abstract class ScriptablePref<T> : GenericVariable<T>, IScriptablePref
{
    [SerializeField] protected string prefID;
    [SerializeField] private T defaultValue;

    public string PrefID => prefID; //exposed for use by editor script

    public void SaveCurrentValue() => Save(Value);
    public void SaveDefaultValue() => Save(defaultValue);

    public void DeleteFromStorage() => PlayerPrefs.DeleteKey(prefID);

    public void Load() => Value = PlayerPrefs.HasKey(prefID) ? LoadValue() : defaultValue;

    private void Save(T value)
    {
        Value = value;
        Save();
    }
    
    protected virtual void Save(){}
    
    protected virtual T LoadValue() => defaultValue;

    private void OnEnable() => Load();
    private void OnDisable() => Save();
}
}
