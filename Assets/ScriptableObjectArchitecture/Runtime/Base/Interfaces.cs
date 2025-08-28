namespace ScriptableObjectArchitecture.Base
{
public interface ISimpleEventListener
{
    public void OnEventRaised();
}

public interface IScriptablePref
{
    public void SaveCurrentValue();
    public void Load();
    public void SaveDefaultValue();

    public void DeleteFromStorage();
    public string PrefID { get; }
}
}