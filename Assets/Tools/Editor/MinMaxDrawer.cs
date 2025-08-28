using UnityEditor;
using UnityEngine;

//remember, padawan: this goes to Editor folder

[CustomPropertyDrawer(typeof(MinMaxAttribute))]
public class MinMaxDrawer : PropertyDrawer
{
    private const int Padding = 10; //should be about right
    private const int FFraction = 5; //fraction of controla area float fields occupy;
    private const int MinFFSize = 32; //todo: look for better way to size float field;
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedPropertyType propertyType = property.propertyType;
        if(propertyType != SerializedPropertyType.Vector2) return;
        MinMaxAttribute minMaxAttribute = attribute as MinMaxAttribute;

        //returns the rect of the control minus the label
        Rect controlRect = EditorGUI.PrefixLabel(position, label);
        //lets split in 3 parts with padding
        Rect leftRect = new Rect(controlRect.position, new Vector2(FloatRectWidth(), controlRect.height));
        Rect sliderRect = new Rect(controlRect.position.x + FloatRectWidth() + Padding, controlRect.y, 
            controlRect.width  - (FloatRectWidth() + Padding)*2, controlRect.height);
        Rect rightRect = new Rect(controlRect.position.x + controlRect.width - FloatRectWidth(), controlRect.y,
            
            FloatRectWidth(), controlRect.height);
        
        EditorGUI.BeginChangeCheck();
        Vector2 vector2 = property.vector2Value;
        float min = vector2.x;
        float max = vector2.y;
        float minLimit = minMaxAttribute.Min;
        float maxLimit = minMaxAttribute.Max;

        min = EditorGUI.FloatField(leftRect, float.Parse(min.ToString()));
        max = EditorGUI.FloatField(rightRect, float.Parse(max.ToString()));
        
        EditorGUI.MinMaxSlider(sliderRect, ref min, ref max, minLimit, maxLimit );
        
        //you can possibly delete two lines below
        if (min < minLimit) min = minLimit;
        if (max > maxLimit) max = maxLimit;

        if (EditorGUI.EndChangeCheck()) property.vector2Value = new Vector2(min, max < min ? min : max);

        float FloatRectWidth() => Mathf.Max(MinFFSize, controlRect.width / FFraction);
    }
}