using ScriptableObjectArchitecture.Base;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
[CreateAssetMenu(menuName = "SOA/Prefs/StringPref")]
public class StringPref : ScriptablePref<string>
{
    protected override void Save() => PlayerPrefs.SetString(prefID, Value);
    protected override string LoadValue() => PlayerPrefs.GetString(prefID);
}
}