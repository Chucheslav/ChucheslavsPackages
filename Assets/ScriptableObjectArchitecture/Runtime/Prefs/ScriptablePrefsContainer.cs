using System.Collections.Generic;
using System.Linq;
using ScriptableObjectArchitecture.Base;
using UnityEngine;
using Tools;
using Tools.Extensions;

namespace ScriptableObjectArchitecture
{
[CreateAssetMenu(menuName = "SOA/Prefs/Container", order = -100)]
public class ScriptablePrefsContainer : ScriptableObject
{
    [SerializeField, TypeRestriction(typeof(IScriptablePref))] private List<ScriptableObject> storageList = new();

    private List<IScriptablePref> _prefs = new();
    
    
    public IReadOnlyList<IScriptablePref> Prefs => _prefs;

    public void AddPref(IScriptablePref toAdd)
    {
        if (toAdd is not ScriptableObject so)
        {
            this.LogError(toAdd + "is not a scriptable object, IScriptablePref should only be used on scriptable objects");
            return;
        }
        storageList.Add(so);
        _prefs.Add(toAdd);
    }

    private void OnEnable() => ListsCleanup();

    private void OnValidate()
    {
        if(storageList.Count != _prefs.Count) ListsCleanup();
    }

    private void ListsCleanup()
    {
        storageList = storageList.Where(so => so != null && so is IScriptablePref).Distinct().ToList();
        _prefs.Clear();
        _prefs = storageList.Select(s => s as IScriptablePref).ToList();
    }

    public void RemovePref(IScriptablePref toRemove)
    {
        if (toRemove is not ScriptableObject so)
        {
            this.LogError(toRemove + "is not a scriptable object, IScriptablePref should only be used on scriptable objects");
            return;
        }
        _prefs.Remove(toRemove);
        storageList.Remove(so);
    }

    public void InitializeWithDefaults()
    {
        foreach (IScriptablePref pref in _prefs) pref.SaveDefaultValue();
    }

    public void ClearPrefs()
    {
        foreach (IScriptablePref pref in _prefs) pref.DeleteFromStorage();
    }

    public void LoadAll()
    {
        foreach (IScriptablePref pref in _prefs) pref.Load();
    }

    public void SaveAll()
    {
        foreach (IScriptablePref pref in _prefs) pref.SaveCurrentValue();
    }

    public void ClearList()
    {
        _prefs.Clear();
        storageList.Clear();
    }
}
}