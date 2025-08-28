using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Base
{

public abstract class GenericVariableEditor<T> : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();
        DrawDefaultInspector();
        if (EditorGUI.EndChangeCheck())
        {
            (target as GenericVariable<T>)?.Raise();
        }
        
        GenericVariable<T> se = target as GenericVariable<T>;

        if (GUILayout.Button("Raise")) se.Raise();

        if (GUILayout.Button("Clear subscribers")) se.Clear();
    }
}
}