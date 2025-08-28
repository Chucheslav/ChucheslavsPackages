using System.Linq;
using ScriptableObjectArchitecture.Base;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor
{
[CustomEditor(typeof(ScriptablePrefsContainer))]
public class ScriptablePrefsContainerEditor : UnityEditor.Editor
{
    private bool showMenu;
    
    private bool _showRedButton;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        ScriptablePrefsContainer spc = target as ScriptablePrefsContainer;

        if (GUILayout.Button("Reset to defaults")) spc.InitializeWithDefaults();
        if (GUILayout.Button("Clear from storage")) spc.ClearPrefs();
        if (GUILayout.Button("Load prefs")) spc.LoadAll();
        if (GUILayout.Button("Save prefs")) spc.SaveAll();
        if (GUILayout.Button("Clear list")) spc.ClearList();
        if (GUILayout.Button("Delete all non listed prefs")) _showRedButton = true;

        if (_showRedButton )
        {
            GUILayout.Label("Warning, this will also wipe all prefs not in the list above");
            
            GUI.backgroundColor = Color.red;
            if(GUILayout.Button("DO IT!!"))
            {
                PlayerPrefs.DeleteAll();
                spc.SaveAll();
                _showRedButton = false;
            }
            
            GUI.backgroundColor = Color.green;
            if ( GUILayout.Button("Abort" )) _showRedButton = false;
        }
    }
}
}