using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor
{
[CustomEditor(typeof(SimpleEvent))]
public class SimpleEventEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        SimpleEvent se = target as SimpleEvent;

        if (GUILayout.Button("Raise")) se.Raise();
        
        if (GUILayout.Button("Clear subscribers")) se.Clear();
    }
}
}
