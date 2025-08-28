using System.Linq;
using Tools;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(TypeRestrictionAttribute))]
public class TypeRestrictionDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //base.OnGUI(position, property, label);
        EditorGUI.PropertyField(position, property, label, true);
        
        TypeRestrictionAttribute thisAttribute = attribute as TypeRestrictionAttribute;
        
        //CheckDragAndDrops
        
        Rect fieldRect = GUILayoutUtility.GetLastRect();

        if (!fieldRect.Contains(Event.current.mousePosition)) return;
        if (Event.current.type == EventType.DragUpdated)
        {
            DragAndDrop.visualMode =
                DragAndDrop.objectReferences.Any(s => s.GetType().IsSubclassOf(thisAttribute.Type))
                    ? DragAndDropVisualMode.Link
                    : DragAndDropVisualMode.Rejected;
        }
        else if (Event.current.type == EventType.DragPerform)
        {
            DragAndDrop.objectReferences = DragAndDrop.objectReferences
                .Where(or => or.GetType().IsSubclassOf(thisAttribute.Type)).ToArray();
            Event.current.Use();
        }
    }
}
