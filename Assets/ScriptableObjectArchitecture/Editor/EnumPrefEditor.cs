using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor
{
[CustomEditor(typeof(EnumPref))]
public class EnumPrefEditor : UnityEditor.Editor
{
    private int _index;
    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("prefID"));
        
        EditorGUI.BeginChangeCheck();
        SerializedProperty typeName = serializedObject.FindProperty("typeName");
        EditorGUILayout.PropertyField(typeName);
        EnumPref enumPref = target as EnumPref;
        if (EditorGUI.EndChangeCheck())
        {
            List<Type> ValidTypes = (from asm in AppDomain.CurrentDomain.GetAssemblies()
                from type in asm.GetTypes()
                where type.IsEnum && type.Name == typeName.stringValue
                select type).ToList();
            if (!ValidTypes.Any())
            {
                enumPref.Type = null;
                GUILayout.Label(  typeName.stringValue + " - No such Enum found");
                return;
            }

            if (ValidTypes.Count() > 1)
            {
                enumPref.Type = null;
                GUILayout.Label("more then one fitting Enum found");
                return;
            }

            enumPref.Type = ValidTypes.First();
        }
        
        if(enumPref.Type == null) return;
        GUILayout.Label("Choose Value");
        string[] choices = Enum.GetNames(enumPref.Type);
        int _index = Array.IndexOf(choices, enumPref.Value);
        if (_index < 0) _index = 0;
        _index = EditorGUILayout.Popup(_index, choices);
        enumPref.Value = choices[_index];
        GUILayout.Label("Choose Default Value");
        SerializedProperty property = serializedObject.FindProperty("defaultValue");
        _index = Array.IndexOf(choices,property.stringValue );
        if (_index < 0) _index = 0;
        _index = EditorGUILayout.Popup(_index, choices);
        property.stringValue = choices[_index];
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(target);
    }
    
    
    
}
}