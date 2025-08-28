using UnityEngine;

namespace ScriptableObjectArchitecture.Base
{
public abstract class GenericEventEditor<T> : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GenericEvent<T> se = target as GenericEvent<T>;

        if (GUILayout.Button("Clear subscribers")) se.Clear();
    }
}
}