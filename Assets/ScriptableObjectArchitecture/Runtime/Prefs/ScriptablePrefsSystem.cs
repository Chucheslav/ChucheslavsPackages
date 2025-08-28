using UnityEngine;

namespace ScriptableObjectArchitecture
{
[CreateAssetMenu(menuName = "SOA/Prefs/System", order = -101)]
public class ScriptablePrefsSystem : ScriptableObject
{
    [SerializeField] private ScriptablePrefsContainer prefsContainer;

    private static ScriptablePrefsSystem _instance;

    private void OnEnable()
    {
        if (_instance != null)
            Debug.Log("More then one localization system scriptable object referenced, last referenced will be used");
        _instance = this;
        if(prefsContainer!= null) prefsContainer.LoadAll();
    }
    
    private void OnDisable()
    {
        if(prefsContainer!= null) prefsContainer.SaveAll();
    }

    public static void InitializeWithDefaults() => _instance.prefsContainer.InitializeWithDefaults();
}
}