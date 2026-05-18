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
    string errorMessage;
    
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
                errorMessage = "no such Enum found";
                enumPref.Type = null;
            }

            else if (ValidTypes.Count() > 1)
            {
                errorMessage = "more than one Enum with such name found";
                enumPref.Type = null;
            }

            else enumPref.Type = ValidTypes.First();
        }
        
        if(enumPref.Type == null)
        {
            if(!string.IsNullOrWhiteSpace(typeName.stringValue))
                GUILayout.Label( $"{typeName.stringValue} - {errorMessage}");
            return;
        }
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